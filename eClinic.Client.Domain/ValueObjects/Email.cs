using System.Net;
using System.Text.RegularExpressions;

namespace eClinic.Client.Domain.ValueObjects
{
    public class Email
    {
        public string Address { get; private set; }

        public Email() { }
        private Email(string email) => Address = email;

        public static Email Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O e-mail é obrigatório.");

            const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
                throw new ArgumentException($"Formato de e-mail inválido: {email}");
            
            return new Email(email);
        }
    }
}
