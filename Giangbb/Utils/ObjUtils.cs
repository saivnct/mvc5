using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Giangbb.Utils
{
    public class ObjUtils
    {

        public static string ObjToJsonString(Object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, new IsoDateTimeConverter()
            {
                DateTimeFormat = "dd/MM/yyy hh:mm:ss"
            });
        }
    }
}