using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using DataAccess.Repositorys.MajorRepository;
using DataAccess.Repositorys.StudentRepository;

namespace RazorPages.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMajorRepository majorRepository;
        public DeleteModel(IStudentRepository _studentRepository, IMajorRepository _majorRepository)
        {
            this.studentRepository = _studentRepository;
            this.majorRepository = _majorRepository;
        }

        [BindProperty]
      public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || studentRepository.GetAll() == null)
            {
                return NotFound();
            }

            var student = studentRepository.GetById(id);

            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = student;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                if (id == null || studentRepository.GetAll() == null)
                {
                    return NotFound();
                }
                var student = studentRepository.GetById(id);

                if (student != null)
                {
                    studentRepository.Delete(id);
                }

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ViewData["Message"] = "Sinh viên này đang nằm trong khóa học";
                return Page();
            }
        }
    }
}
