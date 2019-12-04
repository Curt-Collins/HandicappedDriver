using System;
using System.Web;
using System.Web.Services;
using HandicappedDriver.Bridge;
using HandicappedDriver.CoreSystem;

namespace HandicappedDriver
{
    public class Facade
    {
        private string username;
        JSONSerializer jSON = new JSONSerializer();
        Driver driver = new Driver();

        public Facade()
        {
        }

        [WebMethod]
        public void ForgotPassword(string username)
        {
            DriverData d = new DriverData();
            d = jSON.DeSerialize<DriverData>(username);
            driver = new Driver(d);
            driver.ResetPassword(d);
            
            // accepts username to create new password
        }

        [WebMethod]
        public void CreateDriver(string username)
        {
            // accepts username to create new driver
            DriverData d = new DriverData();
            d = jSON.DeSerialize<DriverData>(username);
            driver = new Driver(d);
            driver.ResetPassword(d);
            // d.create();
        }

        [WebMethod]
        public void Login(string info)
        {
            // utilize the given info to login to the Home Page
            // find the driver based on the correct username and password

            // string username, string password
            DriverData d = new DriverData();
            d = jSON.DeSerialize<DriverData>(info);

            // d.login();
        }

        [WebMethod]
        public void Logout(string username)
        {
            DriverData d = new DriverData();
            d = jSON.DeSerialize<DriverData>(username);
            // utilizes the username to log the user out of the system
        }

        [WebMethod]
        public void UpdateDriverProfile(string info)
        {
            // string name, string email, string mobile, string plateNum, string plateState

            // utilizes given information and pushes back into the database to update driver information
            DriverData d = new DriverData();
            d = jSON.DeSerialize<DriverData>(info);
            if(d.eMailAddress == "")
            {
                // tell them that they need to input something other than an empty string
            }
            // d.update();
            // this will be called to update the driver object's info
            driver = new Driver(d);
            driver.UpdateProfile(d);
        }

        [WebMethod]
        public void NavigateToSpace(int spaceID)
        {
            // this pulls up the Navigation system to navigate to the space that the user wants to go to
            ParkingSpaceData p = new ParkingSpaceData();
            p = jSON.DeSerialize<ParkingSpaceData>(spaceID.ToString());
        }

        [WebMethod]
        public void GetParkingLots()
        {
            // this shows the parking lots in the system in a dropdown in the GUI
            ParkingLotData p = new ParkingLotData();

            // p.show();  This will show the parking lots that are in the system
        }

        [WebMethod]
        public void GetCampusMap()
        {
            // this shows the campus map
            // called from the GUI and shows the graphic only
        }

        [WebMethod]
        public void SendMessageToDriver(string info)
        {
            // string fromUser, string toLicNum, string toLicState, string msg
            // this sends a message to a driver from a user to a certain user based on the license plate information
            info = "{something}{yes}{thank you}";
            string s1 = info;
            string s2 = info;
            string message = info;
            int j = 0;
            int k = 0;
            DriverData sendingDriver = new DriverData();
            DriverData receivingDriver = new DriverData();

            for(int i = 0; i < info.Length; i++)
            {
                if(info[i] == '}' && j == 0)
                {
                    s1 = info.Substring(0, i);
                    k = i;
                    j++;
                } else if(info[i] == '}' && j == 1)
                {
                    s2 = info.Substring(k, i);
                    k = i + 1;
                    j++;
                } else if(info[i] == '}' && j == 2)
                {
                    message = info.Substring(k, i);
                }
            }

            sendingDriver = jSON.DeSerialize<DriverData>(s1);
            receivingDriver = jSON.DeSerialize<DriverData>(s2);

            driver.SendMessage(sendingDriver, receivingDriver, message);

        }

        [WebMethod]
        public string ViewAvailableSpaces(int lotID)
        {
            // this shows the available spaces in a certain lot based on the lotID that is put in the method
            ParkingLotData p = new ParkingLotData();
            p = jSON.DeSerialize<ParkingLotData>(lotID.ToString());
			string spaces;
			// p.view();
			// 'spaceID' and 'lotID' is unavailable from "startTime" to "endTime".  Append this info to spaces.

			ParkingSpace p = new ParkingSpace();
			Reservation reservation = new Reservation();

            if(p.occupied == true)
			{
				spaces = "Space " + p.id + " in parking lot " + p.parkingLot.id + " is unavailable from " + reservation.startTime + " to " + reservation.endTime;
			}
			string spaces = p.view();

			return spaces;
        }

        [WebMethod]
        public void ShowExistingReservation(string username)
        {
            // this accesses the database to show any existing reservations that the user has made
            DriverData d = new DriverData();
            d = jSON.DeSerialize<DriverData>(username);
        }

        [WebMethod]
        public void OccupySpace(int resvID)
        {
            // this accesses the database and changes the status of the corresponding space in the database
            ReservationData r = new ReservationData();
            r = jSON.DeSerialize<ReservationData>(resvID.ToString());

            // r.occupy(); need this to be implemented
        }

        [WebMethod]
        public void LeaveSpace(int resvID)
        {
            // this changes the status of the space in the database to unoccupied
            ReservationData r = new ReservationData();
            r = jSON.DeSerialize<ReservationData>(resvID.ToString());

            // r.leave(); need this to be implemented
        }

        [WebMethod]
        public void CancelReservation(int resvID)
        {
            // this removes a reservation in the database from a certain spot and user
            ReservationData r = new ReservationData();
            r = jSON.DeSerialize<ReservationData>(resvID.ToString());

            // r.cancel(); need this to be implemented
        }
    }
}
