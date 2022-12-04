using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrchidLink.Controllers
{
    public class IndexRedirectionController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return Redirect("/Links");
        }
    }
}
