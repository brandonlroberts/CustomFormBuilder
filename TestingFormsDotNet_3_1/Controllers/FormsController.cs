using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingFormsDotNet_3_1.Data.Entities;
using TestingFormsDotNet_3_1.Models.Entities;

namespace TestingFormsDotNet_3_1.Controllers
{
    public class FormsController : Controller
    {
        private readonly FormsContext _context;

        public FormsController(FormsContext context)
        {
            _context = context;
        }

        // GET: Forms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Forms.ToListAsync());
        }

        // GET: Forms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vm = new Form() { FormControlForms = new List<FormControlForm>() };
            var form = await _context.Forms.FindAsync(id);
            form.FormControlForms = _context.FormControlForms
                .Include(x => x.FormControlNavigation)
                .Include(x => x.FormNavigation)
                .Where(x => x.FormId == id.Value)
                .OrderBy(x => x.Order)
                .ToList();
            if (form == null)
            {
                return NotFound();
            }
            vm.Name = form.Name;
            vm.Id = form.Id;
            vm.Rowversion = form.Rowversion;
            foreach (var item in form.FormControlForms)
            {
                vm.FormControlForms.Add(new FormControlForm()
                {
                    FormControlNavigation = new FormControl()
                    {
                        FormSectionId = item.FormControlNavigation.FormSectionId,
                        FormName = item.FormControlNavigation.FormName,
                        IsActive = item.FormControlNavigation.IsActive,
                        FormDataTypeId = item.FormControlNavigation.FormDataTypeId
                    },
                    IsActive = item.IsActive
                });
            }

            return View(vm);
        }

        // GET: Forms/Create
        public IActionResult Create()
        {
            var formControls = _context.FormControls.OrderBy(x => x.Order);
            var vm = new Form();
            vm.FormControlForms = new List<FormControlForm>();

            foreach (var item in formControls)
            {
                vm.FormControlForms.Add(new FormControlForm()
                {
                    FormControlNavigation = new FormControl()
                    {
                        Id = item.Id,
                        FormSectionId = item.FormSectionId,
                        FormName = item.FormName,
                        IsActive = item.IsActive,
                        FormDataTypeId = item.FormDataTypeId,
                    },
                    IsActive = item.IsActive,
                    Order = item.Order
                });
            }

            return View(vm);
        }

        // POST: Forms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Form form)
        {
            if (ModelState.IsValid)
            {
                var formControlForms = new List<FormControlForm>();
                var newForm = new Form();
                newForm.Name = form.Name;
                _context.Forms.Add(newForm);
                await _context.SaveChangesAsync();

                for (int i = 0; i < form.FormControlForms.Count(); i++)
                {
                    formControlForms.Add(new FormControlForm()
                    {
                        FormId = newForm.Id,
                        FormControlId = form.FormControlForms[i].FormControlNavigation.Id,
                        IsActive = form.FormControlForms[i].IsActive,
                        Order = form.FormControlForms[i].Order
                    });
                }

                _context.FormControlForms.AddRange(formControlForms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }

        // GET: Forms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vm = new Form() { FormControlForms = new List<FormControlForm>() };
            var form = await _context.Forms.FindAsync(id);
            form.FormControlForms = _context.FormControlForms
                .Include(x => x.FormControlNavigation)
                .Include(x => x.FormNavigation)
                .Where(x => x.FormId == id.Value)
                .OrderBy(x => x.FormControlNavigation.Order)
                .ToList();
            if (form == null)
            {
                return NotFound();
            }
            vm.Name = form.Name;
            vm.Id = form.Id;
            vm.Rowversion = form.Rowversion;
            foreach (var item in form.FormControlForms)
            {
                vm.FormControlForms.Add(new FormControlForm()
                {
                    FormControlNavigation = new FormControl()
                    {
                        FormSectionId = item.FormControlNavigation.FormSectionId,
                        FormName = item.FormControlNavigation.FormName,
                        IsActive = item.FormControlNavigation.IsActive,
                        FormDataTypeId = item.FormControlNavigation.FormDataTypeId
                    },
                    IsActive = item.IsActive,
                    Order = item.Order
                });
            }

            //var vm = new FormViewModel() { FormControlForms = new List<FormControlFormViewModel>() };
            //var form = await _context.Forms.FindAsync(id);
            //form.FormControlForms = _context.FormControlForms
            //    .Include(x => x.FormControlNavigation)
            //    .Include(x => x.FormNavigation)
            //    .Where(x => x.FormId == id.Value)
            //    .OrderBy(x => x.FormControlNavigation.Order)
            //    .ToList();
            //if (form == null)
            //{
            //    return NotFound();
            //}
            //vm.Name = form.Name;
            //vm.Id = form.Id;
            //vm.Rowversion = form.Rowversion;
            //foreach (var item in form.FormControlForms)
            //{
            //    vm.FormControlForms.Add(new FormControlFormViewModel()
            //    {
            //        FormControlNavigation = new FormControlNavigationViewModel()
            //        {
            //            FormSectionId = item.FormControlNavigation.FormSectionId,
            //            FormName = item.FormControlNavigation.FormName,
            //            IsActive = item.FormControlNavigation.IsActive,
            //            FormDataTypeId = item.FormControlNavigation.FormDataTypeId
            //        },
            //        IsActive = item.IsActive,
            //        FormOrder = item.Order
            //    });
            //}

            return View(vm);
        }

        // POST: Forms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Form form)
        {
            if (id != form.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var formControlForms = _context.FormControlForms.Where(x => x.FormId == id).Include(x => x.FormControlNavigation).OrderBy(x => x.FormControlNavigation.Order).ToList();
                    var existingForm = await _context.Forms.FindAsync(id);

                    existingForm.Name = form.Name;
                    _context.Forms.Update(existingForm);

                    for (int i = 0; i < formControlForms.Count(); i++)
                    {
                        formControlForms[i].IsActive = form.FormControlForms[i].IsActive;
                        formControlForms[i].Order = form.FormControlForms[i].Order;
                    }

                    _context.FormControlForms.UpdateRange(formControlForms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormExists(form.Id))
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
            return View(form);
        }

        // GET: Forms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Forms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // POST: Forms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var form = await _context.Forms.FindAsync(id);
            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormExists(int id)
        {
            return _context.Forms.Any(e => e.Id == id);
        }
    }
}
