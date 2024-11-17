using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseMatch.AdminModule;
using CourseMatch.UserManagement;
using CourseMatch.MenuUI;
using CourseMatch.File_Handling;
using System.IO;

namespace CourseMatch.MenuUI
{
    public class AdminMenu : Menu
    {
        public override void DisplayMenu()
        {
            string pathQ = "questions.csv";
            string pathO = "options.csv";

            while (true)
            {
                Console.WriteLine(" ||Admin Menu|| ");
                Console.WriteLine("1. View Questions");
                Console.WriteLine("2. View Options");
                Console.WriteLine("3. Add a Question");
                Console.WriteLine("4. Add an Option");
                Console.WriteLine("5. Update Questions");
                Console.WriteLine("6. Update Options");
                Console.WriteLine("7. Delete Questions and Options");
                Console.WriteLine("8. Logout");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        ViewQuestions.DisplayQ(pathQ);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        ViewOptions.DisplayO(pathO);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        AddQuestion.AddQ(pathQ);
                        break;

                    case "4":
                        Console.Clear();
                        AddOption.AddO(pathO);
                        break;

                    case "5":
                        Console.Clear();
                        UpdateQuestion.UpdateQ(pathQ);
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "6":
                        Console.Clear();
                        UpdateOption.UpdateO(pathO);
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "7":
                        Console.Clear();
                        DeleteQuestion.DeleteQ(pathQ, pathO);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "8":
                        Console.WriteLine("Logging out...");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid option, try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}