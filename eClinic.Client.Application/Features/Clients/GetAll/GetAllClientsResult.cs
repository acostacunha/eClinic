namespace eClinic.Client.Application.Features.Clients.GetAll
{
    public class GetAllClientsResult
    {
        public List<ClientResponse> Items { get; set; } = new();
        public int TotalItems { get; set; }
        public int Page {  get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }

    }
}
