using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tickflow.Json
{
    public class JsonExtensions : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
			return (typeof(object).IsAssignableFrom(objectType));
		}

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
			JObject jo = new JObject();
			Type type = value.GetType();
			jo.Add("type", type.Name);
			foreach (PropertyInfo prop in type.GetProperties())
			{
				if (prop.CanRead)
				{
					object propVal = prop.GetValue(value, null);
					if (propVal != null)
					{
						jo.Add(prop.Name, JToken.FromObject(propVal, serializer));
					}
				}
			}
			jo.WriteTo(writer);
		}
    }
}
