using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace HandicappedDriver.Bridge
{
    public class ResData
    {
        public int Res_Id;
        public string StatusDesc;
        public DateTime FromTime;
        public DateTime UntilTime;
        public string EMailAddr;
    }

    public class ParkingSpace
    {
        public int Space_Id;
        public string LocationDesc;
        public string NavigationString;
        public Boolean Occupied;
        public List<ResData> Avail;
    }

    public class ParkingSpaceData : HandicappedDriverTableData
    {
        public int Id;

        public List<ParkingSpace> LoadAvailableSpaces(int lotID)
        {
            string queryString = "SELECT Res_ID, LocationDesc, StatusDesc, Occupied, FromTime, UntilTime, " +
                "Navigation, EMailAddress, Space_ID FROM SpaceReservations " +
                "WHERE ParkingLot_Id=" + lotID.ToString() + " ORDER BY Space_ID, FromTime";

            List<ParkingSpace> listSpaces = new List<ParkingSpace>();

            if (Connect())
            {
                SqlCommand cmd = Connection.CreateCommand();
                cmd.CommandText = queryString;
                SqlDataReader rdr = cmd.ExecuteReader();

                ParkingSpace psp = new ParkingSpace();
                ResData r;
                int curSpaceID = -1;
                int prevSpaceID = -1;

                while (rdr.Read())
                {
                    if (prevSpaceID != rdr.GetInt32(8))
                    {
                        curSpaceID = rdr.GetInt32(8);
                        psp = new ParkingSpace();
                        psp.Space_Id = curSpaceID;
                        psp.LocationDesc = rdr.GetString(1);
                        psp.NavigationString = rdr.GetString(6);
                        psp.Occupied = rdr.GetBoolean(3);
                        psp.Avail = new List<ResData>();
                        listSpaces.Add(psp);
                    }

                    if (!(rdr.IsDBNull(0)))
                    {
                        r = new ResData();
                        r.Res_Id = rdr.GetInt32(0);
                        r.StatusDesc = rdr.GetString(2);
                        r.FromTime = rdr.GetDateTime(4);
                        r.UntilTime = rdr.GetDateTime(5);
                        r.EMailAddr = rdr.GetString(7);
                        listSpaces[listSpaces.IndexOf(psp)].Avail.Add(r);
                    }
                }

                rdr.Close();
                this.Connection.Close();
            }

            return listSpaces;
        }

        private void InsertRes(ref ParkingSpace psp2, ref ResData r2)
        {

        }

        public void LoadInfo()
        {

        }
    }
}
