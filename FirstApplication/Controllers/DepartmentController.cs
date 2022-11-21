using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstApplication.Data;
using FirstApplication.Models;

namespace FirstApplication.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DataContext _context;

        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        // GET: Department
        public IActionResult Index()
        {
            var Department=_context.Department.ToList();
              return View(Department);
        }

        // GET: Department/Details/5
        public IActionResult Details(int? id)
        {


            var department = _context.Department.Where(m => m.DepartmentId == id).FirstOrDefault();

            return View(department);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create( Department department)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(department);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            //}
            //return View(department);
        }

        // GET: Department/Edit/5
        public IActionResult Edit(int? id)
        {
            //if (id == null || _context.Department == null)
            //{
            //    return NotFound();
            //}

            var department = _context.Department.Where(x=>x.DepartmentId==id).FirstOrDefault();
            //if (department == null)
            //{
            //    return NotFound();
            //}
            return View(department);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(Department department)
        {
            //if (id != department.DepartmentId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
                    _context.Update(department);
                    _context.SaveChanges();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!DepartmentExists(department.DepartmentId))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction("Index");
            //}
            //return View(department);
        }

        // GET: Department/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department =_context.Department
                .FirstOrDefault(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Department == null)
            {
                return Problem("Entity set 'DataContext.Department'  is null.");
            }
            var department = await _context.Department.FindAsync(id);
            if (department != null)
            {
                _context.Department.Remove(department);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
          return _context.Department.Any(e => e.DepartmentId == id);
        }
    }
}
