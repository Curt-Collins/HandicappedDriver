using System;
using System.Data.SqlClient;

namespace HandicappedDriver.Bridge
{
    public class ReservationData : HandicappedDriverTableData
    {
        public int? Id;
        public int? driver_ID;
        public string eMailAddress;
        public string locationDesc;
        public string statusDesc;
        public bool occupied;
        public string navigation;
        public DateTime fromTime;
        public DateTime untilTime;
        public int space_Id;
        //public string resvID;

        public ReservationData() { }

        public ReservationData(int resID)
        {
            Id = resID;
            LoadReservation();
        }

        public void ParkInSpace(string spaceID)
        {
            this.Id = Int32.Parse(spaceID);
            Park();
            // need to figure out how to change the reservation status to unavailable at this juncture
        }

        public void LeaveSpace(string spaceID)
        {
            this.Id = Int32.Parse(spaceID);
            Leave();
            // need to figure out how to change the reservation status to available at this juncture
        }

        public ReservationData(string usr)
        {
            eMailAddress = usr;
            LoadReservation();
        }

       public void LoadReservation()
        {
            String queryString = "";

            if (Id != null)
            {
                queryString = "SELECT ID, LocationDesc, StatusDesc, Occupied, FromTime, UntilTime, " +
                    "Navigation, EMailAddress, Space_ID FROM SpaceReservation " + "" +
                    "WHERE (StatusDesc='ACTIVE' OR StatusDesc='PENDING') AND ID=" + Id.ToString();
            }
            else if (!(string.IsNullOrEmpty(eMailAddress)))
            {
                queryString = "SELECT ID, LocationDesc, StatusDesc, Occupied, FromTime, UntilTime, " +
                    "Navigation, EMailAddress, Space_ID, Driver_ID FROM SpaceReservation " +
                    "WHERE (StatusDesc='ACTIVE' OR StatusDesc='PENDING') AND EMailAddress" + eMailAddress;
            }

            if (Connect())
            {
                SqlCommand cmd = Connection.CreateCommand();
                cmd.CommandText = queryString;
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    this.Id = rdr.GetInt32(0);
                    this.locationDesc = rdr.IsDBNull(1) ? "" : rdr.GetString(1);
                    this.statusDesc = rdr.IsDBNull(2) ? "" : rdr.GetString(2);
                    this.occupied = rdr.GetBoolean(3);
                    this.fromTime = rdr.GetDateTime(4);
                    this.untilTime = rdr.GetDateTime(5);
                    this.navigation = rdr.IsDBNull(6) ? "" : rdr.GetString(6);
                    this.eMailAddress = rdr.IsDBNull(7) ? "" : rdr.GetString(7);
                    this.space_Id = rdr.GetInt32(8);
                    this.driver_ID = rdr.GetInt32(9);

                    rdr.Close();
                    this.Connection.Close();
                }
            }
        }

        public void Update()
        {
            String queryString1 = "UPDATE [Reservation] SET " +
                "[Status_ID]=" +
                    "(SELECT ID FROM [ReservationStatus] WHERE [StatusDesc]=@statusDesc), " +
                "WHERE ([ID]=@Id)";

            if (Connect())
            {
                SqlCommand cmd = this.Connection.CreateCommand();
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@statusDesc", statusDesc);
                cmd.CommandText = queryString1;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Connection.Close();
            }
        }

        public void CreateNew(string usr, string pwd)
        {
            string queryString1 = "INSERT INTO [Reservation] " +
                "(driver_id, parkingspace_id, fromtime, untiltime, status_id) VALUES " +
                "(@driver_id, @parkingspace_id, @fromtime, @untiltime, 4)";

            string queryString2 = "SELECT res_id FROM [Reservation] WHERE " +
                "driver_id=@driver_id AND parkingspace_id=@parkingspace_id AND status_id=4";

            SqlCommand cmd;

            if (Connect())
            {
                cmd = this.Connection.CreateCommand();
                cmd.Parameters.AddWithValue("@driver_id", driver_ID);
                cmd.Parameters.AddWithValue("@parkingspace_id", space_Id);
                cmd.Parameters.AddWithValue("@fromTime", fromTime);
                cmd.Parameters.AddWithValue("@untilTime", untilTime);
                cmd.CommandText = queryString1;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = this.Connection.CreateCommand();
                cmd.Parameters.AddWithValue("@driver_id", driver_ID);
                cmd.Parameters.AddWithValue("@parkingspace_id", space_Id);
                cmd.Parameters.AddWithValue("@fromTime", fromTime);
                cmd.CommandText = queryString2;

                Id = Int32.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                this.Connection.Close();
            }
        }

        public void Park()
        {
            statusDesc = "ACTIVE";
            Update();
        }

        public void Leave()
        {
            statusDesc = "COMPLETED";
            Update();
        }

        public void Cancel()
        {
            statusDesc = "CANCELLED";
            Update();
        }

    }
}