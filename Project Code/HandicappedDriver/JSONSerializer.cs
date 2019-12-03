using System;
using System.Data;
//using ChoETL;
//using Newtonsoft.Json;
using System.Text;

namespace HandicappedDriver
{

 
    public class JSONSerializer
    {

        public string Serialize(object obj)
        {
            return 
            //return JsonConvert.SerializeObject(obj);
        }

        public object DeSerialize(String s)
        {
            return JsonConvert.DeserializeObject(s);
            // return JsonConvert.DeserializeObject<DataTable>(s);
        }

    }
}