using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HandicappedDriver;
using System.Web.Services;
using HandicappedDriver.Bridge;

namespace HandicappedDriver.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateDriver()
        {
            Facade.CreateDriver("ataylor64@uco.edu");
            Facade.CreateDriver("ataylor64-ga@uco.edu");
            Facade.CreateDriver("");
            Facade.CreateDriver("123");
        }

        [TestMethod]
        public void TestUpdateDriver()
        {
            int uid;
            uid = Facade.Login_GetID("ataylor64@uco.edu", "1dda81");
            if (uid > 0)
            {
                DriverData d = Facade.GetDriverFull(uid);
                d.mobileNumber = "888-yaygirl";
                d.password = "1dda81";
                d.licensePlateNum = "17-A856";
                d.licensePlateState = "Oklahoma";
                
                Facade.UpdateDriverProfile(d);

            }

        }

        [TestMethod]
        public void TestLogin()
        {
            int uid;
            uid = Facade.Login_GetID("ataylor64@uco.edu", "1dda81");
            if (uid > 0)
            {
                Facade.GetDriverFull(uid);
            }
        }

       [TestMethod]
        public void TestNavigateToParkingSpace()
        {
            Facade.NavigateToSpace(11);
            Facade.NavigateToSpace(20);
            //Facade.NavigateToSpace(999);
            //Facade.NavigateToSpace(300);

        }
    }
}
