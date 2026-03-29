using System;

namespace Lab3
{
    class Program
    {
        /// <summary>
        /// Main menu to execute Laboratory Work 3 tasks.
        /// </summary>
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nChoose a task (1-2) or 0 to exit:");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1": Task1.Execute(); break;
                    case "2": Task2.Execute(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }
    }
}