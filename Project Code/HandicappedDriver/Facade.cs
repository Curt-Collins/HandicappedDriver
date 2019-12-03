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

        public void ForgotPassword(string username)
        {
            // accepts username to create new password
        }

        public void CreateDriver(string username)
        {
            // accepts username to create new password
            this.username = username;

        }

        public void Login(string username, string password)
        {
            // utilize the given info to login to the Home Page
        }

        public void Logout(string username)
        {
            // utilizes the username to exit the program
        }
        
        public void UpdateDriverProfile(string name, string email, string mobile, string plateNum, string plateState)
        {
            // utilizes given information and pushes back into the database to update driver information
        }
        
        public void NavigateToSpace(int spaceID)
        {
            // this pulls up the Navigation system to navigate to the space that the user wants to go to
        }

        public void GetParkingLots()
        {
            // this shows the parking lot that the user is in
        }

        public void GetCampusMap()
        {
            // this shows the campus map
        }

        public void SendMessageToDriver(string fromUser, string toLicNum, string toLicState, string msg)
        {
            // this sends a message to a driver from a user to a certain user based on the license plate information
        }

        public void ViewAvailableSpaces(int lotID)
        {
            // this shows the available spaces in a certain lot based on the lotID that is put in the method
        }

        public void ShowExistingReservation(string username)
        {
            // this accesses the database to show any existing reservations that the user has made
        }

        public void OccupySpace(int resvID)
        {
            // this accesses the database and changes the status of the corresponding space in the database
        }

        public void LeaveSpace(int resvID)
        {
            // this changes the status of the space in the database to unoccupied
        }

        public void CancelReservation(int resvID)
        {
            // this removes a reservation in the database from a certain spot and user
        }

    }
}
