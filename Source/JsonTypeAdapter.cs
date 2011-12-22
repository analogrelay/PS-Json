using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace PsJson
{
    public class JsonTypeAdapter : PSPropertyAdapter
    {
        public override Collection<PSAdaptedProperty> GetProperties(object baseObject)
        {
            JsonObject jobj = baseObject as JsonObject;
            JObject obj = jobj.JObject;
            if (obj == null)
            {
                return new Collection<PSAdaptedProperty>();
            }
            return new Collection<PSAdaptedProperty>(
                obj.Properties().Select(p => new PSAdaptedProperty(p.Name, p)).ToList());
        }

        public override PSAdaptedProperty GetProperty(object baseObject, string propertyName)
        {
            JsonObject jobj = baseObject as JsonObject;
            JObject obj = jobj.JObject;
            if (obj == null)
            {
                return null;
            }
            JProperty prop = obj.Property(propertyName);
            if (prop == null)
            {
                return null;
            }
            return new PSAdaptedProperty(prop.Name, prop);
        }

        public override string GetPropertyTypeName(PSAdaptedProperty adaptedProperty)
        {
            return RunOnJProp<string>(adaptedProperty, GetTypeName);
        }

        public override object GetPropertyValue(PSAdaptedProperty adaptedProperty)
        {
            return RunOnJProp<object>(adaptedProperty, GetValue);
        }

        public override bool IsGettable(PSAdaptedProperty adaptedProperty)
        {
            return adaptedProperty.Tag is JProperty;
        }

        public override bool IsSettable(PSAdaptedProperty adaptedProperty)
        {
            return adaptedProperty.Tag is JProperty;
        }

        public override void SetPropertyValue(PSAdaptedProperty adaptedProperty, object value)
        {
            RunOnJProp(adaptedProperty, p => SetValue(p, value));
        }

        private void RunOnJProp(PSAdaptedProperty adaptedProperty, Action<JProperty> action) {
            JProperty prop = adaptedProperty.Tag as JProperty;
            if (prop != null) {
                action(prop);
            }   
        }

        private T RunOnJProp<T>(PSAdaptedProperty adaptedProperty, Func<JProperty, T> action)
        {
            JProperty prop = adaptedProperty.Tag as JProperty;
            if (prop == null)
            {
                return default(T);
            }
            return action(prop);
        }

        private void SetValue(JProperty prop, object value) {
            prop.Value = JValue.FromObject(value);
        }

        private object GetValue(JProperty prop)
        {
            return GetValue(prop.Value);
        }

        internal static object GetValue(JToken val) {
            switch (val.Type)
            {
                case JTokenType.Array:
                    return ((JArray)val).Values().Select(GetValue).ToArray();
                case JTokenType.Boolean:
                    return val.Value<bool>();
                case JTokenType.Bytes:
                    return val.Value<byte[]>();
                case JTokenType.Date:
                    return val.Value<DateTime>();
                case JTokenType.Float:
                    return val.Value<float>();
                case JTokenType.Guid:
                    return val.Value<Guid>();
                case JTokenType.Integer:
                    return val.Value<long>();
                case JTokenType.Object:
                    JObject obj = ((JObject)val);
                    return new JsonObject(obj);
                case JTokenType.String:
                    return val.Value<string>();
                case JTokenType.TimeSpan:
                    return val.Value<TimeSpan>();
                case JTokenType.Uri:
                    return val.Value<Uri>();
                default:
                    return null;
            }
        }

        private string GetTypeName(JProperty prop)
        {
            switch (prop.Value.Type)
            {
                case JTokenType.Array:
                    return typeof(object[]).FullName;
                case JTokenType.Boolean:
                    return typeof(bool).FullName;
                case JTokenType.Bytes:
                    return typeof(byte[]).FullName;
                case JTokenType.Date:
                    return typeof(DateTime).FullName;
                case JTokenType.Float:
                    return typeof(float).FullName;
                case JTokenType.Guid:
                    return typeof(Guid).FullName;
                case JTokenType.Integer:
                    return typeof(long).FullName;
                case JTokenType.Object:
                    return typeof(JsonObject).FullName;
                case JTokenType.String:
                    return typeof(string).FullName;
                case JTokenType.TimeSpan:
                    return typeof(TimeSpan).FullName;
                case JTokenType.Uri:
                    return typeof(Uri).FullName;
                default:
                    return null;
            }
        }
    }
}
