using GCPDev.FinalTask.Data;
using GCPDev.FinalTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GCPDev.FinalTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;

        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(WishModel wish)
        {
            if (!ModelState.IsValid)
                ViewBag.Message = "Wrong value";
            else
            {
                _context.Wishes.Add(wish);
                _context.SaveChanges();

                ViewBag.Message = $"Great! You've added new wish '{wish.Name}' to your list";
            }

            return View();
        }

        public IActionResult Wishes()
        {
            var wishes = _context.Wishes.ToList();

            if (wishes == null || wishes.Count == 0)
            {
                wishes = new List<WishModel> {
                    new WishModel { Name = "Here should be your wish", Description = "To add wish to your list go to home page or click 'Add wish' above " }
                };
            }
            return View(wishes);
        }

        [HttpPost]
        public IActionResult Delete(WishModel wish)
        {
            if (wish.Id == 0)
                TempData["Message"] = "This item can't be deleted";

            _context.Wishes.Remove(wish);
            _context.SaveChanges();

            TempData["Message"] = $"The wish {wish.Name} successfully deleted!";

            return RedirectToAction("Wishes");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
