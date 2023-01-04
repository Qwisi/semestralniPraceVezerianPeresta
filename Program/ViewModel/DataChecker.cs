using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Program.ViewModel
{
    public class DataChecker
    {
        public static bool ValidEmail(string email, ref string exception)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch (Exception ex)
            {
                exception = "Ivalid email type";
                return false;
            }
        }

        public static bool ValidPass(string password, ref string exception)
        {
            bool isValid = true;
            if (password.Length < 8)
            {
                exception += "\nPassword must be at least 8 characters long";
                isValid = false;
            }

            // Check for at least one lowercase letter
            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                exception += "\nPassword must contain at least one lowercase letter";
                isValid = false;
            }

            // Check for at least one uppercase letter
            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                exception += "\nPassword must contain at least one uppercase letter";
                isValid = false;
            }
            /*
            // Check for at least one digit
            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                exception += "\nPassword must contain at least one digit";
                isValid = false;
            }

            // Check for at least one special character
            if (!Regex.IsMatch(password, @"[!#$%&'*+\-/=?\^_`{|}~]"))
            {
                exception += "\nPassword must contain at least one special character";
                isValid = false;
            }*/
            return isValid;
        }

        public static bool CheckPasswordEquals(string password, string confirmPassword, ref string exception)
        {
            if (password.Equals(confirmPassword))
            {
                return true;
            }
            else
            {
                exception = "Passwords are not equals";
                return false;
            }
        }

    }
}
