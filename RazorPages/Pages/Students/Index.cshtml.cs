using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using DataAccess.Repositorys.StudentRepository;

namespace RazorPages.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentRepository studentRepository;

        public IndexModel(IStudentRepository _studentRepository)
        {
            this.studentRepository = _studentRepository;
        }
        public IList<BussinessObject.Models.Student> Student { get;set; } = default!;

        public async Task OnGet()
        {
            try
            {
                Student = studentRepository.GetAll();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return;
            }
         
 
        }
    }
}
