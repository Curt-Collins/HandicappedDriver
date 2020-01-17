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
    public partial class loginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            Facade f = new Facade();
            

            // check if the username contains '@uco.edu'
            bool isFound = user.Contains("@uco.edu");

            if (!isFound)
            {
                user += "@uco.edu";
            }
            

            bool result = Facade.Login(user,pass);
            MessageBox.Show(result +"");

            // An opinion:- if the user is new and does not exist in the database. Redirect them to create account. Pass in a parameter to denote that
            // it is a new user. If the parameter is true, do not go to the home page unless the information has been sucessfully saved. This way we 
            // don't have worry about disabling the buttons in other page.

            if (Facade.CreateDriver(user) == true)
            {
                Response.Redirect("createAccount.aspx");
            }
            else if (result)
            {
                int uid = Facade.Login_GetID(user, pass);
                if (uid > 0)
                {
                    // if the user is legit go to home page

                    DriverData driver = Facade.GetDriverFull(uid);
                    int usrid_pg = (int)driver.Id;
                    // assuming userid_pg is the user id, go to home page

                    // write cookies
                    HttpCookie user_ID_cookie = new HttpCookie("USER_ID");
                    user_ID_cookie["USER_ID"] = user;
                    user_ID_cookie.Expires = DateTime.Now.AddHours(2);
                    Response.Cookies.Add(user_ID_cookie);

                    Response.Redirect("homePage.aspx");
                }
            }
            else
            {
                string msg = "Your profile does not match in our existing database. Please update your profile befor you can continue.";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(msg);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                Response.Redirect("createAccount.aspx");
            }
        }
    }
}