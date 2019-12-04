using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace HandicappedDriver.Bridge
{
    public abstract class HandicappedDriverTableData
    {
        // Curt
        //        protected string strConn =
        //            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ccollins45\source\repos\HandicappedDriver\HandicappedDriver.accdb;Persist Security Info=False;";
        //Leif
       protected string strConn =
           @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ccollins45\source\repos\HandicappedDriver\HandicappedDriver.accdb;Persist Security Info=False;";

        protected OleDbConnection Connection { get; set; }
        protected OleDbDataAdapter Adapter { get; set; }
        protected OleDbDataReader Reader { get; set; }

        protected Boolean Connect()
        {
            Boolean retval;
            //            try
            //            {
            this.Connection = new OleDbConnection(strConn);
                Connection.Open();
                retval = true;
 //           }
 //          catch
 //           {
 //               retval = false;
 //           }

            return retval;
        }

        public void Disconnect()
        {
            this.Connection.Close();
        }

    }
}