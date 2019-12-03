using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HandicappedDriver
{
    public class TestDataClass
    {
        public String fld1 = "Something String 1";
        public int fld2 = 12;
    }


    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HandicappedDriver.JSONSerializer js = new HandicappedDriver.JSONSerializer();

            TestDataClass t = new TestDataClass();

            var res = js.Serialize(t);

            //String testString =
            //    "{\"results\": [ { \"Enabled\": true, \"Id\": 106, \"Name\": \"item 1\", }, " +
            //    "{ \"Enabled\": false, \"Id\": 107, \"Name\": \"item 2\", \"__metadata\": { \"Id\": 4013 } " +
            //    "} ] }";

            //object dt = js.DeSerialize(testString);

            int i = 0;

        }
    }
}