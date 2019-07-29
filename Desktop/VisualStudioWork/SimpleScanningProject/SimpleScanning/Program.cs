using System;
using System.IO;
using System.Collections.Generic;


namespace SimpleScanning
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuControl();

        }

        //MENU Methods
        public static void Menu()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("Type 1 to enter new tasks.");
            Console.WriteLine("Type 2 to view pages.");
            Console.WriteLine("Type 3 to edit tasks.");
            Console.WriteLine("_______________________________________________________________");
        }

        public static int UserMenuInput()
        {
            string input = "";

            do
            {
                Menu();
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));

            return int.Parse(input);
        }


        public static void MenuControl()
        {
            bool addInput = false;

            do
            {
                int menuSelect = UserMenuInput();
                switch (menuSelect)
                {
                    case 1:
                        Console.Clear();
                        ReturnUserInfo();
                        break;
                    case 2:
                        Console.Clear();
                        PagesDisplay();
                        break;
                    case 3:
                        Console.Clear();
                        // Enter the method for editing tasks
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;

                }
            } while (!addInput);
        }

        //PAGES Methods
        public static void Pages()
        {
            Console.WriteLine("Which page would you like to view?");
            Console.WriteLine("Type 1 to view page 1.");
            Console.WriteLine("Type 2 to view page 2.");
            Console.WriteLine("Type 3 to view page 3.");
            Console.WriteLine("Type 4 to view page 4.");
            Console.WriteLine("_______________________________________________________________");
        }
        public static int PagesInput()
        {
            string input = "";

            do
            {
                Pages();
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));

            return int.Parse(input);
        }

        public static void PagesDisplay()
        {
            
            PagesInput();
            SendUserInfo();
            List<string> tasks = ReturnUserInfo();

            List<string> pageOne = tasks.GetRange(0, 19);

            List<string> pageTwo = tasks.GetRange(20, 39);

            List<string> pageThree = tasks.GetRange(40, 59);

            List<string> pageFour = tasks.GetRange(60, 89);

            bool addInput = false;

            do
            {
                int pageSelect = PagesInput();
                switch (pageSelect)
                {
                    case 1:
                        Console.WriteLine("Page 1");
                        Console.WriteLine(" ");
                        Console.WriteLine(pageOne);
                        break;
                    case 2:
                        Console.WriteLine("Page 2");
                        Console.WriteLine(" ");
                        Console.WriteLine(pageTwo);
                        break;
                    case 3:
                        Console.WriteLine("Page 3");
                        Console.WriteLine(" ");
                        Console.WriteLine(pageThree);
                        break;
                    case 4:
                        Console.WriteLine("Page 4");
                        Console.WriteLine(" ");
                        Console.WriteLine(pageFour);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;

                }
            } while (!addInput);
        }

        // EDIT Methods
       

        //USER INFO Methods
        public static List<string> ReturnUserInfo()
        {
            List<string> tasks = new List<string>();
            StreamWriter writeInput = new StreamWriter("Input.txt", true);
            string line;

            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please enter the next task.");
                Console.WriteLine("To End press ENTER with no input.");
                Console.WriteLine("_______________________________________________________________");

                line = Console.ReadLine();

                tasks.Add(line);
            } while (line != "");

            foreach (string i in tasks)
            {
                writeInput.WriteLine(i);
                Console.WriteLine();
            }

            if (line == "")
            {
                writeInput.Close();
            }

            return tasks;
        }

        public static void SendUserInfo()
        {
            StreamReader returnInput = new StreamReader("Input.txt");
            string line;
            do
            {
                line = returnInput.ReadLine();

                Console.WriteLine(line);
            } while (line != null);
            returnInput.Close();
        }
    }
}
