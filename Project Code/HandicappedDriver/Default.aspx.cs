using System;
using System.Collections;
using System.Web.UI;
using HandicappedDriver.Bridge;


namespace HandicappedDriver
{


    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DriverData dd = new DriverData(1);

            dd.mobileNumber = "(888) 974-8201";

            dd.UpdateProfile();

            dd = new DriverData();

            dd.CreateNew("beevis@uco.edu", "passwird");

        }
    }
}