using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace HandicappedDriver.Bridge
{
    public class ReservationData : HandicappedDriverTableData
    {
        public int? Id;
        //public int? driver_ID;
        public string eMailAddress;
        public string locationDesc;
        public string statusDesc;
        public bool occupied;
        public string navigation;

        public ReservationData() { }

        public ReservationData(int resID)
        {
            Id = resID;
            LoadReservation();
        }

        public ReservationData(string usr)
        {
            EMailAddress = usr;
            LoadReservation();
        }

        public void LoadReservation()
        {
            String queryString = "";

            if (Id != null)
            {
                queryString = "SELECT ID, S FROM SpaceReservation WHERE ID=" + Id.ToString();
            }
            else if (!(string.IsNullOrEmpty(eMailAddress)))
            {
                    queryString = "SELECT * FROM SpaceReservation WHERE EMailAddress" + eMailAddress;
            }
            
            if (Connect())
                {
                    SqlCommand cmd = Connection.CreateCommand();
                    cmd.CommandText = queryString;
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
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

        public void Update()
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

        private string resvID = "";

        private void SetID(string r)
        {
            resvID = r;
        }

        public string GetID()
        {
            return resvID;
        }

        public void PullRes()
        {

        }

    }
}