using eClinic.Client.Domain.Enums;
using eClinic.Client.Domain.ValueObjects;

namespace eClinic.Client.Domain.Entities
{
    public class Client : AuditableEntity
    {
        public string Name { get; private set; } = string.Empty;
        private Cpf _cpf;
        public Cpf Cpf { get => _cpf; private set => _cpf = value; }
        private Email _email;
        public Email Email { get => _email; private set => _email = value; }
        public string Phone { get; set; } = string.Empty;
        public DateTime Birthdate { get; private set; }
        public GenderType Gender { get; private set; }
        public Adress? Adress { get; private set; } = null;
        public Client() { }
        public Client(string name, Cpf cpf, Email email, string phone, DateTime birthdate, GenderType gender)
        {
            PublicId = Guid.NewGuid();
            Name = name;
            Cpf = cpf;
            Email = email;
            Phone = phone;
            Birthdate = birthdate;
            Gender = gender;
        }

        public void AddAdress(Adress adress)
        {
            Adress = adress;
        }

        public void UpdateClient(string name, Email email, string phone, DateTime birthdate, GenderType gender)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Birthdate = birthdate;
            Gender = gender;
            UpdateAt = DateTime.Now;
        }
    }
}
