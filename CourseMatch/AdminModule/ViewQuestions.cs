using System;
using System.IO;
using CourseMatch.File_Handling;
using CourseMatch.AdminModule;
using System.Text;
using static CourseMatch.File_Handling.FiLeDetails;

namespace CourseMatch.AdminModule
{
    public static class ViewQuestions
    {
        public static void DisplayQ(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    // Skip header
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var col = line.Split(',');

                        var question = new Question
                        {
                            QuestionID = col[0],
                            QuestionText = col[1]
                        };

                        // Output the data or process it
                        Console.WriteLine("-----------------------");
                        Console.WriteLine();
                        Console.WriteLine($"Question ID:{question.QuestionID}");
                        Console.WriteLine($"Question Text:{question.QuestionText}");
                        Console.WriteLine(); // Empty line for separation
                        Console.WriteLine("-----------------------");

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }
    }
}
