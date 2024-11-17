using System;
using System.IO;

namespace CourseMatch.AdminModule
{
    public static class DeleteQuestion
    {
        public static void DeleteQ(string questionsFilePath, string optionsFilePath)
        {
            Console.WriteLine("Enter 'back' to return to the admin menu.");
            Console.WriteLine("Enter the Question ID to delete: ");
            string questionID = Console.ReadLine();

            if (questionID.ToLower() == "back")
            {
                Console.Clear();
                return;
            }

            // Delete the question from the questions.csv
            DeleteEntryFromFile(questionsFilePath, questionID);

            // Delete associated options from options.csv
            DeleteEntryFromFile(optionsFilePath, questionID);

            Console.WriteLine($"Question {questionID} and its associated options have been deleted.");
        }

        static void DeleteEntryFromFile(string filePath, string questionID)
        {
            var tempFile = Path.GetTempFileName();

            using (var reader = new StreamReader(filePath))
            using (var writer = new StreamWriter(tempFile))
            {
                string line;
                bool headerSkipped = false;

                while ((line = reader.ReadLine()) != null)
                {
                    // Skip the header once
                    if (!headerSkipped)
                    {
                        writer.WriteLine(line);
                        headerSkipped = true;
                        continue;
                    }

                    var values = line.Split(',');

                    if (values[0] != questionID) // If the Question ID doesn't match, write it to the temp file
                    {
                        writer.WriteLine(line);
                    }
                }
            }

            // Replace the original file with the temp file
            File.Delete(filePath);
            File.Move(tempFile, filePath);
        }
    }
}
