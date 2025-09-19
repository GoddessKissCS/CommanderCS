using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GameCMS.Pages.Admin
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string MemberId { get; set; }
        
        [BindProperty]
        public string Password { get; set; }
        
        public string LoginMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<JsonResult> OnPostLoginAsync(string memberId, string password)
        {
            // In a real application, this would query your database
            var account = await AuthenticateUser(memberId, password);
            
            if (account != null && (account.Clearance == Clearance.Administrator || account.Clearance == Clearance.Owner))
            {
                // Set session or authentication cookie
                HttpContext.Session.SetString("IsAuthenticated", "true");
                HttpContext.Session.SetString("MemberId", memberId);
                
                return new JsonResult(new { success = true });
            }
            
            return new JsonResult(new { success = false, message = "Invalid credentials or insufficient clearance" });
        }

      

        private async Task<AccountScheme> AuthenticateUser(string memberId, string password)
        {
            var account = DatabaseManager.Account.LoginAdminIntoCMS(memberId, password);

            return account;
        }
    }
}