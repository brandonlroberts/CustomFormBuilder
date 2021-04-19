using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TestingFormsDotNet_3_1.Data.Entities;
using TestingFormsDotNet_3_1.Models.Entities;

namespace TestingFormsDotNet_3_1.Controllers
{
    public class FormControlsController : Controller
    {
        private readonly FormsContext _context;

        public FormControlsController(FormsContext context)
        {
            _context = context;
        }

        // GET: FormControls
        public async Task<IActionResult> Index()
        {
            var formsContext = _context.FormControls.Include(f => f.FormDataType).Include(f => f.FormSectionNavigation);
            return View(await formsContext.ToListAsync());
        }

        // GET: FormControls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formControl = await _context.FormControls
                .Include(f => f.FormDataType)
                .Include(f => f.FormSectionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formControl == null)
            {
                return NotFound();
            }

            return View(formControl);
        }

        // GET: FormControls/Create
        public IActionResult Create()
        {
            ViewData["FormDataTypeId"] = new SelectList(_context.FormDataTypes, "Id", "Id");
            ViewData["FormSectionId"] = new SelectList(_context.FormSections, "Id", "Id");
            return View();
        }

        // POST: FormControls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,FormSectionId,FormDataTypeId,IsVisible,Order,CssClass,Id,Rowversion,CreatedBy,Created,ModifiedBy,Modified,IsActive,InActivated,InActivatedBy")] FormControl formControl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formControl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormDataTypeId"] = new SelectList(_context.FormDataTypes, "Id", "Id", formControl.FormDataTypeId);
            ViewData["FormSectionId"] = new SelectList(_context.FormSections, "Id", "Id", formControl.FormSectionId);
            return View(formControl);
        }

        // GET: FormControls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formControl = await _context.FormControls.FindAsync(id);
            if (formControl == null)
            {
                return NotFound();
            }
            ViewData["FormDataTypeId"] = new SelectList(_context.FormDataTypes, "Id", "Id", formControl.FormDataTypeId);
            ViewData["FormSectionId"] = new SelectList(_context.FormSections, "Id", "Id", formControl.FormSectionId);
            return View(formControl);
        }

        // POST: FormControls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,FormSectionId,FormDataTypeId,IsVisible,Order,CssClass,Id,Rowversion,CreatedBy,Created,ModifiedBy,Modified,IsActive,InActivated,InActivatedBy")] FormControl formControl)
        {
            if (id != formControl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formControl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormControlExists(formControl.Id))
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
            ViewData["FormDataTypeId"] = new SelectList(_context.FormDataTypes, "Id", "Id", formControl.FormDataTypeId);
            ViewData["FormSectionId"] = new SelectList(_context.FormSections, "Id", "Id", formControl.FormSectionId);
            return View(formControl);
        }

        // GET: FormControls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formControl = await _context.FormControls
                .Include(f => f.FormDataType)
                .Include(f => f.FormSectionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formControl == null)
            {
                return NotFound();
            }

            return View(formControl);
        }

        // POST: FormControls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formControl = await _context.FormControls.FindAsync(id);
            _context.FormControls.Remove(formControl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormControlExists(int id)
        {
            return _context.FormControls.Any(e => e.Id == id);
        }
    }
}
