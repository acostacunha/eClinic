namespace eClinic.Client.Domain.ValueObjects
{
    public class Adress
    {
        public string Street { get; private set;  }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        private Adress() { }
        public static Adress Create(
            string street, 
            string number,
            string complement,
            string city,
            string state,
            string zipcode
            )
        {
            return new Adress {
                Street = street.Trim(),
                Number = number.Trim(),
                Complement = complement.Trim(),
                City = city.Trim(),
                State = state.Trim(),
                ZipCode = zipcode.Trim()
            };
        }
    }
}
