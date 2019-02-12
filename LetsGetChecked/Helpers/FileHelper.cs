using Newtonsoft.Json;
using System.IO;
using LetsGetChecked.Exception;

namespace LetsGetChecked.Helpers
{
    public static class FileHelper 
    {
        public static string ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileDoesNotExistsException($"File {filePath} does not exists");
            }

            return File.ReadAllText(filePath);
        }

        public static T DeserializeFile<T>(string fileContent)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(fileContent);
            }
            catch (System.Exception ex)
            {
                throw new InvalidFileException($"File is invalid! - Exception {ex}");
            }
        }
    }
}