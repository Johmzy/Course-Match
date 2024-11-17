using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMatch.AdminModule
{
    static public class UpdateOption
    {
        static public void UpdateO(string filePath)
        {
            // Ask for the Question ID to update
            Console.WriteLine("Enter 'back' to return to the admin menu.");
            Console.Write("Enter Question ID to update: ");
            string questionID = Console.ReadLine();

            if (questionID.ToLower() == "back")
            {
                Console.Clear();
                return;
            }

            string[] options = File.ReadAllLines(filePath);
            bool foundQuestion = false;

            // Loop through all options and find the ones with the matching Question ID
            for (int i = 0; i < options.Length; i++)
            {
                var parts = options[i].Split(',');
                if (parts.Length > 0 && parts[0] == questionID)
                {
                    foundQuestion = true;

                    // Display all options for the selected Question ID
                    Console.WriteLine($"{options[i]}");
                }
            }

            if (!foundQuestion)
            {
                Console.WriteLine("Question not found.");
                return;
            }

            // Ask which option to update
            Console.Write("Enter Option Key to update: ");
            string optionKeyToUpdate = Console.ReadLine();

            // Loop through again to find the specific option by key
            bool optionFound = false;
            for (int i = 0; i < options.Length; i++)
            {
                var parts = options[i].Split(',');
                if (parts.Length > 0 && parts[0] == questionID && parts[1] == optionKeyToUpdate)
                {
                    optionFound = true;

                    // Display current details of the option
                    Console.WriteLine($"Current Option: {options[i]}");

                    // Ask for new values
                    Console.Write("Enter new Option Text: ");
                    string newOptionText = Console.ReadLine();
                    Console.Write("Enter new Next Step: ");
                    string newNextStep = Console.ReadLine();

                    // Update the option in the options array
                    options[i] = $"{questionID},{parts[1]},{newOptionText},{newNextStep}";

                    // Save the updated options back to the file
                    File.WriteAllLines(filePath, options);
                    Console.WriteLine("Option updated successfully.");
                    return;
                }
            }

            if (!optionFound)
            {
                Console.WriteLine("Option Key not found.");
            }

        }
    }
}
