using System;
using System.IO;

namespace CourseMatch.AdminModule
{
    public static class MatchLogic
    {
        public static void StartMatch(string questionsFilePath, string optionsFilePath)
        {
            string currentQuestionID = "Q1"; // Start from the first question

            while (true)
            {
                // Read the question from Questions.csv
                string questionText = GetQuestionText(currentQuestionID, questionsFilePath);
                if (string.IsNullOrEmpty(questionText))
                {
                    Console.WriteLine("Question not found.");
                    break;
                }

                Console.WriteLine($"Question: {questionText}");


                // Display options for the current question from Options.csv
                Console.WriteLine("Options:");
                DisplayOptions(currentQuestionID, optionsFilePath);


                // Ask the user to select an option
                Console.Write("Enter Option Key: ");
                string selectedKey = Console.ReadLine();
                Console.Clear();


                // Find the next step based on the selected option
                string nextStep = GetNextStep(currentQuestionID, selectedKey, optionsFilePath);


                if (string.IsNullOrEmpty(nextStep))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Option Key.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                // If the next step is a match, display it and exit
                if (nextStep.StartsWith("Match ->"))
                {
                    Console.WriteLine();
                    Console.WriteLine("Congratulations! You have a matched course!");
                    Console.WriteLine(nextStep.Replace("Match ->", "Recommended Program:"));
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }

                // Otherwise, move to the next question
                currentQuestionID = nextStep;
            }
        }

        private static string GetQuestionText(string questionID, string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var row = line.Split(','); // CSV is comma-separated
                    if (row.Length > 1 && row[0] == questionID)
                    {
                        return row[1];
                    }
                }
            }
            return null;
        }

        private static void DisplayOptions(string questionID, string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var row = line.Split(','); // CSV is comma-separated
                    if (row.Length > 3 && row[0] == questionID)
                    {
                        Console.WriteLine($"{row[1]}: {row[2]}");
                    }
                }
            }
        }

        private static string GetNextStep(string questionID, string optionKey, string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var row = line.Split(','); // CSV is comma-separated
                    if (row.Length > 3 && row[0] == questionID && row[1] == optionKey)
                    {
                        return row[3];
                    }
                }
            }

            return null;
        }
    }
}
