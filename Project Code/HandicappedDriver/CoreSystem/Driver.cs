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
        Random rand = new Random();

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

        public string ResetPassword(DriverData driver)
        {
            string[] p = {"a", "b", "c", "d", "e", "f", "g", "!", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string password = "";
            for(int i = 0; i < 6; i++)
            {
                password = password + p[rand.Next(17)];
            }

            return password;
            // driver.UpdateProfile();  this will be implemented by Curt in the DriverData class
            //string message = "Thanks for choosing Handicapped Driver! Your password is " + password + ".  Please like us on Facebook!";
            // the two following lines of code will work once the MailAdapter class and send() method in that class are 

            //MailAdapter m = new MailAdapter();
            //m.send(driver, message);
        }

        public void ValidatePassword(string p)
        {

        }

        public void UpdateProfile(DriverData driver)
        {
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
