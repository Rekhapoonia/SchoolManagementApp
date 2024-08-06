using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.Application.Dto;
using SchoolManagementApp.Infrastructure.Interface;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index(string searchString)
        {
            var student = _unitOfWork.studentRepository.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                student = student.Where(s => s.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentDto studentDto)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.studentRepository.CreateStudentAsync(studentDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error: ", ex.Message);
                }
            }
            return View(studentDto);
        }
    }
}
