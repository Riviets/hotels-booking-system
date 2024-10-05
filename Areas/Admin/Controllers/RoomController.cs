using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using lab1.ViewModels;
using lab1.Repositories.Interfaces; // Підключення до інтерфейсу репозиторію
using System.Linq;

namespace lab1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        // GET: Admin/Room
        public IActionResult Index()
        {
            var rooms = _roomRepository.GetAll().ToList();
            var viewModel = new AppViewModel
            {
                Rooms = rooms
            };
            return View(viewModel);
        }

        // GET: Admin/Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomRepository.Add(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Admin/Room/Edit/{id}
        public IActionResult Edit(int id)
        {
            var room = _roomRepository.GetById(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Admin/Room/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _roomRepository.Update(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Admin/Room/Delete/{id}
        public IActionResult Delete(int id)
        {
            var room = _roomRepository.GetById(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Admin/Room/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _roomRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
