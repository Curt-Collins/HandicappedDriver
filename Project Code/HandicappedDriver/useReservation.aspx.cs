using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandicappedDriver
{
    public partial class useReservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNavigate_Click(object sender, EventArgs e)
        {

            // change space_ID to actual space id value from database.
            int space_ID = 2;
            var url = Facade.NavigateToSpace(space_ID);

            Response.Redirect(url);
            //Response.Write(String.Format("window.open('{0}','_blank')", ResolveUrl("https://www.facebook.com")));
        }

        protected void btnOccupy_Click(object sender, EventArgs e)
        {

        }
    }
}