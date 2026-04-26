namespace eClinic.Client.Application.Features.Clients
{
    public class ClientResponse
    {
        public Guid PublicId {get;set;}
        public string Name {get;set;} = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender {  get; set; } = string.Empty;
        public string Phone {  get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
