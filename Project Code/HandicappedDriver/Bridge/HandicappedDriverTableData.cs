using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace HandicappedDriver.Bridge
{
    public abstract class HandicappedDriverTableData
    {
        //protected OleDbConnection connection = new OleDbConnection(
        //    new OleDbConnectionStringBuilder()
        //    {
        //        DataSource = "..\\App_Data\\HandicappedDriver.accdb",
        //        Provider = "Microsoft.ACE.OLEDB.12.0",
        //        PersistSecurityInfo = false
        //    }.ConnectionString
        //);

        //protected OleDbDataAdapter adapter { get; set; }
        //protected OleDbDataReader reader { get; set; }
        //protected OleDbCommand command { get; set; }

        protected SqlConnection connection = new SqlConnection(
            new SqlConnectionStringBuilder()
            {
                DataSource = "192.168.1.123",
                InitialCatalog = "HandicappedDriver",
                UserID = "Group1",
                Password = "Grp1Pass!"
            }.ConnectionString
        );

        protected SqlDataAdapter adapter { get; set; }
        protected SqlDataReader reader { get; set; }
        protected SqlCommand command { get; set; }

        protected Boolean Connect()
        {
            Boolean retval = true;
            if (!(connection.State == ConnectionState.Open))
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    retval = false;
                }
            }

            return retval;
        }

        public void Disconnect()
        {
            this.connection.Close();
        }

    }
}