using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMatch.AdminModule
{
    public static class AddQuestion
    {
        public static void AddQ(string questionsFilePath)
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the Question ID: ");
                    string questionID = Console.ReadLine();

                    if (questionID.ToLower() == "back")
                    {
                        Console.Clear();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(questionID))
                    {
                        Console.WriteLine("Question ID cannot be empty. Please enter a valid Question ID.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue; // Prompts the user again for a valid ID
                    }

                    Console.WriteLine("Enter the Question Text: ");
                    string questionText = Console.ReadLine();

                    if (questionText.ToLower() == "back")
                    {
                        Console.Clear();
                        return;
                    }


                    if (string.IsNullOrWhiteSpace(questionText))
                    {
                        Console.WriteLine("Question Text cannot be empty. Please enter a valid Question Text.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue; // Prompts the user again for valid text
                    }

                    // Append the new question to the questions CSV
                    using (var writer = new StreamWriter(questionsFilePath, append: true))
                    {
                        writer.WriteLine($"{questionID},{questionText}");
                    }

                    Console.WriteLine("Question added successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

    }
}
