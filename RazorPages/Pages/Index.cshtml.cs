using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using System;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; private set; } = "Loading ...";

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("LoggedInUser") == null)
            {
                return RedirectToPage("/Auth/Login");
            }

            return Page();        
        }
    }
}
