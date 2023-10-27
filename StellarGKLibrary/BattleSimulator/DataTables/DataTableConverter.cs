using System;
using System.Reflection;
using Newtonsoft.Json;

namespace StellarGKLibrary.DataTables
{
    public class DataTableConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type type = value.GetType();
            MethodInfo method = type.GetMethod("ToJsonArray");
            serializer.Serialize(writer, method.Invoke(value, null));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Activator.CreateInstance(objectType, new object[] { serializer, reader });
        }

        public override bool CanConvert(Type objectType)
        {
            Type genericTypeDefinition = objectType.GetGenericTypeDefinition();
            return genericTypeDefinition == typeof(DataTable<>);
        }
    }
}
