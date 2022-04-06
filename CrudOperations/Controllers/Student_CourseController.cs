using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudOperations.Models;
using CrudOperations.Models.Database;

namespace CrudOperations.Controllers
{
    public class Student_CourseController : Controller
    {
        private readonly DatabaseModel _context;

        public Student_CourseController(DatabaseModel context)
        {
            _context = context;
        }

        // GET: Student_Course
        public async Task<IActionResult> Index()
        {
            var databaseModel = _context.Student_Course.Include(s => s.Course).Include(s => s.Student);
            return View(await databaseModel.ToListAsync());
        }

        // GET: Student_Course/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Course = await _context.Student_Course
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student_Course == null)
            {
                return NotFound();
            }

            return View(student_Course);
        }

        // GET: Student_Course/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentName");
            return View();
        }

        // POST: Student_Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,CourseId,Degree")] Student_Course student_Course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student_Course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", student_Course.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentName", student_Course.StudentId);
            return View(student_Course);
        }

        // GET: Student_Course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Course = await _context.Student_Course.FindAsync(id);
            if (student_Course == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", student_Course.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentName", student_Course.StudentId);
            return View(student_Course);
        }

        // POST: Student_Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,CourseId,Degree")] Student_Course student_Course)
        {
            if (id != student_Course.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student_Course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student_CourseExists(student_Course.StudentId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", student_Course.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentName", student_Course.StudentId);
            return View(student_Course);
        }

        // GET: Student_Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Course = await _context.Student_Course
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student_Course == null)
            {
                return NotFound();
            }

            return View(student_Course);
        }

        // POST: Student_Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student_Course = await _context.Student_Course.FindAsync(id);
            _context.Student_Course.Remove(student_Course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Student_CourseExists(int id)
        {
            return _context.Student_Course.Any(e => e.StudentId == id);
        }
    }
}
