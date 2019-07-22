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

        public static string Serialize(Type type, object obj) {
            try {
                var stream = new MemoryStream();
                var serializer = new DataContractJsonSerializer(type);
                serializer.WriteObject(stream, obj);
                stream.Position = 0;
                var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            catch (Exception ex) {
                throw new Exception($"Error al serializar objeto {type}.", ex);
            }
        }

        public static object Deserialize(Type type, string json) {
            try {
                var serializer = new DataContractJsonSerializer(type);
                object result;
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json))) {
                    result = serializer.ReadObject(ms);
                }
                return result;
            } catch (Exception ex) {
                throw new Exception($"Error al deserializar objeto {type}.", ex);
            }
        }

    }
}
