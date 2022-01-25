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
                Works = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.Date.Day).ToList();
                First = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.Date.Day + 1).ToList();
                Second = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.Date.Day+2).ToList();
                Third = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.Date.Day+3).ToList();
                Four = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.Date.Day+4).ToList();
                Five = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.Date.Day+5).ToList();
                Six = _context.Work.Where(d => d.WorkUser == userss && d.Data.Day == DateTime.Now.Date.Day+6).ToList();

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
            int main = DateTime.Now.Date.Day - 1;
            DateTime dateValue = DateTime.Now.Date;
            int Month = DateTime.Now.Month;
            Console.WriteLine(Month);
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
            int Day = main + end;
            if (Day == 32)
            {
                Day = 1;
                Month += 1;
            }
            else if( Day == 33)
            {
                Day = 2;
                Month += 1;
            }
            else if (Day == 34)
            {
                Day = 3;
                Month += 1;
            }
            else if (Day == 35)
            {
                Day = 3;
                Month += 1;
            }
            var savawork = new Work()
            {
                WorkUser = userss,
                WorkDo = Doing.WorkDo,
                Data = DateTime.Parse($"{Month}-{Day}-2022"),
            };
            _context.Work.Add(savawork);
            _context.SaveChanges();
            return RedirectToPage("./Index");




        }
        public void test()
        {
            Console.WriteLine("Okkkkkkkkkkkkkkkk");
        }
    public IActionResult deletedef(int id)
        {
            Doing = _context.Work.Find(id);
            _context.Work.Remove(Doing);
            _context.SaveChanges();
            return RedirectToPage("./index");

        }

    }
}