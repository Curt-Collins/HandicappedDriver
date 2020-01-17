using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HandicappedDriver.Bridge;
using HandicappedDriver.CoreSystem;
using System.Windows;



namespace HandicappedDriver
{
    
    public partial class useReservation : System.Web.UI.Page
    {
        string res_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Reading cookies
            HttpCookie resID = Request.Cookies["RES_ID"];
            res_id = resID != null ? resID.Value.Split('=')[1] : "undefined";

            HttpCookie u_id = Request.Cookies["USER_ID"];
            string userID = u_id != null ? u_id.Value.Split('=')[1] : "undefined";
            ReservationData rd = Facade.ShowExistingReservation(userID);
            lblUserReservation.Text = rd.locationDesc;
        }

        protected void btnNavigate_Click(object sender, EventArgs e)
        {

            HttpCookie u_id = Request.Cookies["USER_ID"];
            string userID = u_id != null ? u_id.Value.Split('=')[1] : "undefined";
            ReservationData rd = Facade.ShowExistingReservation(userID);

            int space_ID = rd.space_Id;

            //MessageBox.Show(""+space_ID);



            var url = Facade.NavigateToSpace(space_ID);

            Response.Redirect(url);
        }

        protected void btnOccupy_Click(object sender, EventArgs e)
        {
            int i = Int32.Parse(res_id);
            bool re = Facade.OccupySpace(i);
            if (re)
            {
                MessageBox.Show("Your status has been marked as true");
            }
        }

        protected void btnLeave_Click(object sender, EventArgs e)
        {
            int i = Int32.Parse(res_id);
            bool re = Facade.LeaveSpace(i);
            if (re)
            {
                MessageBox.Show("Your status has been marked as true");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int i = Int32.Parse(res_id);
            bool re = Facade.CancelReservation(i);
            if (re)
            {
                MessageBox.Show("Your status has been marked as true");
            }
        }
    }
}