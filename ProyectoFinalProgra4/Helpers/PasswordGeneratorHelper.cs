using System;
using System.Linq;
using System.Text;

namespace ProyectoFinalProgra4.Helpers
{
    public static class PasswordGeneratorHelper
    {
        public static string Generate(int length = 20)
        {
            // Conjuntos de caracteres
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string symbols = "!@#$%^&*()-_=+[]{};:,.<>?";

            var allChars = upper + lower + digits + symbols;
            var random = new Random();

            var password = new StringBuilder();

            // Garantizar al menos uno de cada tipo
            password.Append(upper[random.Next(upper.Length)]);
            password.Append(lower[random.Next(lower.Length)]);
            password.Append(digits[random.Next(digits.Length)]);
            password.Append(symbols[random.Next(symbols.Length)]);

            // Rellenar hasta la longitud requerida
            for (int i = password.Length; i < length; i++)
            {
                password.Append(allChars[random.Next(allChars.Length)]);
            }

            // Mezclar los caracteres para que no queden siempre en el mismo orden
            return new string(password.ToString().OrderBy(c => random.Next()).ToArray());
        }

        public static bool IsComplex(string pwd)
        {
            if (string.IsNullOrWhiteSpace(pwd) || pwd.Length < 14) return false;

            bool hasUpper = pwd.Any(char.IsUpper);
            bool hasLower = pwd.Any(char.IsLower);
            bool hasDigit = pwd.Any(char.IsDigit);
            bool hasSymbol = pwd.Any(c => !char.IsLetterOrDigit(c));

            return hasUpper && hasLower && hasDigit && hasSymbol;
        }
    }
}
