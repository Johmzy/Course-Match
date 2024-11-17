using CourseMatch.File_Handling;

namespace CourseMatch.AdminModule
{
    public static class AddOption
    {
        public static void AddO(string optionsFilePath)
        {
            Console.WriteLine("Enter the Question ID to add options to: ");
            string questionID = Console.ReadLine();

            if (questionID.ToLower() == "back")
            {
                Console.Clear();
                return;
            }

            bool addingOptions = true;
            while (addingOptions)
            {
                Console.WriteLine("Enter an Option Key: ");
                string optionKey = Console.ReadLine();

                Console.WriteLine("Enter the Option Text: ");
                string optionText = Console.ReadLine();

                Console.WriteLine("Enter the Next Step: ");
                string nextStep = Console.ReadLine();

                // Append the option to the options CSV
                using (var writer = new StreamWriter(optionsFilePath, append: true))
                {
                    writer.WriteLine($"{questionID},{optionKey},{optionText},{nextStep}");
                }

                // Ask if the user wants to add another option
                Console.WriteLine("Do you want to add another option for this question? (y/n): ");
                string continueAdding = Console.ReadLine();

                if (continueAdding.ToLower() != "y")
                {
                    addingOptions = false;
                }
            }

            Console.WriteLine("Options added successfully.");
        }
    }
}
