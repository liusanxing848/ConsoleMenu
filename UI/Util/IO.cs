using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConsoleMenu.UI.Util
{
    internal static class IO
    {
        public static string ReadYAMLtoString(string path, string filename)
        {
            IDeserializer deserializer = new DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();

            string yaml = File.ReadAllText(path + filename);

            return yaml;
        }
        public static List<string> FileToMenuOption(string filePath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(filePath);
            FileInfo[] fileInfos = dirInfo.GetFiles("*");

            List<string> menuOptions = new List<string>();
            foreach (FileInfo fInfo in fileInfos)
            {
                menuOptions.Add(fInfo.Name);
            }
            menuOptions.Add("BACK");

            return menuOptions;
        }
    }
}
