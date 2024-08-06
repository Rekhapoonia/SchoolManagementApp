using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementApp.Application.Dto;
using SchoolManagementApp.Infrastructure.Interface;
using SchoolManagementApp.Infrastructure.Repositories;

namespace SchoolManagementApp.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var subject = _unitOfWork.subjectRepository.GetAll();
            return View(subject);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Students = new SelectList(_unitOfWork.studentRepository.GetAll(), "Id", "Name");
            ViewBag.Teachers = new SelectList( _unitOfWork.teacherRepositry.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubjectDto subjectDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.subjectRepository.CreateSubjectAsync(subjectDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error: ", ex.Message);
                }
            }
            return View(subjectDto);
        }
    }
}
