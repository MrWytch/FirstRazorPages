using FirstRazorPagesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FirstRazorPagesApp.Pages
{
    public class CreditsPageModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreditsPageModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty(Name = "rating")]
        public int Rating { get; set; }

        [BindProperty(Name = "success")]
        public bool Success { get; set; }

        public IList<CreditsModel> LstCredits { get; set; } = default!;

        public async Task<IActionResult> OnPostSaveDataAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var credit = new CreditsModel
            {
                Created = DateTime.Now,
                Value = Rating,
                Success = Success
                
            };

            
            _context.Credits.Add(credit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./CreditsPage");      
        }

        public async Task OnGetAsync()
        {
            if (_context.Credits != null)
            {
                LstCredits = await _context.Credits.ToListAsync();
            }
        }
    }
}
