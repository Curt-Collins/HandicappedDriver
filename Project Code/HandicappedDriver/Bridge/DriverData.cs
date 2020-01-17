using System;
using System.Data;


namespace HandicappedDriver.Bridge
{
    public class DriverData : HandicappedDriverTableData
    {
        public int? Id { get; set; }
        public string fullName { get; set; }
        public string password { get; set; }
        public string mobileNumber { get; set; }
        public string licensePlateNum { get; set; }
        public string eMailAddress { get; set; }
        public string licensePlateState { get; set; }

        public DriverData() { }

        public DriverData(int? driverID)
        {
            this.Id = driverID;
            LoadDriver();
        }

        public void LoadDriver(string usr, string pwd = "")
        {
            string queryString;
            if (pwd == "")
            {
                queryString =
                    "SELECT ID FROM Driver WHERE EMailAddress=@eMailAddress";
            }
            else
            {
                queryString =
                    "SELECT ID FROM Driver WHERE EMailAddress=@eMailAddress AND Password=@password";
            }

            if (Connect())
            {
                command = this.connection.CreateCommand();
                command.Parameters.AddWithValue("@eMailAddress", usr);
                command.Parameters.AddWithValue("@password", pwd);
                command.CommandText = queryString;

                Id = (int?)command.ExecuteScalar();
                command.Dispose();
                if (Id != null)
                {
                    LoadDriver();
                }
            }
        }

        public void LoadDriver()
        {
            String queryString = "SELECT d.ID, d.FullName, d.LicensePlateNum, " +
                "d.MobileNumber, d.EMailAddress, d.Password, p.State FROM " +
                "Driver d LEFT OUTER JOIN LicensePlateState p ON " +
                "d.LicensePlateState_ID = p.ID WHERE d.ID=" + Id.ToString();

            if (Connect())
            {
                command = connection.CreateCommand();
                command.CommandText = queryString;
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    this.Id = reader.GetInt32(0);
                    this.fullName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    this.licensePlateNum = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    this.mobileNumber = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    this.eMailAddress = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    this.password = reader.IsDBNull(5) ? "" : reader.GetString(5);
                    this.licensePlateState = reader.IsDBNull(6) ? "" : reader.GetString(6);
                }

                reader.Close();
                this.connection.Close();
            }
        }

        // changing void to bool to check if update was successful
        public bool Update()
        {
            String queryString = "UPDATE [Driver] SET " +
                "[FullName]=@fullName, [LicensePlateNum]=@licensePlateNum, [MobileNumber]=@mobileNumber, " +
                "[EMailAddress]=@eMailAddress, [Password]=@password, [LicensePlateState_ID]=" +
                "(SELECT [ID] FROM LicensePlateState WHERE ([State]=@licensePlateState)) " +
                "WHERE ([ID]=@Id)";

            if (Connect())
            {
                command = this.connection.CreateCommand();
                command.Parameters.AddWithValue("@fullName", fullName);
                command.Parameters.AddWithValue("@licensePlateNum", licensePlateNum);
                command.Parameters.AddWithValue("@mobileNumber", mobileNumber);
                command.Parameters.AddWithValue("@eMailAddress", eMailAddress);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@licensePlateState", licensePlateState);
                command.Parameters.AddWithValue("@Id", Id);
                command.CommandText = queryString;

                command.ExecuteNonQuery();
                command.Dispose();
                this.connection.Close();

                // new code
                return true;
            }
            // new code
            else
            {
                return false;
            }
        }

        public int CreateNew(string usr, string pwd)
        {
            String queryString;

            if (Connect())
            {
                queryString =
                    "SELECT COUNT(*) FROM Driver WHERE EMailAddress=@eMailAddress";
                this.command = connection.CreateCommand();
                command.Parameters.AddWithValue("@eMailAddress", usr);
                command.CommandText = queryString;

                if ((int)command.ExecuteScalar() == 0)
                {
                    command.Dispose();

                    queryString =
                        "INSERT Driver (EMailAddress, Password, licensePlateState_ID, MobileNumber" +
                        ",LicensePlateNum, FullName) VALUES " +
                        "(@eMailAddress, @password, -1, SPACE(1), SPACE(1), SPACE(1))";

                    //queryString =
                    //    "INSERT Driver (EMailAddress, Password, licensePlateState_ID) VALUES " +
                    //    "(@eMailAddress, @password, -1)";

                    command = this.connection.CreateCommand();
                    command.Parameters.AddWithValue("@eMailAddress", usr);
                    command.Parameters.AddWithValue("@password", pwd);
                    command.CommandText = queryString;

                    command.ExecuteNonQuery();

                    queryString =
                        "SELECT Id FROM Driver WHERE EMailAddress=@eMailAddress";

                    command.CommandText = queryString;
                    this.Id = (int)command.ExecuteScalar();

                    LoadDriver();

                    return 0; //success
                }
                else
                {
                    return 1; //already exists
                }
            }
            else
            {
                return 2; //no connection
            }
        }

        public void SendMessage(string msg)
        {
            String queryString;

            if (Connect())
            {
                queryString =
                    "INSERT EMail_Message (Receiver_ID, Status_ID, SentTime, MessageText, Msg_Type) " +
                    "VALUES (@id, 1, @senttime, @msg, 'NEWPASSWORD')";

                command = this.connection.CreateCommand();
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@senttime", DateTime.Now);
                command.Parameters.AddWithValue("@msg", msg);
                command.CommandText = queryString;

                command.ExecuteNonQuery();
                command.Dispose();
                this.connection.Close();

            }
        }

    }

}
