using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    internal class DisplayPage
    {
        private static string[] _options = new string[] { };

        public static void Run(Action pageOption)
        {
            Layout menu = new Layout(_options, "");
            int curr = menu.RunMenu();
            switch (curr)
            {
                case 0:
                    Console.Clear();
                    pageOption.Invoke();
                    break;
                default:
                    break;
            }
        }
    }
}
