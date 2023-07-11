using Microsoft.AspNetCore.Http;
using NetTopologySuite.IO;
using Newtonsoft.Json;

namespace Service.Extentions
{
    public static class GeoJsonConverter
    {
        public static T ConvertGeoJsonToObject<T>(this IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var content = reader.ReadToEnd();
                var geoJsonSerializer = GeoJsonSerializer.Create();
                using (var stringReader = new System.IO.StringReader(content))
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    return geoJsonSerializer.Deserialize<T>(jsonReader);
                }
            }
        }
    }
}
