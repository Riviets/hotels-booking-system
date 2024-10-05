using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using lab1.ViewModels;
using lab1.DBContext; // Підключіть ваш DbContext
using System.Linq;

namespace lab1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Ін'єкція залежності для доступу до бази даних
        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var hotels = _context.Hotels.ToList();
            var viewModel = new AppViewModel
            {
                Hotels = hotels
            };
            return View(viewModel);
        }
    }
}
