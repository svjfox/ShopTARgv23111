using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Core.Domain; // Используем доменные модели
using ShopTARgv23.Data;
using ShopTARgv23.Models.Kindergarten; // Используем модели для представления

namespace ShopTARgv23.Controllers
{
    public class KindergartenController : Controller
    {
        private readonly ShopTARgv23Context _context;
        private readonly IKindergartenServices _kindergartenServices;
        private readonly IFileServices _fileServices;

        public KindergartenController(ShopTARgv23Context context)
        {
            _context = context;
        }

        // Метод для отображения списка детских садов
        public IActionResult Index()
        {
            var kindergartens = _context.Kindergartens
                .Select(k => new KindergartenIndexViewModel
                {
                    Id = k.Id,
                    KindergartenName = k.KindergartenName,
                    GroupName = k.GroupName,
                    ChildrenCount = k.ChildrenCount,
                    Teacher = k.Teacher
                }).ToList();

            return View(kindergartens);
        }

        // GET: Kindergarten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kindergarten/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ShopTARgv23.Models.Kindergarten.KindergartenViewModel viewModel) // Используем полное имя класса
        {
            if (ModelState.IsValid)
            {
                // Преобразуем ViewModel в доменную модель перед добавлением в БД
                var domainKindergarten = new ShopTARgv23.Core.Domain.Kindergarten // Используем полное имя класса
                {
                    KindergartenName = viewModel.KindergartenName,
                    GroupName = viewModel.GroupName,
                    ChildrenCount = viewModel.ChildrenCount,
                    Teacher = viewModel.Teacher
                };

                _context.Kindergartens.Add(domainKindergarten);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Kindergarten/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Kindergartens == null)
            {
                return NotFound();
            }

            var kindergarten = _context.Kindergartens
                .FirstOrDefault(m => m.Id == id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            // Преобразуем доменную модель в ViewModel для передачи в представление
            var viewModel = new ShopTARgv23.Models.Kindergarten.KindergartenViewModel
            {
                Id = kindergarten.Id,
                KindergartenName = kindergarten.KindergartenName,
                GroupName = kindergarten.GroupName,
                ChildrenCount = kindergarten.ChildrenCount,
                Teacher = kindergarten.Teacher
            };

            return View(viewModel);
        }

        // POST: Kindergarten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var kindergarten = _context.Kindergartens.Find(id);

            if (kindergarten != null)
            {
                _context.Kindergartens.Remove(kindergarten);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}