using System;
using System.Text;
using System.Text.Json;

namespace HandicappedDriver
{
    public class JSONSerializer
    {
    
        public string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize<T>(obj);
        }

        public T DeSerialize<T>(String s)
        {
            return JsonSerializer.Deserialize<T>(s);
        }

    }
}