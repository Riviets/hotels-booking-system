using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using lab1.ViewModels;
using lab1.Repositories.Interfaces; // Додано для доступу до інтерфейсу репозиторію
using System.Linq;

namespace lab1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;

        // Ін'єкція залежності для доступу до репозиторія
        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        // GET: Admin/Hotel
       public IActionResult Index()
{
    var hotels = _hotelRepository.GetAll().ToList(); // Явне перетворення на List<Hotel>
    var viewModel = new AppViewModel
    {
        Hotels = hotels
    };
    return View(viewModel);
}


        // GET: Admin/Hotel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Hotel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _hotelRepository.Add(hotel); // Додавання нового готелю через репозиторій
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Admin/Hotel/Edit/5
        public IActionResult Edit(int id)
        {
            var hotel = _hotelRepository.GetById(id); // Отримання готелю за ID
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Admin/Hotel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _hotelRepository.Update(hotel); // Оновлення готелю через репозиторій
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Admin/Hotel/Delete/5
        public IActionResult Delete(int id)
        {
            var hotel = _hotelRepository.GetById(id); // Отримання готелю за ID
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Admin/Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _hotelRepository.Delete(id); // Видалення готелю через репозиторій
            return RedirectToAction(nameof(Index));
        }
    }
}
