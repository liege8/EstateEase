using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EstateEase.Models;

namespace EstateEase.Areas.Agent.Controllers
{
    [Area("Agent")]
    [Authorize(Roles = "Agent")]
    public class InquiryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reply(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reply(int id, string message)
        {
            // Add reply logic here
            return RedirectToAction(nameof(Index));
        }
    }
}