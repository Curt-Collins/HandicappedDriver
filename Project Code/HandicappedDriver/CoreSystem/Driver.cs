using System;
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

        public Driver(string u)
        {
            username = u;
        }

        public Driver(int id)
        {
            this.id = id;
        }

        public void GetProfile()
        {

        }

        public void ResetPassword()
        {

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
    }
}
