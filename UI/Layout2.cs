using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.UI
{
    //for two colomns display, still needs work
    internal class Layout2
    {
        private string _prompt = "";
        private readonly string[] _options;
        private int _currentSelection = 0;
        private int _drawMenuColumnPos;
        private int _drawMenuRowPos;
        private int _menuMaximumWidth;
        private int _columns = 1; // Number of columns for the menu

        public Layout2(string[] options, string prompt)
        {
            _prompt = prompt;
            _options = options;
            ModifyMenuCentered(); // Call this method to calculate _menuMaximumWidth based on the options
        }

        public int GetMaximumWidth()
        {
            return _menuMaximumWidth;
        }

        public void CenterMenuToConsole()
        {
            _drawMenuColumnPos = GetConsoleWindowWidth() / 2 - _menuMaximumWidth / 2;
        }

        public void ModifyMenuCentered()
        {
            int maximumWidth = _options.Max(option => option.Length) + 4; // Adding padding
            _menuMaximumWidth = maximumWidth * _columns; // Assume each column can be as wide as the widest option
        }

        public static int GetConsoleWindowWidth()
        {
            return Console.WindowWidth;
        }

        public void SetConsoleWindowSize(int width, int height)
        {
            Console.WindowWidth = width;
            Console.WindowHeight = height;
        }

        public void SetConsoleTextColor(ConsoleColor foreground, ConsoleColor background)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }

        public void ResetCursorVisible()
        {
#if WINDOWS
            Console.CursorVisible = !Console.CursorVisible;
#endif
        }

        public void SetCursorPosition(int row, int column)
        {
            if (row >= 0 && row < Console.WindowHeight)
            {
                Console.CursorTop = row;
            }
            if (column >= 0 && column < Console.WindowWidth)
            {
                Console.CursorLeft = column;
            }
        }

        private int GetStringLines(string input)
        {
            return input.Split('\n').Length;
        }

        public int RunMenu()
        {
            bool run = true;
            ConsoleKey keyPressed;
            Console.WriteLine(_prompt);
            _drawMenuRowPos = GetStringLines(_prompt) + 2; // Adjusting initial row position based on prompt
            CenterMenuToConsole(); // Ensure menu is centered

            while (run)
            {
                DrawMenu();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                int rows = (_options.Length + _columns - 1) / _columns; // Calculate the total number of rows needed
                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        _currentSelection = (_currentSelection - _columns + _options.Length) % _options.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        _currentSelection = (_currentSelection + _columns) % _options.Length;
                        break;
                    case ConsoleKey.LeftArrow:
                        _currentSelection = (_currentSelection - 1 + _options.Length) % _options.Length;
                        break;
                    case ConsoleKey.RightArrow:
                        _currentSelection = (_currentSelection + 1) % _options.Length;
                        break;
                    case ConsoleKey.Enter:
                        run = false;
                        break;
                }
            }

            return _currentSelection;
        }

        private void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine(_prompt);
            for (int i = 0; i < _options.Length; i++)
            {
                int row = _drawMenuRowPos + i / _columns;
                int colOffset = i % _columns * (_menuMaximumWidth / _columns);
                SetCursorPosition(row, _drawMenuColumnPos + colOffset);

                if (i == _currentSelection)
                {
                    SetConsoleTextColor(ConsoleColor.Yellow, ConsoleColor.Green);
                }
                else
                {
                    SetConsoleTextColor(ConsoleColor.White, ConsoleColor.Black);
                }

                Console.Write(_options[i]);
                Console.ResetColor();
            }
        }
    }
}
