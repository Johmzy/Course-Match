using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMatch.AdminModule
{
    static class DeleteOption
    {

        public static void DeleteOptions(string optionsFilePath)
        {
            Console.WriteLine("Enter 'back' to return to the admin menu.");
            Console.Write("Enter the Question ID to delete an option from: ");
            string questionID = Console.ReadLine();

            if (questionID.ToLower() == "back")
            {
                Console.Clear();
                return;
            }

            // Display the options for the specified question ID
            DisplayOptions(optionsFilePath, questionID);

            // Ask the admin which option key they want to delete
            Console.WriteLine("Enter the Option Key to delete: ");
            string optionKey = Console.ReadLine();

            // Delete the specified option from options.csv
            DeleteOptionFromFile(optionsFilePath, questionID, optionKey);

            Console.WriteLine($"Option {optionKey} for Question {questionID} has been deleted.");
        }

        static void DisplayOptions(string filePath, string questionID)
        {
            bool optionsExist = false;
            using (var reader = new StreamReader(filePath))
            {
                // Skip the header
                reader.ReadLine();

                // Read through the file and display options for the given Question ID
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var row = line.Split(',');

                    if (row[0] == questionID) // Check if the Question ID matches
                    {
                        Console.WriteLine($"Option Key: {row[1]}, Option Text: {row[2]}, Next Step: {row[3]}");
                        optionsExist = true;
                    }
                }
            }

            if (!optionsExist)
            {
                Console.WriteLine("No options found for this Question ID.");
            }
        }

        static void DeleteOptionFromFile(string filePath, string questionID, string optionKey)
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

                    var row = line.Split(',');

                    // If the question ID and option key match, skip writing this line (effectively deleting it)
                    if (row[0] != questionID || row[1] != optionKey)
                    {
                        writer.WriteLine(line); // Write the line to the temp file if it's not the one to delete
                    }
                }
            }

            // Replace the original file with the temp file
            File.Delete(filePath);
            File.Move(tempFile, filePath);
        }
    }
}  
