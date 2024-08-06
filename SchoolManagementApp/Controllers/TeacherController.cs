using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Application.Dto;
using SchoolManagementApp.Infrastructure.Interface;

namespace SchoolManagementApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeacherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var teacher = _unitOfWork.teacherRepositry.GetAll();
            return View(teacher);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeacherDto teacherDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.teacherRepositry.CreateTeacherAsync(teacherDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error: ", ex.Message);
                }
            }
            return View(teacherDto);
        }
    }
}

