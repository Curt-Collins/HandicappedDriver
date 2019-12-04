using System;
using System.Data;
using System.Data.OleDb;

namespace HandicappedDriver.Bridge
{
    public class DriverData: HandicappedDriverTableData
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string password { get; set; }
        public string mobileNumber { get; set; }
        public string licensePlateNum { get; set; }
        public string eMailAddress { get; set; }
        public string licensePlateState { get; set; }

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

            }
        }

        public DriverData() { }

        public DriverData(int driverID)
        {
            this.Id = driverID;
            LoadDriver();
        }


    }
}