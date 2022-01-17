using WeeklyPlanning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WeeklyPlanning.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WeeklyPlanning.Data.WeeklyPlanningContext _context;

        public DeleteModel(WeeklyPlanning.Data.WeeklyPlanningContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Work Work { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Work = await _context.Work.FindAsync(id);

            if (Work != null)
            {
                _context.Work.Remove(Work);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}
