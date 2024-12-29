using ClassesWebsite.Models;
using ClassesWebsite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassesWebsite.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index(string searchString, string sortOrder, int page = 1)
        {
            // Get students from the database, sorted alphabetically
            var students = await _studentService.GetAll();

            // Search functionality: Filter students by name
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Sorting functionality: Sort by Name or other fields
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name).ToList();
                    break;
                case "name_asc":
                default:
                    students = students.OrderBy(s => s.Name).ToList();
                    break;
            }

            // Pagination: Only show 5 students per page
            int pageSize = 5;
            var pagedStudents = students.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Passing data to the view
            var totalStudents = students.Count();
            var model = new StudentIndexViewModel
            {
                Students = pagedStudents,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)totalStudents / pageSize),
                SearchString = searchString,
                SortOrder = sortOrder
            };

            return View(model);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.AddAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _studentService.UpdateAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null) return NotFound();

            await _studentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
