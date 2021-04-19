using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TestingFormsDotNet_3_1.Data.Entities;
using TestingFormsDotNet_3_1.Models.Entities;

namespace TestingFormsDotNet_3_1.Controllers
{
    public class FormDataTypesController : Controller
    {
        private readonly FormsContext _context;

        public FormDataTypesController(FormsContext context)
        {
            _context = context;
        }

        // GET: FormDataTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormDataTypes.ToListAsync());
        }

        // GET: FormDataTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formDataType = await _context.FormDataTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formDataType == null)
            {
                return NotFound();
            }

            return View(formDataType);
        }

        // GET: FormDataTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormDataTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FormDataType formDataType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formDataType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formDataType);
        }

        // GET: FormDataTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formDataType = await _context.FormDataTypes.FindAsync(id);
            if (formDataType == null)
            {
                return NotFound();
            }
            return View(formDataType);
        }

        // POST: FormDataTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FormDataType formDataType)
        {
            if (id != formDataType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formDataType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormDataTypeExists(formDataType.Id))
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
            return View(formDataType);
        }

        // GET: FormDataTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formDataType = await _context.FormDataTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formDataType == null)
            {
                return NotFound();
            }

            return View(formDataType);
        }

        // POST: FormDataTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formDataType = await _context.FormDataTypes.FindAsync(id);
            _context.FormDataTypes.Remove(formDataType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormDataTypeExists(int id)
        {
            return _context.FormDataTypes.Any(e => e.Id == id);
        }
    }
}
