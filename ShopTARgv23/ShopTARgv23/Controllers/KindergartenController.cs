using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Data;
using ShopTARgv23.Models.Kindergarten;

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

            return View(kindergarten);
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
