using System.IO;

namespace Dworkin.Utils {
    public class Importer
    {
        public static string LoadJsonFromFileAsync(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}