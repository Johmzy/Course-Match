using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CourseMatch.File_Handling.FiLeDetails;

namespace CourseMatch.AdminModule
{
    public static class ViewOptions
    {
        public static void DisplayO(string filePath)
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

                        var option = new Option
                        {
                            QuestionID = col[0],
                            OptionKey = col[1],
                            OptionText = col[2],
                            NextStep = col[3]
                        };

                        // Output the data or process it
                        Console.WriteLine("-----------------------");
                        Console.WriteLine();
                        Console.WriteLine($"Question ID:{option.QuestionID}");
                        Console.WriteLine($"Option Key:{option.OptionKey}");
                        Console.WriteLine($"Option Text:{option.OptionText}");
                        Console.WriteLine($"Next Step:{option.NextStep}");
                        Console.WriteLine();
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
