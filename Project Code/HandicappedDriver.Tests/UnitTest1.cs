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
        public void TestMethod1()
        {
            Facade.CreateDriver("ataylor64@uco.edu");
        }
    }
}
