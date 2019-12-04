using System;
using System.Data;
using System.Data.OleDb;

namespace HandicappedDriver.Bridge
{
	public class DriverData : HandicappedDriverTableData
	{
		public int Id { get; set; }
		public string fullName { get; set; }
		public string password { get; set; }
		public string mobileNumber { get; set; }
		public string licensePlateNum { get; set; }
		public string eMailAddress { get; set; }
		public string licensePlateState { get; set; }

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
                "d.LicensePlateState_ID = p.ID";

            DataSet ds = new DataSet();

            if (Connect())
            {
                this.Adapter = new OleDbDataAdapter(queryString, this.Connection);
                Adapter.Fill(ds);
                DataTable driver = ds.Tables[0];

                if (driver.Rows.Count == 1)
                {
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
        {
            String queryString = "UPDATE Driver SET " +
                "FullName=@fullName, LicensePlateNum=@licensePlateNum, " +
                "MobileNumber=@mobileNumber, EMailAddress=@eMailAddress, " +
                "Password=@password, LicensePlateState_ID=" +
                "(SELECT ID FROM LicensePlateState WHERE State=@licensePlateState) " +
                "WHERE ID=@Id";

            if (Connect())
            {
                OleDbCommand cmd = this.Connection.CreateCommand();
                cmd.Parameters.Add(new OleDbParameter("@Id", Id));
                cmd.Parameters.Add(new OleDbParameter("@licensePlateNum", licensePlateNum));
                cmd.Parameters.Add(new OleDbParameter("@fullName", fullName));
                cmd.Parameters.Add(new OleDbParameter("@mobileNumber", mobileNumber));
                cmd.Parameters.Add(new OleDbParameter("@licensePlateState", licensePlateState));
                cmd.Parameters.Add(new OleDbParameter("@password", password));
                cmd.Parameters.Add(new OleDbParameter("@eMailAddress", eMailAddress));
                cmd.CommandText = queryString;

                cmd.ExecuteNonQuery();

                this.Connection.Close();
            }
        }
    }
}
