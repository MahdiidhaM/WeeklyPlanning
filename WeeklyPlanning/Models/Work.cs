using System.ComponentModel.DataAnnotations;
//using DailyWork.Areas.Identity.Pages.Account;

namespace WeeklyPlanning.Models
{
    public class Work
    {
        [Key]
        public int ID { get; set; }
        public string WorkDo { get; set; }
        public string WorkUser { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}
