using System;
//using ChoETL;
//using Newtonsoft.Json;

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