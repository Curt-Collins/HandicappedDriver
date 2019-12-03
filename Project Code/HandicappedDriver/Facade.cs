using System;
using System.Web;
namespace HandicappedDriver
{
    public class Facade
    {
        private string username;

        public Facade()
        {
        }

        // webmethod look it up so that it is visible from the webs
        private string serializeJSON(string p)
        {
            var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = jsonSerializer.Serialize(p);
            return json;

        }

        // need to implement this method
        private string deserializeJSON()
        {

        }

        public void ForgotPassword(string username)
        {
            // accepts username to create new password
            this.username = username;
        }

        public void CreateDriver(string username)
        {
            // accepts username to create new password
            this.username = username;

        }

        public void Login(string username, string password)
        {

        }

        public void Logout(string username)
        {

        }
        
        public void UpdateDriverProfile(string name, string email, string mobile, string plateNum, string plateState)
        {

        }
        
        public void NavigateToSpace(int spaceID)
        {

        }

        public void GetParkingLots()
        {

        }

        public void GetCampusMap()
        {

        }

        public void SendMessageToDriver(string fromUser, string toLicNum, string toLicState, string msg)
        {

        }

        public void ViewAvailableSpaces(int lotID)
        {

        }

        public void ShowExistingReservation(string username)
        {

        }

        public void OccupySpace(int resvID)
        {

        }

        public void LeaveSpace(int resvID)
        {

        }

        public void CancelReservation(int resvID)
        {

        }

    }
}
