using System.Data.SqlClient;
using System.Collections.Generic;

namespace HandicappedDriver.Bridge
{
    public class AvailableSpaces
    {
        public List<ReservationData> Avail;
    }




    public class ParkingSpaceData : HandicappedDriverTableData
    {
        public int Id;
        
        public AvailableSpaces LoadAvailableSpaces(int lotID)
        {
            string queryString = "SELECT ID, LocationDesc, StatusDesc, Occupied, FromTime, UntilTime, " +
                "Navigation, EMailAddress, Space_ID FROM SpaceReservation " +
                "WHERE Space_Id=" + lotID.ToString(); 
            
            AvailableSpaces a = new AvailableSpaces();
            a.Avail = new List<ReservationData>();

            if (Connect())
            {
                SqlCommand cmd = Connection.CreateCommand();
                cmd.CommandText = queryString;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ReservationData r = new ReservationData();

                    r.Id = rdr.GetInt32(0);
                    r.locationDesc = rdr.IsDBNull(1) ? "" : rdr.GetString(1);
                    r.statusDesc = rdr.IsDBNull(2) ? "" : rdr.GetString(2);
                    r.occupied = rdr.GetBoolean(3);
                    r.fromTime = rdr.GetDateTime(4);
                    r.untilTime = rdr.GetDateTime(5);
                    r.navigation = rdr.IsDBNull(6) ? "" : rdr.GetString(6);
                    r.eMailAddress = rdr.IsDBNull(7) ? "" : rdr.GetString(7);
                    r.space_Id = rdr.GetInt32(8);

                    a.Avail.Add(r);
                }

                rdr.Close();
                this.Connection.Close();
            }

            return a;
        }

    }
}
