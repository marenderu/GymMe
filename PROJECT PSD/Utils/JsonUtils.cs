using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_PSD.Utils
{
    public class JsonUtils
    {
        // Encode
        public static string Encode(Object obj)
        {
            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        // Decode
        public static T Decode<T>(string json)
        {
            //return JsonConvert.DeserializeObject<T>(json);
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (JsonReaderException)
            {
                // Log the exception
                // Optionally return a default value or null
                return default(T);
            }
        }
    }
}