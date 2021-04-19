using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TestingFormsDotNet_3_1.Data.Entities;
using TestingFormsDotNet_3_1.Models.Entities;

namespace TestingFormsDotNet_3_1.Controllers
{
    public class MannerOfDeathTypesController : Controller
    {
        private readonly FormsContext _context;

        public MannerOfDeathTypesController(FormsContext context)
        {
            _context = context;
        }

        // GET: MannerOfDeathTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MannerOfDeathTypes.ToListAsync());
        }

        // GET: MannerOfDeathTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mannerOfDeathType = await _context.MannerOfDeathTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mannerOfDeathType == null)
            {
                return NotFound();
            }

            return View(mannerOfDeathType);
        }

        // GET: MannerOfDeathTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MannerOfDeathTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] MannerOfDeathType mannerOfDeathType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mannerOfDeathType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mannerOfDeathType);
        }

        // GET: MannerOfDeathTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mannerOfDeathType = await _context.MannerOfDeathTypes.FindAsync(id);
            if (mannerOfDeathType == null)
            {
                return NotFound();
            }
            return View(mannerOfDeathType);
        }

        // POST: MannerOfDeathTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] MannerOfDeathType mannerOfDeathType)
        {
            if (id != mannerOfDeathType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mannerOfDeathType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MannerOfDeathTypeExists(mannerOfDeathType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mannerOfDeathType);
        }

        // GET: MannerOfDeathTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mannerOfDeathType = await _context.MannerOfDeathTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mannerOfDeathType == null)
            {
                return NotFound();
            }

            return View(mannerOfDeathType);
        }

        // POST: MannerOfDeathTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mannerOfDeathType = await _context.MannerOfDeathTypes.FindAsync(id);
            _context.MannerOfDeathTypes.Remove(mannerOfDeathType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MannerOfDeathTypeExists(int id)
        {
            return _context.MannerOfDeathTypes.Any(e => e.Id == id);
        }
    }
}
