using System.Data.SqlClient;
using System.Collections.Generic;

namespace HandicappedDriver.Bridge
{
    public class LotInfo
    {
        public int id;
        public string name;
    }

    public class ParkingLotData : HandicappedDriverTableData
    {
        public List<LotInfo> Lots;

        public ParkingLotData()
        {
            string queryString = "SELECT id, LotName FROM ParkingLot";
            LotInfo l;

            if (Connect())
            {
                Lots = new List<LotInfo>();

                SqlCommand cmd = Connection.CreateCommand();
                cmd.CommandText = queryString;
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    l = new LotInfo();
                    l.id = rdr.GetInt32(0);
                    l.name = rdr.IsDBNull(1) ? "" : rdr.GetString(1);
                    Lots.Add(l);
                }

                rdr.Close();
                this.Connection.Close();
            }
        }
    }
}