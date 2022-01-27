using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using WeeklyPlanning.Areas.Identity.Data;
using WeeklyPlanning.Models;

namespace WeeklyPlanning.Pages
{
    public class IndexModel : PageModel
    {
        public UserManager<WeeklyPlanningUser> usermanage;
        public SignInManager<WeeklyPlanningUser> signmange;
        private readonly WeeklyPlanning.Data.WeeklyPlanningContext _context;

        public IndexModel(WeeklyPlanning.Data.WeeklyPlanningContext context,
            UserManager<WeeklyPlanningUser> userManager,
            SignInManager<WeeklyPlanningUser> signInManager)
        {
            _context = context;
            usermanage = userManager;
            signmange = signInManager;
        }
    public IList<Work> Works { get; set; }
    public IList<Work> WeekDays { get; set; }
    public IList<Work> First { get; set; }
    public IList<Work> Second { get; set; }
    public IList<Work> Third { get; set; }
    public IList<Work> Four { get; set; }
    public IList<Work> Five { get; set; }
    public IList<Work> Six{ get; set; }
    public bool Exist{ get; set; }
        public IActionResult OnGet()
        {
		if (signmange.IsSignedIn(User))
            {
                var userss = usermanage.GetUserName(User);
                var date = DateTime.Now.Date.DayOfWeek;

                //Send the data next days 
                Works = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.Day).ToList();
                First = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.AddDays(1).Day).ToList();
                Second = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.AddDays(2).Day).ToList();
                Third = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.AddDays(3).Day).ToList();
                Four = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.AddDays(4).Day).ToList();
                Five = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.AddDays(5).Day).ToList();
                Six = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.AddDays(6).Day).ToList();

                Exist = _context.Work.Where(d => d.WorkUser == userss).Any();

                return Page();
            }
	    return Page();
        }
	[BindProperty]
        public Work Doing { get; set; }
        public int count { get; set; }
        public IActionResult OnPostAsync(int name)
	{
            DateTime dateValue = DateTime.Now.Date;
            Console.WriteLine("------------------------");
            Console.WriteLine("------------------------");
            int total = (int)dateValue.DayOfWeek;
            Console.WriteLine(total);
            var userss = usermanage.GetUserName(User);

            //Get date of the next days
            int end;
            if (name - total > 0)
            {
                end = name - total;
            }
            else
            {
                end = 7 - Math.Abs(name - total);
            }
            DateTime day = DateTime.Now.AddDays(end-1);

            //Save Data
            var savawork = new Work()
            {
                WorkUser = userss,
                WorkDo = Doing.WorkDo,
                Data = day.Date,
            };
            _context.Work.Add(savawork);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }

    }
}
