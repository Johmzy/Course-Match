using CourseMatch.UserManagement;
using System;
using CourseMatch;
using CourseMatch.MenuUI;


namespace CourseMatch.CourseMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var login = new Login();
            Console.WriteLine("WELCOME TO COURSEMATCH");
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();
            Console.Clear();

            while (true)
            {
                Console.Clear();
                var result = login.PromptCredentials();
                Console.ReadKey();
                Console.Clear();


                if (result.Role == "admin")
                {
                    var Admin = new AdminMenu();
                    Admin.DisplayMenu();
                }
                else if (result.Role == "user")
                {
                    var User = new UserMenu();
                    User.DisplayMenu();
                }
                
            }
        }
    }
}

