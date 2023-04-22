using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Legion_IX.Helpers
{
    internal abstract class MyValidators
    {
        internal static bool ValidateEmail(string email)
        {
            string pattern = @"^(\w+[a-z]{2,})\.(\w+[a-z]{2,})@edu.fit.ba";
            return Regex.IsMatch(email, pattern);
        }

        internal static bool ValidatePassword(string password)
        {
            string pattern = @"(^(?=.+[A-Za-z]){5,}(?=.+\d){3,})";
            return Regex.IsMatch(password, pattern);
        }

        internal static bool Validate_ServicerAssignedSubjectsToProfessor(int checkedItems)
        {
            return (checkedItems <= 0)? true : false;
        }

        internal static bool Validate_ServicerAssignedSubjectsToStudent_Dictionary(in Dictionary<int, List<string>> dicto)
        {
            foreach(List<string> item in dicto.Values)
            {
                if (item.Count > 0)
                    return true;
            }

            return false;
        }
    }
}