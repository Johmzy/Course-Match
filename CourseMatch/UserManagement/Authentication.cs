using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMatch.UserManagement
{
    public class Authentication
    {
        public class VerificationResult
        {
            public bool IsValid { get; set; }
            public string Role { get; set; }
        }

        public VerificationResult VerifyCredentials(string username, string password)
        {
            var result = new VerificationResult();

            if (username == "user" && password == "user123")
            {
                result.IsValid = true;
                result.Role = "user";
            }
            else if (username == "admin" && password == "admin123")
            {
                result.IsValid = true;
                result.Role = "admin";
            }
            else
            {
                result.IsValid = false;
                result.Role = string.Empty;
            }

            return result;
        }
    }

}
