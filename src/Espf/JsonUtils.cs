using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace Espf {
    /// <summary>
    /// Esta clase contiene el metodo de serializacion tal cual
    /// se utilizaba en el DemoProgram del SDK de Evolis
    /// </summary>
    public static class JsonUtils {

        public static string Serialize<T>(object obj) {
            var stream = new MemoryStream();
            var serializer = new DataContractJsonSerializer(typeof(T));
            serializer.WriteObject(stream, obj);
            stream.Position = 0;
            var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static T Deserialize<T>(string json) {
            var serializer = new DataContractJsonSerializer(typeof(T));
            object result;
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json))) {
                result = serializer.ReadObject(ms);
            }
            return (T)result;
        }

    }
}
