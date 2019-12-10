using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


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

            user += "@uco.edu";

            string info = "[{" +
                "\"EMailAddress\":" + user + "," +
                "\"Password\":" + pass +
            "}]";


            bool result = Facade.Login(info);
            Response.Write(result);
            
        }
    }
}