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
        public void TestMethod1()
        {
            Facade.CreateDriver("ataylor64@uco.edu");
        }

        public void TestMethod2()
        {
            int uid;
            uid = Facade.Login_GetID("ataylor64@uco.edu", "1dda81");
            if (uid > 0)
            {
                DriverData d = Facade.GetDriverFull(uid);
                d.mobileNumber = "888-yaygirl";
                Facade.UpdateDriverProfile(d);
            }
        }
    }
}
