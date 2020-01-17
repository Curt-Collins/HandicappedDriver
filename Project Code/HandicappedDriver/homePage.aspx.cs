using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandicappedDriver
{
    public partial class homePage : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //btnViewAvailable.Enabled = false;
        }

        

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("createAccount.aspx");
        }

        protected void btnViewAvailable_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewAvailable.aspx");
        }

        protected void btnUseReservation_Click(object sender, EventArgs e)
        {
            Response.Redirect("useReservation.aspx");
        }

        protected void btnMessageDriver_Click(object sender, EventArgs e)
        {
            Response.Redirect("messageDriver.aspx");
        }
    }
}