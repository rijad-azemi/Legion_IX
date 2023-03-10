using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Legion_IX.Helpers
{
    internal class Validators
    {
        public bool ValidateEmail(string email)
        {
            string pattern = @"^(\w+[a-z]{3,})\.(\w+[a-z]{3,})@edu.fit.ba";
            return Regex.IsMatch(email, pattern);
        }

        public bool ValidatePassword(string password)
        {
            string pattern = @"(^(?=.+[A-Za-z]){5,}(?=.+\d){3,})";
            return Regex.IsMatch(password, pattern);
        }
    }
}
