using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HandicappedDriver.Bridge;

namespace HandicappedDriver
{
    public partial class ShowAvailableSpaces : System.Web.UI.Page
    {
        private List<ParkingSpace> ps;

        protected void Page_Load(object sender, EventArgs e)
        {
            int parkingLot = 1;
            ps = Facade.ViewAvailableSpaces(parkingLot);

        }

        protected override void OnInit(EventArgs e)
        {
        }

    }
}