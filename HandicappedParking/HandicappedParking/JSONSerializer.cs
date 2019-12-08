using System;
using System.Text;
using Newtonsoft.Json;

namespace HandicappedDriver
{
    public class JSONSerializer
    {
        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T DeSerialize<T>(String s)
        {
            return JsonConvert.DeserializeObject<T>(s);
        }

    }
}