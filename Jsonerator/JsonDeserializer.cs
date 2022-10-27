using System;
using Newtonsoft.Json.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsonerator
{
    internal static class JsonDeserializer
    {

        // Handle exception
        public static JObject FileToJObject(FileInfo jsonfile)
        {
            string jsonstring = File.ReadAllText(jsonfile.FullName);
            JObject o = JsonConvert.DeserializeObject<JObject>(jsonstring);
            return o;
        }

        public static JObject StringToJObject(string jsonstring)
        {
            JObject o = JsonConvert.DeserializeObject<JObject>(jsonstring);
            return o;
        }

    }
}
