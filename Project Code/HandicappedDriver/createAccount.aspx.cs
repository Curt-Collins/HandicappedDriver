using System;
using HandicappedDriver.Bridge;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace HandicappedDriver
{
    public partial class createAccount : System.Web.UI.Page
    {
        protected DriverData driver;
        protected int usrid_pg = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            List<State> states = Facade.GetStates();
            int len = states.Count;
            //this.drpRegState.DataSource = states;
            for(int i = 0; i < len; i++)
            {
                drpRegState.Items.Add(states[i].name.ToString());
                
            }
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            

            //string fullName = txtName.Text;
            string username = txtUserName.Text;
            string phone = txtPhoneNumber.Text;
            string stateID = drpRegState.SelectedValue;
            string regNum = txtRegNumber.Text;
            string pass = txtPass.Text;
            //MessageBox.Show(stateID + "  " + regNum);

            bool isFound = username.Contains("@uco.edu");

            if (!isFound)
            {
                username += "@uco.edu";
            }

            /*string info = "[{"+
                "\"LicensePlateState_ID\":" + stateID + "," +
                "\"EMail\":" + username + "," +
                "\"Password\":" + pass + "," +
                "\"MobileNum\":" + phone + "," +
                "\"LicensePlate\":" + regNum + "," +
                 //"\"Name\":" + fullName +
                 "}]";*/

            //Response.Write(info);

            Bridge.DriverData dd = new DriverData();
            dd.fullName = txtUserName.Text;
            dd.mobileNumber = txtPhoneNumber.Text;
            dd.password = txtPass.Text;
            dd.licensePlateNum = regNum;
            dd.licensePlateState = stateID;
            //dd.licensePlateNum = "";
            //dd.licensePlateState = "Oklahoma";
            dd.eMailAddress = txtUserName.Text;
            dd.Id = Facade.Login_GetID(dd.fullName, dd.password);

            // returning boolean to check is update successful
            bool r = Facade.UpdateDriverProfile(dd);
            if (r)
            {
                Response.Redirect("loginPage.aspx");
            }
            else
            {
                string msg = "Something went wrong. Please try again.";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(msg);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            
        }

        /*protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Login
            string usr = txtUserName.Text;
            string pwd = txtPass.Text;

            //Data validation goes here

            int uid = Facade.Login_GetID(usr, pwd);
            if (uid > 0)
            {
                driver = Facade.GetDriverFull(uid);
                usrid_pg = (int)driver.Id;

                // assuming userid_pg is the user id, go to home page

                // write cookies
                //HttpCookie user_ID_cookie = new HttpCookie("USER_ID");
                //user_ID_cookie["USER_ID"] = usr;
                //user_ID_cookie.Expires = DateTime.Now.AddHours(2);
                //Response.Cookies.Add(user_ID_cookie);

                Response.Redirect("homePage.aspx");

                
            }

            //Now do whatever
        }*/

        /*protected void btnForgotPass_Click(object sender, EventArgs e)
        {
            // Forgot password
            string usr = txtUserName.Text;

            //Data validation goes here

            Facade.ForgotPassword(usr);

            //Now do whatever
            txtUserName.Text = usr;
            txtUserName.ReadOnly = true;
            btnSubmit_Click(sender, e);

        }*/

        /*protected void btnCreate_Click(object sender, EventArgs e)
        {
            //Data validation goes here

            if (usrid_pg > 0)
            {
                //driver.fullName = txtName.Text;
                driver.licensePlateNum = txtRegNumber.Text;
                driver.password = txtPass.Text;
                driver.mobileNumber = txtPhoneNumber.Text;
                driver.licensePlateState = drpRegState.SelectedValue;
                Facade.UpdateDriverProfile(driver);
                string msg = "Your profile has been sucessfully created. Please start from login page.";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(msg);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                Response.Redirect("loginPage.aspx");
            }
            else
            {
                string msg = "You already have an existing profile. Please login with your credentials.";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(msg);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                Response.Redirect("loginPage.aspx");
            }

            //else - need to login first

            //Now do whatever
        }*/
    }
}