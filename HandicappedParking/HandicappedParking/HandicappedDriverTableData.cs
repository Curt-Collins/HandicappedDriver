﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

// changed HandicappedDriver to HandicappedParking
namespace HandicappedParking.Bridge
{
    public abstract class HandicappedDriverTableData
    {

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