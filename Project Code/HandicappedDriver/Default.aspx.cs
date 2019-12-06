using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using HandicappedDriver.Bridge;


namespace HandicappedDriver
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JSONSerializer js = new JSONSerializer();
            string s;
            Facade f = new Facade();
            s = f.ViewAvailableSpaces(1);
            s = "";
        }
    }
}