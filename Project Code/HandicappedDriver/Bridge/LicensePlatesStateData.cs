using System.Data.SqlClient;
using System.Collections.Generic;

namespace HandicappedDriver.Bridge
{
    public class State
    {
        public int id;
        public string name;
    }

    public class LicensePlatesStateData : HandicappedDriverTableData
    {
        public List<State> States;

        public LicensePlatesStateData()
        {
            string queryString = "SELECT id, State FROM LicensePlateState";
            State st;

            if (Connect())
            {
                States = new List<State>();

                command = connection.CreateCommand();
                command.CommandText = queryString;
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    st = new State();
                    st.id = reader.GetInt32(0);
                    st.name = reader.GetString(1);
                    States.Add(st);
                }
                command.Dispose();
                reader.Close();
                this.connection.Close();
            }
        }
    }
}