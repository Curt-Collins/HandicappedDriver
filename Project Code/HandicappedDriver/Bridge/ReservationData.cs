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

        public void CancelRes(string spaceID)
        {
            this.Id = Int32.Parse(spaceID);
            Cancel();
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
                    "(SELECT ID FROM [ReservationStatus] WHERE [StatusDesc]=@statusDesc), " +
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

        public void CreateNew(string usr, string pwd)
        {
            string queryString1 = "INSERT INTO [Reservation] " +
                "(driver_id, parkingspace_id, fromtime, untiltime, status_id) VALUES " +
                "(@driver_id, @parkingspace_id, @fromtime, @untiltime, 4)";

            string queryString2 = "SELECT res_id FROM [Reservation] WHERE " +
                "driver_id=@driver_id AND parkingspace_id=@parkingspace_id AND status_id=4";

            if (Connect())
            {
                command = this.connection.CreateCommand();
                command.Parameters.AddWithValue("@driver_id", driver_ID);
                command.Parameters.AddWithValue("@parkingspace_id", space_Id);
                command.Parameters.AddWithValue("@fromTime", fromTime);
                command.Parameters.AddWithValue("@untilTime", untilTime);
                command.CommandText = queryString1;

                command.ExecuteNonQuery();
                command.Dispose();

                command = this.connection.CreateCommand();
                command.Parameters.AddWithValue("@driver_id", driver_ID);
                command.Parameters.AddWithValue("@parkingspace_id", space_Id);
                command.Parameters.AddWithValue("@fromTime", fromTime);
                command.CommandText = queryString2;

                Id = Int32.Parse(command.ExecuteScalar().ToString());
                command.Dispose();

                this.connection.Close();
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