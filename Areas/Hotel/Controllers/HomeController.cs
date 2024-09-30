using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using lab1.DBContext; 
using System.Linq;


namespace YourProjectName.Areas.Hotel.Controllers
{
    [Area("Hotel")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Зчитуємо першого користувача з таблиці Users
            var user = _context.Users.FirstOrDefault();
            
            // Передаємо користувача в View
            return View(user);
        }
    }
}
