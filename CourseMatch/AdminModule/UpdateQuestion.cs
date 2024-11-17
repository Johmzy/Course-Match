using CourseMatch.File_Handling;
using System;
using System.IO;

namespace CourseMatch.AdminModule
{
    static public class UpdateQuestion
    {
        static public void UpdateQ(string filePath)
        {
            Console.WriteLine("Options in the system:");
            ViewQuestions.DisplayQ(filePath);

            Console.WriteLine("Enter 'back' to return to the admin menu.");
            Console.Write("Enter Question ID to update: ");
            string questionID = Console.ReadLine();


            if (questionID.ToLower() == "back")
            {
                Console.Clear();
                return;
            }


            string[] questions = File.ReadAllLines(filePath);
            int questionIndex = -1;

            for (int i = 0; i < questions.Length; i++)
            {
                var parts = questions[i].Split(',');
                if (parts.Length > 0 && parts[0] == questionID)
                {
                    questionIndex = i;
                    break;
                }
            }

            if (questionIndex == -1)
            {
                Console.WriteLine("Question not found.");
                return;
            }

            Console.WriteLine($"Current Question: {questions[questionIndex]}");
            Console.Write("Enter new question text: ");
            string newText = Console.ReadLine();

            var questionParts = questions[questionIndex].Split(',');
            questions[questionIndex] = $"{questionParts[0]},{newText}";

            File.WriteAllLines(filePath, questions);
            Console.WriteLine("Question updated successfully.");
        }
    }
}
