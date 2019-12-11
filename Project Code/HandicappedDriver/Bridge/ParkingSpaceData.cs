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
                command = connection.CreateCommand();
                command.CommandText = queryString;
                reader = command.ExecuteReader();

                ParkingSpace psp = new ParkingSpace();
                ResData r;
                int curSpaceID = -1;
                int prevSpaceID = -1;

                while (reader.Read())
                {
                    if (prevSpaceID != reader.GetInt32(8))
                    {
                        curSpaceID = reader.GetInt32(8);
                        psp = new ParkingSpace();
                        psp.Space_Id = curSpaceID;
                        psp.LocationDesc = reader.GetString(1);
                        psp.NavigationString = reader.GetString(6);
                        psp.Occupied = reader.GetBoolean(3);
                        psp.Avail = new List<ResData>();
                        listSpaces.Add(psp);
                    }

                    if (!(reader.IsDBNull(0)))
                    {
                        r = new ResData();
                        r.Res_Id = reader.GetInt32(0);
                        r.StatusDesc = reader.GetString(2);
                        r.FromTime = reader.GetDateTime(4);
                        r.UntilTime = reader.GetDateTime(5);
                        r.EMailAddr = reader.GetString(7);
                        listSpaces[listSpaces.IndexOf(psp)].Avail.Add(r);
                    }
                }

                command.Dispose();
                reader.Close();
                this.connection.Close();
            }

            return listSpaces;
        }

        private void InsertRes(ref ParkingSpace psp2, ref ResData r2)
        {

        }

        public void LoadInfo(int id)
        {

        String queryString = "SELECT LocationDesc, Occupied, Navigation " +
                "FROM ParkingSpace WHERE d.ID=" + id.ToString();

            if (Connect())
            {
                command = connection.CreateCommand();
                command.CommandText = queryString;
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    this.Id = reader.GetInt32(0);
                    this.fullName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    this.licensePlateNum = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    this.mobileNumber = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    this.eMailAddress = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    this.password = reader.IsDBNull(5) ? "" : reader.GetString(5);
                    this.licensePlateState = reader.IsDBNull(6) ? "" : reader.GetString(6);
                }

                reader.Close();
                this.connection.Close();
            }
        }
    }
}
