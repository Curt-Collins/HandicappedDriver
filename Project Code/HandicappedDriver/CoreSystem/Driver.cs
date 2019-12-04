using System;
using System.Web.Services;
using HandicappedDriver.Bridge;

namespace HandicappedDriver.CoreSystem
{
    public class Driver
    {
        private int id;
        private string name;
        private string password;
        private string mobileNum;
        private string plateNum;
        private string plateState;
        private string username;

        public Driver()
        {

        }

        public Driver(string u)
        {
            username = u;
        }


        public Driver(int id)
        {
            this.id = id;
        }

        public Driver(DriverData d)
        {

        }

        public void GetProfile()
        {

        }

        public void ResetPassword(DriverData driver)
        {
            string password = "";
            driver.password = password;
            // driver.UpdateProfile();  this will be implemented by Curt in the DriverData class
            string message = "Thanks for choosing Handicapped Driver!" + password + "please like us on Facebook.";
            // the two following lines of code will work once the MailAdapter class and send() method in that class are 
            // MailAdapter m = new MailAdapter();
            // m.send(driver, message);
        }

        public void ValidatePassword(string p)
        {

        }

        public void UpdateProfile(string name, string email, string mobile, string plateNum, string plateState)
        {
            this.name = name;
            username = email;
            mobileNum = mobile;
            this.plateNum = plateNum;
            this.plateState = plateState;
        }

        private void LoadInfo()
        {

        }

        private void SaveInfo()
        {

        }

        public void SendMessage(DriverData d1, DriverData d2, string message)
        {
            // this will send info to d2 about d1 along with the message from d1
        }

    }
}
