using System;
using System.Data.SqlClient;

namespace HandicappedDriver.Bridge
{
    public class ReservationData : HandicappedDriverTableData
    {
        public int? Id;
        //public int? driver_ID;
        public string eMailAddress;
        public string locationDesc;
        public string statusDesc;
        public bool occupied;
        public string navigation;
        public DateTime fromTime;
        public DateTime untilTime;
        public int space_Id;
        public string resvID;

        public ReservationData() { }

        public ReservationData(int resID)
        {
            Id = resID;
            LoadReservation();
        }

        public void ParkInSpace(string spaceID)
        {
            int spID = Int32.Parse(spaceID);
            ReservationData r = new ReservationData(spID);
            r.occupied = true;
            // need to figure out how to change the reservation status to unavailable at this juncture
        }

        public void LeaveSpace(string spaceID)
        {
            int spID = Int32.Parse(spaceID);
            ReservationData r = new ReservationData(spID);
            r.occupied = false;
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
                    "WHERE StatusDesc = 'ACTIVE' AND ID=" + Id.ToString();
            }
            else if (!(string.IsNullOrEmpty(eMailAddress)))
            {
                queryString = "SELECT ID, LocationDesc, StatusDesc, Occupied, FromTime, UntilTime, " +
                    "Navigation, EMailAddress, Space_ID FROM SpaceReservation " +
                    "WHERE StatusDesc = 'ACTIVE' AND ID=" + eMailAddress;
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

                    rdr.Close();
                    this.Connection.Close();
                }
            }
        }

        public void Update()
        {
        }

        public void CreateNew(string usr, string pwd)
        {
        }

        public void PullRes()
        {

        }

        public void Park()
        {

        }

        public void Leave()
        {

        }

        public void Cancel()
        {

        }

    }
}