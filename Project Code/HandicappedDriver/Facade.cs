using System;
using System.Web;
using System.Collections.Generic;
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

        // GOOD
        [WebMethod]
        public void ForgotPassword(string username)
        {
            DriverData d = new DriverData();
            d = jSON.DeSerialize<DriverData>(username);
            driver = new Driver(d);
            driver.ResetPassword(d);
        }

        // GOOD
        [WebMethod]
        public void CreateDriver(string username)
        {
            // accepts username to create new driver
            DriverData d = new DriverData();
            d = jSON.DeSerialize<DriverData>(username);
            driver = new Driver(d);
            driver.ResetPassword(d);
        }

        // GOOD
        [WebMethod]
        public bool Login(string info)
        {
            bool login = false;
            DriverData d;
            d = jSON.DeSerialize<DriverData>(info);
            if(!(String.IsNullOrEmpty(d.eMailAddress)) && !(String.IsNullOrEmpty(d.password)))
            {
                d.LoadDriver(d.eMailAddress, d.password);
                if (!(d.Id is null))
                {
                    login = true;
                }
            }

            return login;
        }

        // TODO
        [WebMethod]
        public void Logout(string info)
        {
            bool logout = false;
            DriverData d;
            d = jSON.DeSerialize<DriverData>(info);
            // logout the driver from the system
            // can the GUI just go back to the login page?  Does this need to be implemented here?
        }

        // TODO
        [WebMethod]
        public void UpdateDriverProfile(string info)
        {
            // this changes what is inside the system, therefore it does not return anything to the GUI
            DriverData d = new DriverData();
            d = jSON.DeSerialize<DriverData>(info);
            driver = new Driver(d);
            driver.UpdateProfile(d);
        }


        // TODO
        [WebMethod]
        public string NavigateToSpace(string spaceID)
        {
            // this pulls up the Navigation system to navigate to the space that the user wants to go to
            ParkingSpaceData p = new ParkingSpaceData(spaceID);
            string s = "";
            p = jSON.DeSerialize<ParkingSpaceData>(spaceID);
            p.LoadInfo();

            //s = jSON.Serialize<ParkingSpaceData>(p.NavString);

            return s;
        }

        // GOOD
        [WebMethod]
        public string GetParkingLots()
        {
            string s = "";
            // this shows the parking lots in the system in a dropdown in the GUI
            ParkingLotData p = new ParkingLotData();
            s = jSON.Serialize<List<LotInfo>>(p.Lots);
            return s;
        }

        // TODO
        [WebMethod]
        public void SendMessageToDriver(string info)
        {
            // string fromUser, string toLicNum, string toLicState, string msg
            // this sends a message to a driver from a user to a certain user based on the license plate information
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

        // GOOD
        [WebMethod]
        public string ViewAvailableSpaces(string lotID)
        {
            // this shows the available spaces in a certain lot based on the lotID that is put in the method
			string spaces = "";
            ParkingSpaceData ps = new ParkingSpaceData();
            List<HandicappedDriver.Bridge.ParkingSpace> a = ps.LoadAvailableSpaces(lotID);
            spaces = jSON.Serialize<List<HandicappedDriver.Bridge.ParkingSpace>>(a);

            return spaces;
        }

        // GOOD
        [WebMethod]
        public string ShowExistingReservation(string username)
        {
            // this accesses the database to show any existing reservations that the user has made
            ReservationData r;
            string s = "";
            r = jSON.DeSerialize<ReservationData>(username);
            r.PullRes();
            r.resvID = "stuff";
            if (r.resvID != "")
            {
                s = jSON.Serialize<ReservationData>(r);
            }
            
            return s;
        }

        // TODO
        [WebMethod]
        public void OccupySpace(string resvID)
        {
            // this accesses the database and changes the status of the corresponding space in the database
            ReservationData r = new ReservationData();
            r = jSON.DeSerialize<ReservationData>(resvID.ToString());
            r.ParkInSpace(resvID);
            // r.occupied = true, meaning that the spot is now listed as 'occupied' in the database
        }

        // TODO
        [WebMethod]
        public void LeaveSpace(string resvID)
        {
            // this changes the status of the space in the database to unoccupied
            ReservationData r = new ReservationData();
            r = jSON.DeSerialize<ReservationData>(resvID.ToString());
            r.LeaveSpace(resvID);
            // r.occupied = false, meaning that the spot is now listed as 'unoccupied' in the database
        }

        // TODO
        [WebMethod]
        public void CancelReservation(string resvID)
        {
            // this removes a reservation according to the resvID passed to the database
            ReservationData r = new ReservationData();
            r = jSON.DeSerialize<ReservationData>(resvID.ToString());
        }
    }
}
