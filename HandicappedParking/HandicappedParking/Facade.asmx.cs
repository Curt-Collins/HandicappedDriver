using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Newtonsoft.Json;

namespace HandicappedParking
{
    /// <summary>
    /// Summary description for Facade
    /// </summary>
    [WebService(Namespace = "HandicappedParking")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Facade : System.Web.Services.WebService
    {

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public string HelloWorld()
        {
            return "[{\"msg\" : \"Hello World\"}]";

        }

        [WebMethod]
        public static string StatesTest()
        {
            return
                "[" + "" +
                "{" + "name:" + "Alberta," + "abbreviation: AB" + "}," +
                "{" + "name:" + "British Columbia," + "abbreviation: BC" + "}," +
                "{" + "name:" + "Alberta," + "abbreviation: MN" + "}," +
                "]";
        }
    }
}
