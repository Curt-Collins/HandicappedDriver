using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HandicappedDriver;
using System.Web.Services;

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

        public void TestUpdateDriver()
        {
            

        }
    }
}
