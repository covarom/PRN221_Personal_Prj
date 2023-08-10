using DataAccess.Repositorys.AccountRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Auth
{
    public class LoginModel : PageModel
    {
            private readonly IAccountRepository _accountRepository;

            public LoginModel(IAccountRepository accountRepository)
            {
            this._accountRepository = accountRepository;
            }

             [BindProperty]
            public string Username { get; set; }

            [BindProperty]
            public string Password { get; set; }

            public void OnGet()
            {
            }

            public async Task<IActionResult> OnPost()
            {
                 var user = _accountRepository.GetByUsername(Username);
                try
                {
                if (user != null && user.Password == Password)
                {
                    HttpContext.Session.SetString("LoggedInUser", user.Username);
                    return RedirectToPage("/Students/Index"); // Chuyển hướng đến trang dashboard sau khi đăng nhập thành công
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt."); // Thêm lỗi vào ModelState
                    return Page();
                }
                 }
                catch (Exception ex)
                {
                    ViewData["Message"] = ex.Message;
                    return Page();
                }


        }

    }
}
