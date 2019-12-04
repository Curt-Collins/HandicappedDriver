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
<<<<<<< HEAD
=======

            dd.mobileNumber = "(888) 974-8000";

            dd.Update();
>>>>>>> 2f86e39ba6e93c29d486d00e3ecac4ddb8c2485e
        }
    }
}