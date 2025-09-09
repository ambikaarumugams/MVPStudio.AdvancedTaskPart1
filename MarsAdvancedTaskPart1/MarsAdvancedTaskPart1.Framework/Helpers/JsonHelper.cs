using Newtonsoft.Json;

namespace MarsAdvancedTaskPart1.Framework.Helpers
{
    public class JsonHelper
    {
        //Read Json from a file and deserializes it into a model object
        public static T ReadJson<T>(string jsonPath)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), jsonPath);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"JSON file not found: {fullPath}");

            var jsonData = File.ReadAllText(fullPath);
            var obj = JsonConvert.DeserializeObject<T>(jsonData);

            if (obj == null)
                throw new InvalidOperationException($"Could not deserialize {fullPath} into {typeof(T).Name}");
           
            return obj;
        }
    }
}
