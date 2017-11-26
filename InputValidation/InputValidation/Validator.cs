using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace InputValidation
{
    class Validator
    {

        public bool ValidName(string name)
        {
            string letters = "[A-Za-z]*";
            string spaces = @"\s*";
            string pattern = @"^(" + letters + spaces + ")+$";
            if (Regex.IsMatch(name, pattern))
            {
                return true;
            }
            return false;
        }

        public bool ValidPhone(string phone)
        {
            string threeNumsInParenthesis = @"\(\d{3}\)?";
            string dash = "-";
            string threeNums = @"\d{3}";
            string numsInParenthesisORnumsAndDash = "(" + threeNumsInParenthesis + ")|(" + threeNums + dash + ")";
            string fourNums = @"\d{4}";
            string pattern = @"^(" + numsInParenthesisORnumsAndDash + ")?" + threeNums + dash + fourNums + "$";
            if (Regex.IsMatch(phone, pattern))
            {
                return true;
            }
            return false;
        }

        public bool ValidEmail(string email)
        {
            string notAt = @"[^@]";
            string dot = @"\.";
            string letters = "[a-z]";
            string wordORdash = @"\w|-";
            string pattern = @"^" + notAt + "+" + "@" + "((" + wordORdash + ")+" + dot + ")*" + dot + letters + "+" + "$";
            if (Regex.IsMatch(email, pattern))
            {
                return true;
            }
            return false;
        }
    }
}
