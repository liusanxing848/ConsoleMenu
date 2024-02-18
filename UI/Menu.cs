using ConsoleMenu.UI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.UI
{
    public static class Menu
    {
        public static string[] options = new string[]
        {
            "Display Configuration",
            "File Explorer",
            "Option 3",
            "Option 4",
            "Exit"
        };

        public static void Run()
        {
            Layout page = new Layout(options, _prompt);
            int currentSelection = page.RunMenu();
            switch (currentSelection)
            {
                case 0:
                    Console.Clear();
                    Run();
                    break;
                case 1:
                    _ViewDefaultConfigs();
                    break;
                case 2:
                    _FileExplorer();
                    break;
                case 3:
                    _ViewDefaultConfigs();
                    break;
                case 4:
                    _ViewDefaultConfigs();
                    break;
                case 5:
                    Console.Clear();
                    Run();
                    break;
                default:
                    break;
            }
        }

        private static void _FileExplorer()
        {
            Console.Clear();
            string selectedFilePath = " ";
            FileExporer.Run(out selectedFilePath, Run, Run);
        }

        private static void _ViewDefaultConfigs()
        {
            Console.Clear();
            DisplayPage.Run(Run, IO.ReadYAMLtoString("", "config.yaml"));
        }












        //https://www.asciiart.eu/text-to-ascii-art
        private static string _prompt = @"         
.--------------------------------------------------------------------------------------------------------.
|                                                                                                        |
|   _____    _                    _____   ______   _    _    ____    _        _____    ______   _____    |
|  |  __ \  | |          /\      / ____| |  ____| | |  | |  / __ \  | |      |  __ \  |  ____| |  __ \   |
|  | |__) | | |         /  \    | |      | |__    | |__| | | |  | | | |      | |  | | | |__    | |__) |  |
|  |  ___/  | |        / /\ \   | |      |  __|   |  __  | | |  | | | |      | |  | | |  __|   |  _  /   |
|  | |      | |____   / ____ \  | |____  | |____  | |  | | | |__| | | |____  | |__| | | |____  | | \ \   |
|  |_|      |______| /_/    \_\  \_____| |______| |_|  |_|  \____/  |______| |_____/  |______| |_|  \_\  |
|                                                                                                        |
'--------------------------------------------------------------------------------------------------------'
";
    }
}
