using HandicappedDriver.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace HandicappedDriver
{
    public partial class viewAvailable : System.Web.UI.Page
    {
        int lot;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            List<LotInfo> lotInfos = Facade.GetParkingLots();
            int len = lotInfos.Count;
            for (int i = 0; i < len; i++)
            {
                drpLot.Items.Add(lotInfos[i].name.ToString());

            }

            lot = drpLot.SelectedIndex;
            lot++;

            int bullshit;
            ParkingSpaceData sd = new ParkingSpaceData();
            List<ParkingSpace> spot = sd.LoadAvailableSpaces(lot);  // returning ZERO content
            int len2 = spot.Count;
            for (int i = 0; i < len2; i++)
            {
                bullshit = spot[i].Space_Id;
                if ((spot.Exists(x => x.Space_Id == bullshit)))
                {
                    drpSpot.Items.Add(spot[i].Space_Id.ToString());

                }

            }
        }

        protected void btnCampusMap_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.uco.edu/files/maps/uco-parking-map.pdf");
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            DateTime startTime = Convert.ToDateTime(txtStartTime.Text);
            DateTime endTime = Convert.ToDateTime(txtEndTime.Text);
            int spot_ID = drpSpot.SelectedIndex;
            spot_ID++;

            // Reading cookies
            HttpCookie userName = Request.Cookies["USER_ID"];
            string uid = userName != null ? userName.Value.Split('=')[1] : "undefined";


            ReservationData rd = new ReservationData();
            int resId = rd.CreateNew(uid, spot_ID, startTime, endTime);

            MessageBox.Show("Your reservation has been sucessful. Reservation ID:" + resId);

            // write cookies
            HttpCookie res_ID_cookie = new HttpCookie("RES_ID");
            res_ID_cookie["RES_ID"] = ""+resId;
            res_ID_cookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(res_ID_cookie);


            Response.Redirect("homePage.aspx");
        }

        

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
                        
            ParkingSpaceData psd = new ParkingSpaceData();
            System.Data.DataTable spaceTable = psd.LoadReservations(lot);
            grdRes.DataSource = spaceTable;
            grdRes.DataBind();

            //MessageBox.Show();
            
        }

        protected void drpLot_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}