using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TestingFormsDotNet_3_1.Data.Entities;
using TestingFormsDotNet_3_1.Models.Entities;

namespace TestingFormsDotNet_3_1.Controllers
{
    public class MannerOfDeathSubTypesController : Controller
    {
        private readonly FormsContext _context;

        public MannerOfDeathSubTypesController(FormsContext context)
        {
            _context = context;
        }

        // GET: MannerOfDeathSubTypes
        public async Task<IActionResult> Index()
        {
            var formsContext = _context.MannerOfDeathSubTypes.Include(m => m.MannerOfDeathTypeNavigation);
            return View(await formsContext.ToListAsync());
        }

        // GET: MannerOfDeathSubTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mannerOfDeathSubType = await _context.MannerOfDeathSubTypes
                .Include(m => m.MannerOfDeathTypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mannerOfDeathSubType == null)
            {
                return NotFound();
            }

            return View(mannerOfDeathSubType);
        }

        // GET: MannerOfDeathSubTypes/Create
        public IActionResult Create()
        {
            ViewData["MannerOfDeathTypeId"] = new SelectList(_context.MannerOfDeathTypes, "Id", "Id");
            return View();
        }

        // POST: MannerOfDeathSubTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MannerOfDeathTypeId,Name")] MannerOfDeathSubType mannerOfDeathSubType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mannerOfDeathSubType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MannerOfDeathTypeId"] = new SelectList(_context.MannerOfDeathTypes, "Id", "Id", mannerOfDeathSubType.MannerOfDeathTypeId);
            return View(mannerOfDeathSubType);
        }

        // GET: MannerOfDeathSubTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mannerOfDeathSubType = await _context.MannerOfDeathSubTypes.FindAsync(id);
            if (mannerOfDeathSubType == null)
            {
                return NotFound();
            }
            ViewData["MannerOfDeathTypeId"] = new SelectList(_context.MannerOfDeathTypes, "Id", "Id", mannerOfDeathSubType.MannerOfDeathTypeId);
            return View(mannerOfDeathSubType);
        }

        // POST: MannerOfDeathSubTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MannerOfDeathTypeId,Name")] MannerOfDeathSubType mannerOfDeathSubType)
        {
            if (id != mannerOfDeathSubType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mannerOfDeathSubType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MannerOfDeathSubTypeExists(mannerOfDeathSubType.Id))
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
            ViewData["MannerOfDeathTypeId"] = new SelectList(_context.MannerOfDeathTypes, "Id", "Id", mannerOfDeathSubType.MannerOfDeathTypeId);
            return View(mannerOfDeathSubType);
        }

        // GET: MannerOfDeathSubTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mannerOfDeathSubType = await _context.MannerOfDeathSubTypes
                .Include(m => m.MannerOfDeathTypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mannerOfDeathSubType == null)
            {
                return NotFound();
            }

            return View(mannerOfDeathSubType);
        }

        // POST: MannerOfDeathSubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mannerOfDeathSubType = await _context.MannerOfDeathSubTypes.FindAsync(id);
            _context.MannerOfDeathSubTypes.Remove(mannerOfDeathSubType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MannerOfDeathSubTypeExists(int id)
        {
            return _context.MannerOfDeathSubTypes.Any(e => e.Id == id);
        }
    }
}
