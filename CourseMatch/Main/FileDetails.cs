using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMatch.File_Handling
{
    internal class FiLeDetails
    {
        public class Question
        {
            public string QuestionID { get; set; }
            public string QuestionText { get; set; }
        }

        public class Option
        {
            public string QuestionID { get; set; }
            public string OptionKey { get; set; }
            public string OptionText { get; set; }
            public string NextStep { get; set; }
        }
    }
}
