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
            ParkingLotData p = new ParkingLotData();
            s = js.Serialize<List<LotInfo>>(p.Lots);
            s = "";
        }
    }
}