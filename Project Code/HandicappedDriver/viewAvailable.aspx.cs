using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandicappedDriver
{
    public partial class viewAvailable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string s = Facade.GetParkingLots();
            //Response.Write(s);
        }

        protected void btnCampusMap_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.uco.edu/files/maps/uco-parking-map.pdf");
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            Response.Redirect("useReservation.aspx");
        }
    }
}