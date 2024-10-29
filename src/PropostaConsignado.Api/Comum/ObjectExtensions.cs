using Newtonsoft.Json;

namespace PropostaConsignado.Api.Comum
{
    public static class ObjectExtensions
    {
        public static string ToNameTypeJson(this object @object)
            => JsonConvert.SerializeObject(@object, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });

        public static TTipoDesejado ToNameTypeObject<TTipoDesejado>(this string json)
            => JsonConvert.DeserializeObject<TTipoDesejado>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects })!;
    }
}