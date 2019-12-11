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

            // An opinion:- if the user is new and does not exist in the database. Redirect them to create account. Pass in a parameter to denote that
            // it is a new user. If the parameter is true, do not go to the home page unless the information has been sucessfully saved. This way we 
            // don't have worry about disabling the buttons in other page.

            /*if(Facade.CreateDriver(user) == true)
            {
                Response.Redirect("createAccount.aspx");
            }
            else */if (result)
            {
                Response.Redirect("homePage.aspx");
            }

            //Response.Write(result);
            
        }
    }
}