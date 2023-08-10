using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using DataAccess.Repositorys.MajorRepository;
using DataAccess.Repositorys.StudentRepository;

namespace RazorPages.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMajorRepository majorRepository;
        public EditModel(IStudentRepository _studentRepository, IMajorRepository _majorRepository)
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
            Student = student;
           ViewData["MajorId"] = new SelectList(majorRepository.GetAll(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                studentRepository.CreateOrUpdate(Student);
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }

            return RedirectToPage("./Index");
        }

        private bool StudentExists(int id)
        {
          return studentRepository.GetById(id) != null;
        }
    }
}
