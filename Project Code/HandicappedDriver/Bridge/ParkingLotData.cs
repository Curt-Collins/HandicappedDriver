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

                command = connection.CreateCommand();
                command.CommandText = queryString;
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    l = new LotInfo();
                    l.id = reader.GetInt32(0);
                    l.name = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    Lots.Add(l);
                }
                command.Dispose();
                reader.Close();
                this.connection.Close();
            }
        }
     }
}