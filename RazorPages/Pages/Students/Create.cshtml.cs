using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject.Models;
using DataAccess.Repositorys.StudentRepository;
using DataAccess.Repositorys.MajorRepository;

namespace RazorPages.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMajorRepository majorRepository;
        public CreateModel(IStudentRepository _studentRepository, IMajorRepository _majorRepository)
        {
            this.studentRepository = _studentRepository;
            this.majorRepository = _majorRepository;
        }

        public IActionResult OnGet()
        {
        ViewData["MajorId"] = new SelectList(majorRepository.GetAll(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || studentRepository.GetAll() == null || Student == null)
            {
                return Page();
            }

            studentRepository.CreateOrUpdate(Student);

            return RedirectToPage("./Index");
        }
    }
}
