using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TestingFormsDotNet_3_1.Data.Entities;
using TestingFormsDotNet_3_1.Models.Entities;

namespace TestingFormsDotNet_3_1.Controllers
{
    public class FormControlFormsController : Controller
    {
        private readonly FormsContext _context;

        public FormControlFormsController(FormsContext context)
        {
            _context = context;
        }

        // GET: FormControlForms
        public async Task<IActionResult> Index()
        {
            var formsContext = _context.FormControlForms.Include(f => f.FormControlNavigation).Include(f => f.FormNavigation);
            return View(await formsContext.ToListAsync());
        }

        // GET: FormControlForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formControlForm = await _context.FormControlForms
                .Include(f => f.FormControlNavigation)
                .Include(f => f.FormNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formControlForm == null)
            {
                return NotFound();
            }

            return View(formControlForm);
        }

        // GET: FormControlForms/Create
        public IActionResult Create()
        {
            ViewData["FormControlId"] = new SelectList(_context.FormControls, "Id", "Id");
            ViewData["FormId"] = new SelectList(_context.Forms, "Id", "Id");
            return View();
        }

        // POST: FormControlForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormId,FormControlId,Id,Rowversion,CreatedBy,Created,ModifiedBy,Modified,IsActive,InActivated,InActivatedBy")] FormControlForm formControlForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formControlForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormControlId"] = new SelectList(_context.FormControls, "Id", "Id", formControlForm.FormControlId);
            ViewData["FormId"] = new SelectList(_context.Forms, "Id", "Id", formControlForm.FormId);
            return View(formControlForm);
        }

        // GET: FormControlForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formControlForm = await _context.FormControlForms.FindAsync(id);
            if (formControlForm == null)
            {
                return NotFound();
            }
            ViewData["FormControlId"] = new SelectList(_context.FormControls, "Id", "Id", formControlForm.FormControlId);
            ViewData["FormId"] = new SelectList(_context.Forms, "Id", "Id", formControlForm.FormId);
            return View(formControlForm);
        }

        // POST: FormControlForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FormControlForm formControlForm)
        {
            if (id != formControlForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingEntity = _context.FormControlForms.Where(x => x.Id == id).FirstOrDefault();
                    existingEntity.IsActive = formControlForm.IsActive;
                    _context.Update(existingEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormControlFormExists(formControlForm.Id))
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
            ViewData["FormControlId"] = new SelectList(_context.FormControls, "Id", "Id", formControlForm.FormControlId);
            ViewData["FormId"] = new SelectList(_context.Forms, "Id", "Id", formControlForm.FormId);
            return View(formControlForm);
        }

        // GET: FormControlForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formControlForm = await _context.FormControlForms
                .Include(f => f.FormControlNavigation)
                .Include(f => f.FormNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formControlForm == null)
            {
                return NotFound();
            }

            return View(formControlForm);
        }

        // POST: FormControlForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formControlForm = await _context.FormControlForms.FindAsync(id);
            _context.FormControlForms.Remove(formControlForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormControlFormExists(int id)
        {
            return _context.FormControlForms.Any(e => e.Id == id);
        }
    }
}
