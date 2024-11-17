using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMatch.UserManagement
{
    public class Login : User
    {
        private Authentication auth = new Authentication();

        public Authentication.VerificationResult PromptCredentials()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                var result = auth.VerifyCredentials(username, password);

                if (result.IsValid)
                {
                    Console.WriteLine($"Login successful! Welcome {result.Role}");
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid credentials. Please try again.");
                    Console.ReadKey();
                    Console.Clear();

                }
            }

        }
    }
}
