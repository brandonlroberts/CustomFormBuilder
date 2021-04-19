using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TestingFormsDotNet_3_1.Data.Entities;
using TestingFormsDotNet_3_1.Models.Entities;

namespace TestingFormsDotNet_3_1.Controllers
{
    public class FormSectionsController : Controller
    {
        private readonly FormsContext _context;

        public FormSectionsController(FormsContext context)
        {
            _context = context;
        }

        // GET: FormSections
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormSections.ToListAsync());
        }

        // GET: FormSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formSection = await _context.FormSections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formSection == null)
            {
                return NotFound();
            }

            return View(formSection);
        }

        // GET: FormSections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FormSection formSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formSection);
        }

        // GET: FormSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formSection = await _context.FormSections.FindAsync(id);
            if (formSection == null)
            {
                return NotFound();
            }
            return View(formSection);
        }

        // POST: FormSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FormSection formSection)
        {
            if (id != formSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormSectionExists(formSection.Id))
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
            return View(formSection);
        }

        // GET: FormSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formSection = await _context.FormSections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formSection == null)
            {
                return NotFound();
            }

            return View(formSection);
        }

        // POST: FormSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formSection = await _context.FormSections.FindAsync(id);
            _context.FormSections.Remove(formSection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormSectionExists(int id)
        {
            return _context.FormSections.Any(e => e.Id == id);
        }
    }
}
