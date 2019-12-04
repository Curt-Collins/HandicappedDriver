using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HandicappedDriver.Bridge
{
    public abstract class HandicappedDriverTableData
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
        protected string strConn =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\richu\OneDrive\Documents\GitHub\HandicappedDriver\HandicappedDriver.accdb;Persist Security Info=False;";
        // C:\Users\richu\OneDrive\Documents\GitHub\HandicappedDriver
=======
        // Curt
        //        protected string strConn =
        //            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ccollins45\source\repos\HandicappedDriver\HandicappedDriver.accdb;Persist Security Info=False;";
        //Leif
       protected string strConn =
           @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ccollins45\source\repos\HandicappedDriver\HandicappedDriver.accdb;Persist Security Info=False;";
>>>>>>> 2f86e39ba6e93c29d486d00e3ecac4ddb8c2485e
>>>>>>> 28f4648d1b458e7c5b5561d7c49d29a3df57c82c

        SqlConnection conn = new SqlConnection(
            new SqlConnectionStringBuilder()
            {
                DataSource = "192.168.1.123",
                InitialCatalog = "HandicappedDriver",
                UserID = "Group1",
                Password = "Grp1Pass!"
            }.ConnectionString
        );

        protected SqlConnection Connection = new SqlConnection();
        protected SqlDataAdapter Adapter { get; set; }
        protected SqlDataReader Reader { get; set; }


        //protected string strConn =
        //   @"Provider=SQLNCLI11;Server=(local);Database=HandicappedDriver;Uid=Group1;Pwd=password;";


        protected Boolean Connect()
        {
            Boolean retval = true;
            if (!(Connection.State == ConnectionState.Open))
            {
                try
                {
                    this.Connection = conn;
                    Connection.Open();
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
            this.Connection.Close();
        }

    }
}