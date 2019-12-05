using System.Data.SqlClient;
using System.Collections;

namespace HandicappedDriver.Bridge
{
    public class State
    {
        public int id;
        public string name;
    }

    public class LicensePlatesStateData : HandicappedDriverTableData
    {
        public ArrayList<State> States;

        public LicensePlatesStateData()
        {
            string queryString = "";
            State st;

            if (Connect())
            {
                States = new ArrayList<State>();

                SqlCommand cmd = Connection.CreateCommand();
                cmd.CommandText = queryString;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    st = new State();
                    st.id = rdr.GetInt32(0);
                    st.name = rdr.GetString(1);

                }

                rdr.Close();
                this.Connection.Close();
            }
        }

        public class ArrayList<T>
        {
        }
    }
}