using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace PsJson
{
    [TypeConverter(typeof(JsonObjectConverter))]
    public class JsonObject
    {
        public JObject JObject { get; private set; }
        public object this[string key]
        {
            get
            {
                return JsonTypeAdapter.GetValue(JObject[key]);
            }
        }

        public JsonObject(JObject jobject)
        {
            JObject = jobject;
        }

        public override string ToString()
        {
            return JObject.ToString();
        }
    }
}
