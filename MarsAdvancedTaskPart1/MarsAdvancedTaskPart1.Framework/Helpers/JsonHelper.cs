using Newtonsoft.Json;

namespace MarsAdvancedTaskPart1.Framework.Helpers
{
    public class JsonHelper
    {
        //Read Json from a file and deserializes it into a model object
        public static T ReadJson<T>(string jsonPath)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), jsonPath);
            var jsonData = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
    }
}
