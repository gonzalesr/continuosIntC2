using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Shared
{
    public class EmailValue
    {
        public string Value { get; private set; }
        private static readonly Regex EmailRegex = new(
           @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
           RegexOptions.Compiled | RegexOptions.IgnoreCase
       );
        public EmailValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El correo electrónico no puede estar vacío.", nameof(value));

            if (!EmailRegex.IsMatch(value))
                throw new ArgumentException("El formato del correo electrónico no es válido.", nameof(value));

            Value = value;
        }
        public static implicit operator string(EmailValue email)
        {
            return email == null ? "" : email.Value;
        }

        public static implicit operator EmailValue(string e)
        {
            return new EmailValue(e);
        }
        public override string ToString() => Value;
    }
}
