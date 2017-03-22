using System.IO;

namespace SoftUniStore.Utilities
{
    public static class WebUtil
    {
        public static string RetrieveFileContent(string path)
        {
            string content = File.ReadAllText(path);

            return content;
        }
    }
}
