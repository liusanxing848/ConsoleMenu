using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    public static class Menu
    {
        public static string[] options = new string[]
        {
            "Initialize",
            "Set Environment & Service Provider Configurations",
            "Single Call",
            "Batch Call & Export",
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
                    Menu.Run();
                    break;
                case 1: 
                    _Initializie();
                    break;
                case 2:
                    _Initializie();
                    break;
                case 3:
                    _Initializie();
                    break;
                case 4:
                    _Initializie();
                    break;
                case 5: 
                    Console.Clear();
                    Menu.Run();
                    break;
                default:
                    break;
            }
        }

        private static void _Initializie()
        {
            Console.Clear();
            //Tasks.Initialize();
            //DisplayLogPage.Run(Menu.Run);
        }

        private static void _ViewDefaultConfigs()
        {
            Console.Clear();
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
