using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrchidLink.Data;
using System;

namespace OrchidLink.Controllers
{
    public class LinkController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public LinkController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("/go/{slug}")]
        public IActionResult Index(string slug)
        {
            var link = _dbContext.Links.Where(d => d.Slug == slug).FirstOrDefault();
            if (link == null) return NotFound();

            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7)
            };
            Response.Cookies.Append("OrchidLink.AnnonUser", Guid.NewGuid().ToString(), option);

            return Redirect(link.Destination);
        }
    }
}
