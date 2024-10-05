using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using lab1.ViewModels;
using lab1.Repositories.Interfaces; // Підключення до інтерфейсу репозиторію
using System.Linq;

namespace lab1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        // GET: Admin/Booking
        public IActionResult Index()
        {
            var bookings = _bookingRepository.GetAll().ToList();
            var viewModel = new AppViewModel
            {
                Bookings = bookings
            };
            return View(viewModel);
        }

        // GET: Admin/Booking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _bookingRepository.Add(booking);
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Admin/Booking/Edit/{id}
        public IActionResult Edit(int id)
        {
            var booking = _bookingRepository.GetById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Admin/Booking/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookingRepository.Update(booking);
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Admin/Booking/Delete/{id}
        public IActionResult Delete(int id)
        {
            var booking = _bookingRepository.GetById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Admin/Booking/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookingRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
