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

            dd.mobileNumber = "(888) 974-8201";

            dd.UpdateProfile();

            dd = new DriverData();

            dd.CreateNew("beevis@uco.edu", "passwird");

<<<<<<< HEAD
=======
            dd.Update();
>>>>>>> 2f86e39ba6e93c29d486d00e3ecac4ddb8c2485e
>>>>>>> 28f4648d1b458e7c5b5561d7c49d29a3df57c82c
        }
    }
}