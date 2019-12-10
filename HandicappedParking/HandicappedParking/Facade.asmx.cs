using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Newtonsoft.Json;
using HandicappedDriver.Bridge;

namespace HandicappedParking
{
    /// <summary>
    /// Summary description for Facade
    /// </summary>
    [WebService(Namespace = "HandicappedParking")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Facade : System.Web.Services.WebService
    {

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public string HelloWorld()
        {
            return "Hello World";
        }

        // FROM THE ORIGINAL FACADE
        // GOOD
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void ForgotPassword(string username)
        {
            DriverData d = new DriverData();
            d = jSON.DeSerialize<DriverData>(username);
            driver = new Driver(d);
            string pass = driver.ResetPassword(d);
            string message = "Hello " + d.fullName + "!  Your password has been changed to " + pass + ".  You can change this password at any time on the " +
                "Update Profile page.  Thank you for choosing the Handicapped Parking System at UCO!";
            d.SendMessage(message);
        }

        // GOOD
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void CreateDriver(string username)
        {
            // accepts username to create new driver
            DriverData d = new DriverData();
            d = jSON.DeSerialize<DriverData>(username);
            driver = new Driver(d);
            string pass = driver.ResetPassword(d);
            d.CreateNew(username, pass);
            string message = "Welcome to the Handicapped Parking System at UCO!  Your username is " + username + " and your password is " + pass + ".  " +
                "You can change this password at any time on the Update Profile page.  Thank you for choosing the Handicapped Parking System!";
            d.SendMessage(message);
        }

        // GOOD
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static bool Login(string info)
        {
            bool login = false;
            DriverData d;
            d = jSON.DeSerialize<DriverData>(info);
            if (!(String.IsNullOrEmpty(d.eMailAddress)) && !(String.IsNullOrEmpty(d.password)))
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
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void Logout(string info)
        {
            bool logout = false;
            DriverData d;
            d = jSON.DeSerialize<DriverData>(info);
            // logout the driver from the system
            // can the GUI just go back to the login page?  Does this need to be implemented here?
        }

        // TODO
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void UpdateDriverProfile(string info)
        {
            // this changes what is inside the system, therefore it does not return anything to the GUI
            DriverData d = new DriverData();
            d = jSON.DeSerialize<DriverData>(info);
            driver = new Driver(d);
            driver.UpdateProfile(d);
        }

        // TODO
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static string NavigateToSpace(string spaceID)
        {
            // this pulls up the Navigation system to navigate to the space that the user wants to go to
            ParkingSpaceData p = new ParkingSpaceData();
            string s = "";
            p = jSON.DeSerialize<ParkingSpaceData>(spaceID);
            p.LoadInfo();

            //s = jSON.Serialize<ParkingSpaceData>(p.NavString);

            return s;
        }

        // GOOD
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static string GetParkingLots()
        {
            string s = "";
            // this shows the parking lots in the system in a dropdown in the GUI
            ParkingLotData p = new ParkingLotData();
            s = jSON.Serialize<List<LotInfo>>(p.Lots);
            return s;
        }

        // TODO but unimportant at this point
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void SendMessageToDriver(string info)
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

            for (int i = 0; i < info.Length; i++)
            {
                if (info[i] == '}' && j == 0)
                {
                    s1 = info.Substring(0, i);
                    k = i;
                    j++;
                }
                else if (info[i] == '}' && j == 1)
                {
                    s2 = info.Substring(k, i);
                    k = i + 1;
                    j++;
                }
                else if (info[i] == '}' && j == 2)
                {
                    message = info.Substring(k, i);
                }
            }

            sendingDriver = jSON.DeSerialize<DriverData>(s1);
            receivingDriver = jSON.DeSerialize<DriverData>(s2);

            driver.SendMessage(sendingDriver, receivingDriver, message);
        }

        // GOOD
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static string ViewAvailableSpaces(string lotID)
        {
            // this shows the available spaces in a certain lot based on the lotID that is put in the method
            string spaces = "";
            ParkingSpaceData ps = new ParkingSpaceData();
            List<HandicappedDriver.Bridge.ParkingSpace> a =
                ps.LoadAvailableSpaces(Int32.Parse(lotID));
            spaces = jSON.Serialize<List<HandicappedDriver.Bridge.ParkingSpace>>(a);

            return spaces;
        }

        // GOOD
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static string ShowExistingReservation(string username)
        {
            // this accesses the database to show any existing reservations that the user has made
            ReservationData r;
            string s = "";
            r = jSON.DeSerialize<ReservationData>(username);
            //r.PullRes();
            //r.resvID = "stuff";
            //if (r.resvID != "")
            //{
            //    s = jSON.Serialize<ReservationData>(r);
            //}

            return s;
        }

        // TODO
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void OccupySpace(string resvID)
        {
            // this accesses the database and changes the status of the corresponding space in the database
            ReservationData r = new ReservationData();
            r = jSON.DeSerialize<ReservationData>(resvID.ToString());
            r.ParkInSpace(resvID);
            // r.occupied = true, meaning that the spot is now listed as 'occupied' in the database
        }

        // TODO 
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void LeaveSpace(string resvID)
        {
            // this changes the status of the space in the database to unoccupied
            ReservationData r = new ReservationData();
            r = jSON.DeSerialize<ReservationData>(resvID.ToString());
            r.LeaveSpace(resvID);
            // r.occupied = false, meaning that the spot is now listed as 'unoccupied' in the database
        }

        // TODO
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void CancelReservation(string resvID)
        {
            // this removes a reservation according to the resvID passed to the database
            ReservationData r = new ReservationData();
            r = jSON.DeSerialize<ReservationData>(resvID);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static string StatesTest()
        {
            return
                "[" + "" +
                "{" + "name:" + "Alberta," + "abbreviation: AB" + "}," +
                "{" + "name:" + "British Columbia," + "abbreviation: BC" + "}," +
                "{" + "name:" + "Alberta," + "abbreviation: MN" + "}," +
                "]";
        }
    }
}
