using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandicappedDriver
{
    public partial class createAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // figure out how to convert JSON string into a JSON object here to populate the dropdown list 
            //string stateObj = Facade.StatesTest();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ///
            /// CHECK WITH OTHERS ON HOW TO DISABLE BUTTONS ON HOME PAGE FOR NEW USERS
            /// 

            //((Button)Page.Master.FindControl("btnViewAvailable")).Enabled = true;
            
            
            //var previousPageMaster = PreviousPage.Master;
            //var mainContentPlaceHolder = previousPageMaster.FindControl("maincontent");
            //var btnViewAvail = (Button)mainContentPlaceHolder.FindControl("btnViewAvailable");
            //btnViewAvail.Enabled = true;



            string fullName = txtName.Text;
            string username = txtUserName.Text;
            string phone = txtPhoneNumber.Text;
            string regState = "5";//drpRegState.SelectedValue;
            int stateID = int.Parse(regState);
            string regNum = txtRegNumber.Text;
            string pass = txtPass.Text;

            string info = "[{"+
                "\"LicensePlateState_ID\":" + stateID + "," +
                "\"EMail\":" + username + "," +
                "\"Password\":" + pass + "," +
                "\"MobileNum\":" + phone + "," +
                "\"LicensePlate\":" + regNum + "," +
                "\"Name\":" + fullName 
                + "}]";
            //Response.Write(info);
            Facade.UpdateDriverProfile(new Bridge.DriverData());
            Response.Redirect("homePage.aspx");
        }
    }
}