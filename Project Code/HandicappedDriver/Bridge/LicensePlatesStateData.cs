﻿using System.Data.SqlClient;
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
            string queryString = "";
            State st;

            if (Connect())
            {
                States = new List<State>();

                SqlCommand cmd = Connection.CreateCommand();
                cmd.CommandText = queryString;
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    st = new State();
                    st.id = rdr.GetInt32(0);
                    st.name = rdr.GetString(1);
                    States.Add(st);
                }

                rdr.Close();
                this.Connection.Close();
            }
        }
    }
}