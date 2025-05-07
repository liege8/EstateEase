using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EstateEase.Models;
using EstateEase.Models.ViewModels;

namespace EstateEase.Areas.Agent.Controllers
{
    [Area("Agent")]
    [Authorize(Roles = "Agent")]
    public class PropertyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new PropertyViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(PropertyViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Add property creation logic here
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}