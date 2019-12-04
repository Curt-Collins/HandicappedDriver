﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace HandicappedDriver.Bridge
{
<<<<<<< HEAD
    public class DriverData : HandicappedDriverTableData
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string password { get; set; }
        public string mobileNumber { get; set; }
        public string licensePlateNum { get; set; }
        public string eMailAddress { get; set; }
        public string licensePlateState { get; set; }
=======
	public class DriverData : HandicappedDriverTableData
	{
		public int Id { get; set; }
		public string fullName { get; set; }
		public string password { get; set; }
		public string mobileNumber { get; set; }
		public string licensePlateNum { get; set; }
		public string eMailAddress { get; set; }
		public string licensePlateState { get; set; }
>>>>>>> 28f4648d1b458e7c5b5561d7c49d29a3df57c82c

	//<<<<<<< HEAD
	protected void LoadDriver()
	{
		String queryString = "SELECT d.ID, d.FullName, d.LicensePlateNum, " +
			"d.MobileNumber, d.EMailAddress, d.Password p.State FROM " +
			"Driver d LEFT OUTER JOIN LicensePlateState ON " +
			"d.LicensePlateState_ID = p.ID";

		this.Adapter = new OleDbDataAdapter(queryString, this.Connection);
		DataTable driver = new DataTable();

		if (Connect())
		{
			Adapter.Fill(driver, "Driver");
		}
	}
//=======
        public DriverData() { }

        public DriverData(int driverID)
        {
            this.Id = driverID;
            LoadDriver();
        }

        public void LoadDriver()
        {
            String queryString = "SELECT d.ID, d.FullName, d.LicensePlateNum, " +
                "d.MobileNumber, d.EMailAddress, d.Password, p.State FROM " +
                "Driver d LEFT OUTER JOIN LicensePlateState p ON " +
                "d.LicensePlateState_ID = p.ID WHERE d.ID=" + Id.ToString();

            if (Connect())
            {
                SqlCommand cmd = Connection.CreateCommand();
                cmd.CommandText = queryString;
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
<<<<<<< HEAD
                    this.Id = rdr.GetInt32(0);
                    this.fullName = rdr.IsDBNull(1) ? "" : rdr.GetString(1);
                    this.licensePlateNum = rdr.IsDBNull(2) ? "" : rdr.GetString(2);
                    this.mobileNumber = rdr.IsDBNull(3) ? "" : rdr.GetString(3);
                    this.eMailAddress = rdr.IsDBNull(4) ? "" : rdr.GetString(4);
                    this.password = rdr.IsDBNull(5) ? "" : rdr.GetString(5);
                    this.licensePlateState = rdr.IsDBNull(6) ? "" : rdr.GetString(6);
                }

                rdr.Close();
                this.Connection.Close();
            }
        }

        public void UpdateProfile()
=======
                    this.Id = (int)driver.Rows[0]["ID"];
                    this.fullName = (string)driver.Rows[0]["FullName"];

                    this.fullName = (string)driver.Rows[0]["LicensePlateNum"];
                    this.fullName = (string)driver.Rows[0]["State"];
                    this.fullName = (string)driver.Rows[0]["MobileNumber"];
                    this.fullName = (string)driver.Rows[0]["EMailAddress"];
                    this.fullName = (string)driver.Rows[0]["Password"];
                }
				this.Connection.Close();
			}

		}
   
        public void Update()
>>>>>>> 28f4648d1b458e7c5b5561d7c49d29a3df57c82c
        {
            String queryString = "UPDATE [Driver] SET " +
                "[FullName]=fullName, [LicensePlateNum]=@licensePlateNum, [MobileNumber]=@mobileNumber, " +
                "[EMailAddress]=@eMailAddress, [Password]=@password, [LicensePlateState_ID]=" +
                "(SELECT [ID] FROM LicensePlateState WHERE ([State]=@licensePlateState)) " +
                "WHERE ([ID]=@Id)";

            if (Connect())
            {
                SqlCommand cmd = this.Connection.CreateCommand();
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@licensePlateNum", licensePlateNum);
                cmd.Parameters.AddWithValue("@mobileNumber", mobileNumber);
                cmd.Parameters.AddWithValue("@eMailAddress", eMailAddress);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@licensePlateState", licensePlateState);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandText = queryString;

                cmd.ExecuteNonQuery();

                this.Connection.Close();
            }
        }
<<<<<<< HEAD

        public void CreateNew(string usr, string pwd)
        {
            String queryString;
            SqlCommand cmd;

            if (Connect())
            {
                queryString =
                    "SELECT COUNT(*) FROM Driver WHERE EMailAddress=@eMailAddress";
                cmd = this.Connection.CreateCommand();
                cmd.Parameters.AddWithValue("@eMailAddress", usr);
                cmd.CommandText = queryString;

                if ((int)cmd.ExecuteScalar() == 0)
                {
                    cmd.Dispose();

                    queryString =
                        "INSERT Driver (EMailAddress, Password, licensePlateState_ID) VALUES " +
                        "(@eMailAddress, @password, -1)";

                    cmd = this.Connection.CreateCommand();
                    cmd.Parameters.AddWithValue("@eMailAddress", usr);
                    cmd.Parameters.AddWithValue("@password", pwd);
                    cmd.CommandText = queryString;

                    cmd.ExecuteNonQuery();

                    queryString =
                        "SELECT Id FROM Driver WHERE EMailAddress=@eMailAddress";

                    cmd.CommandText = queryString;
                    this.Id = (int)cmd.ExecuteScalar();

                    LoadDriver();
                }
            }
        }
=======
>>>>>>> 28f4648d1b458e7c5b5561d7c49d29a3df57c82c
    }
}
