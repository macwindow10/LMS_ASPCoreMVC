using LMS.Data;
using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses
                .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student)
                .ToListAsync();

            return View(courses);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Enrollments)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
                return NotFound();

            ViewBag.Students = new MultiSelectList(_context.Students, "Id", "Name");
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, int[] selectedStudents)
        {
            var course = await _context.Courses
                .Include(c => c.Enrollments)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
                return NotFound();

            course.Enrollments.Clear();
            foreach (var studentId in selectedStudents)
            {
                course.Enrollments.Add(new Enrollment
                {
                    CourseID = course.Id,
                    StudentID = studentId
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
