using Microsoft.AspNetCore.Mvc;

namespace eClinic.Client.Application.Features.Clients.GetById
{
    public class GetClientByIdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
