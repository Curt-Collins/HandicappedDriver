using System;

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

        public ReservationData(string usr)
        {
            this.eMailAddress = usr;
            LoadReservation();
        }

        public void LoadReservation()
        {
            String queryString = "";

            if (Id != null)
            {
                queryString = "SELECT Res_ID, LocationDesc, StatusDesc, Occupied, FromTime, UntilTime, " +
                    "Navigation, EMailAddress, Space_ID, Driver_ID FROM SpaceReservations " + "" +
                    "WHERE (StatusDesc='ACTIVE' OR StatusDesc='PENDING') AND Res_ID=" + Id.ToString();
            }
            else if (!(string.IsNullOrEmpty(eMailAddress)))
            {
                queryString = "SELECT Res_ID, LocationDesc, StatusDesc, Occupied, FromTime, UntilTime, " +
                    "Navigation, EMailAddress, Space_ID, Driver_ID FROM SpaceReservations " +
                    "WHERE (StatusDesc='ACTIVE' OR StatusDesc='PENDING') AND EMailAddress='" + eMailAddress + "'";
            }

            if (Connect())
            {
                command = connection.CreateCommand();
                command.CommandText = queryString;
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    this.Id = reader.GetInt32(0);
                    this.locationDesc = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    this.statusDesc = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    this.occupied = reader.GetBoolean(3);
                    this.fromTime = reader.GetDateTime(4);
                    this.untilTime = reader.GetDateTime(5);
                    this.navigation = reader.IsDBNull(6) ? "" : reader.GetString(6);
                    this.eMailAddress = reader.IsDBNull(7) ? "" : reader.GetString(7);
                    this.space_Id = reader.GetInt32(8);
                    this.driver_ID = reader.GetInt32(9);

                    reader.Close();
                    command.Dispose();
                    this.connection.Close();
                }
            }
        }

        public void Update()
        {
            String queryString1 = "UPDATE [Reservation] SET " +
                "[Status_ID]=" +
                    "(SELECT ID FROM [ReservationStatus] WHERE [StatusDesc]=@statusDesc) " +
                "WHERE ([ID]=@Id)";

            if (Connect())
            {
                command = this.connection.CreateCommand();
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@statusDesc", statusDesc);
                command.CommandText = queryString1;

                command.ExecuteNonQuery();
                command.Dispose();
                this.connection.Close();
            }
        }

        public int CreateNew(string uname, int spid, DateTime fromT, DateTime untilT)
        {

            int uid;

            string queryString1 = "INSERT INTO [Reservation] " +
                "(driver_id, parkingspace_id, fromtime, untiltime, status_id) VALUES " +
                "(@driver_id, @parkingspace_id, @fromtime, @untiltime, 4)";

            string queryString2 = "SELECT id FROM [Reservation] WHERE " +
                "driver_id=@driver_id AND parkingspace_id=@parkingspace_id AND status_id=4";

            if (Connect())
            {
                command = this.connection.CreateCommand();
                command.CommandText = "SELECT id FROM Driver WHERE EMailAddress=@email";
                command.Parameters.AddWithValue("@email", uname);
                uid = Int32.Parse(command.ExecuteScalar().ToString());
                command.Dispose();

                command = this.connection.CreateCommand();
                command.Parameters.AddWithValue("@driver_id", uid);
                command.Parameters.AddWithValue("@parkingspace_id", spid);
                command.Parameters.AddWithValue("@fromTime", fromT);
                command.Parameters.AddWithValue("@untilTime", untilT);
                command.CommandText = queryString1;

                command.ExecuteNonQuery();
                command.Dispose();

                command = this.connection.CreateCommand();
                command.Parameters.AddWithValue("@driver_id", uid);
                command.Parameters.AddWithValue("@parkingspace_id", spid);
                command.Parameters.AddWithValue("@fromTime", fromT);
                command.CommandText = queryString2;

                Id = Int32.Parse(command.ExecuteScalar().ToString());
                command.Dispose();

                this.connection.Close();

                return (int)Id;
            }
            else
            {
                return 0;
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