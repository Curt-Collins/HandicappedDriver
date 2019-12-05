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

        public string leifman
        {
            get { return ""; }
            set { }
        }

        public ReservationData() { }

        public ReservationData(int resID)
        {
            Id = resID;
            LoadReservation();
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
                    "Navigation, EMailAddress FROM SpaceReservation WHERE StatusDesc = 'ACTIVE' AND " +
                    "ID=" + Id.ToString();
            }
            else if (!(string.IsNullOrEmpty(eMailAddress)))
            {
                queryString = "SELECT ID, LocationDesc, StatusDesc, Occupied, FromTime, UntilTime, " +
                    "Navigation, EMailAddress FROM SpaceReservation WHERE  StatusDesc = 'ACTIVE' AND " + 
                    "EMailAddress" + eMailAddress;
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



        private string resvID = "";

        private void SetID(string r)
        {
            resvID = r;
        }

        public string GetID()
        {
            return resvID;
        }

        public void PullRes()
        {

        }

    }
}