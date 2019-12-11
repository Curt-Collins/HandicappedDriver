using System;
using HandicappedDriver.Bridge;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandicappedDriver
{
    public partial class createAccount : System.Web.UI.Page
    {
        protected DriverData driver;

        protected void Page_Load(object sender, EventArgs e)
        {
            // figure out how to convert JSON string into a JSON object here to populate the dropdown list 
            //string stateObj = Facade.StatesTest();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Login
            string usr = txtUserName.Text;
            string pwd = txtPass.Text;

            //Data validation goes here

            int uid = Facade.Login_GetID(usr, pwd);
            if (uid > 0)
            {
                driver = Facade.GetDriverFull(uid);
            }

            //Now do whatever
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Forgot password
            string usr = txtUserName.Text;

            //Data validation goes here

            Facade.ForgotPassword(usr);
 
            //Now do whatever
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Data validation goes here

            if (driver.Id > 0)
            {
                driver.fullName = txtName.Text;
                driver.licensePlateNum = txtRegNumber.Text;
                driver.password = txtPass.Text;
                driver.mobileNumber = txtPhoneNumber.Text;
                driver.licensePlateState = drpRegState.SelectedValue;
                Facade.UpdateDriverProfile(driver);
            }

            //else - need to login first

            //Now do whatever
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