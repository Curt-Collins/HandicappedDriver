using HandicappedDriver.Bridge;
using HandicappedDriver.CoreSystem;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Services;
using System.Windows;

namespace HandicappedDriver
{
    [WebService(Namespace = "HandicappedParking")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Facade : System.Web.Services.WebService
    {
        //static JSONSerializer jSON = new JSONSerializer();
        static Driver driver = new Driver();

        public Facade()
        {
        }

        // GOOD
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static bool ForgotPassword(string username)
        {
            DriverData d = new DriverData();
            d.LoadDriver(username);
            driver = new Driver();
            //Driver class only calculates the new password, does not commit
            string pass = driver.ResetPassword(d);
            //DriverData will commit
            d.Update();
            string message = "Hello " + d.fullName + "!  Your password has been changed to " + pass + ".  You can change this password at any time on the " +
                "Update Profile page.  Thank you for choosing the Handicapped Parking System at UCO!";
            d.SendMessage(message);
            return true;
        }

        // Good
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static bool CreateDriver(string username)
        {
            // accepts username to create new driver
            DriverData d = new DriverData();
            driver = new Driver(username);
            //Driver class only calculates the new password, does not commit
            string pass = driver.ResetPassword(d);
            if (d.CreateNew(username, pass) == 0)
            {
                string message = "Welcome to the Handicapped Parking System at UCO!  Your username is " + username + " and your password is " + pass + ".  " +
                    "You can change this password at any time on the Update Profile page.  Thank you for choosing the Handicapped Parking System!";
                d.SendMessage(message);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Good
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static bool Login(string u, string p)
        {
            //MessageBox.Show("u=" + u + " " + "p=" + p);

            bool login = false;
            DriverData d = new DriverData();

            d.LoadDriver(u, p);

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

        // Good
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static int Login_GetID(string u, string p)
        {
            int driverID = -1;
            DriverData d = new DriverData();
            d.LoadDriver(u, p);

            if (!(String.IsNullOrEmpty(d.eMailAddress)) && !(String.IsNullOrEmpty(d.password)))
            {
                d.LoadDriver(d.eMailAddress, d.password);
                if (!(d.Id is null))
                {
                    driverID = (int)d.Id;
                }
            }
            return driverID;
        }

        // Good
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void Logout(string info)
        {
            // logout the driver from the system
            // can the GUI just go back to the login page?  Does this need to be implemented here?
        }

        // Good
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static bool UpdateDriverProfile(DriverData d)
        {
            d.Update();
            return true;
        }

        // Good
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static string NavigateToSpace(int spaceID)
        {
            // this pulls up the Navigation system to navigate to the space that the user wants to go to
            ParkingSpaceData p = new ParkingSpaceData();
            Bridge.ParkingSpace ps = p.LoadInfo(spaceID);

            return ps.NavigationString;
        }

        // Good
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<LotInfo> GetParkingLots()
        {
            // this shows the parking lots in the system in a dropdown in the GUI
            ParkingLotData pl = new ParkingLotData();
            return pl.Lots;
        }

        // Good
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<State> GetStates()
        {
            // this shows the parking lots in the system in a dropdown in the GUI
            LicensePlatesStateData st = new LicensePlatesStateData();
            return st.States;
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

            //sendingDriver = jSON.DeSerialize<DriverData>(s1);
            //receivingDriver = jSON.DeSerialize<DriverData>(s2);

            driver.SendMessage(sendingDriver, receivingDriver, message);
        }

        // Good
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<Bridge.ParkingSpace> ViewAvailableSpaces(string lotID)
        {
            // this shows the available spaces in a certain lot 
            // based on the lotID that is put in the method
            ParkingSpaceData ps = new ParkingSpaceData();
            List<Bridge.ParkingSpace> ps_list =
                ps.LoadAvailableSpaces(Int32.Parse(lotID));

            return ps_list;
        }

        // Good
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static ReservationData ShowExistingReservation(int uid)
        {
            // this accesses the database to show any existing reservations that the user has made
            ReservationData r = new ReservationData();

            return r;
        }

        // TODO
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void OccupySpace(string resvID)
        {
            // this accesses the database and changes the status of the corresponding space in the database
            ReservationData r = new ReservationData();
            //r = jSON.DeSerialize<ReservationData>(resvID.ToString());
            r.ParkInSpace(resvID);
            // r.occupied = true, meaning that the spot is now listed as 'occupied' in the database
        }

        // TODO 
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void LeaveSpace(string resvID)
        {
            // this changes the status of the space in the database to unoccupied
            ReservationData r = new ReservationData();
            //r = jSON.DeSerialize<ReservationData>(resvID.ToString());
            r.LeaveSpace(resvID);
            // r.occupied = false, meaning that the spot is now listed as 'unoccupied' in the database
        }

        // TODO
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void CancelReservation(string resvID)
        {
            // this removes a reservation according to the resvID passed to the database
            ReservationData r = new ReservationData();
            //r = jSON.DeSerialize<ReservationData>(resvID);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static DriverData GetDriverFull(int uid)
        {
            return new DriverData(uid);
        }

    }
}
