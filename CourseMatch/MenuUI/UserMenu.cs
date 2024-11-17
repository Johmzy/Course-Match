using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CourseMatch.AdminModule;

namespace CourseMatch.MenuUI
{
    public class UserMenu : Menu
    {
        public override void DisplayMenu()
        {
            string pathO = "Options.csv";
            string pathQ = "Questions.csv";
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" ||User Menu|| ");
                Console.WriteLine("1. Start Course Matching");
                Console.WriteLine("2. Logout");
                Console.WriteLine("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        MatchLogic.StartMatch(pathQ, pathO);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Logging out...");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                        break;  
               
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            
        }
    }
}
