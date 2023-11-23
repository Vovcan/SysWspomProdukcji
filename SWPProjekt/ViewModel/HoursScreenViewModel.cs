using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using SWPProjekt.Model;

namespace SWPProjekt.ViewModel
{
    class HoursScreenViewModel : BaseViewModel
    {
        public MainViewModel MainModel { get; set; }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();
        public List<User>? Employees { get; set; }
        public DateTime TodayDate { get; set; }

        DateTime today = DateTime.Today;

        DateTime Nextday = DateTime.Today.AddDays(1);
        public HoursScreenViewModel(MainViewModel mainModel) 
        {
            MainModel = mainModel;
            var allUsers = context.Users.Where(user => user.JobTitleid == 5).ToList();
            var usersWithTasks = context.TaskUsers
    .Where(taskUser => taskUser.Task.FinishDate == today)
    .Select(taskUser => taskUser.User)
    .ToList();
            Employees = allUsers.Intersect(usersWithTasks).ToList();
            var usersWithWorkingHoursToday = context.WorkingHours
    .Where(wh => wh.Date == DateTime.Today)
    .Select(wh => wh.User)
    .Distinct()
    .ToList();
            Employees = Employees.Except(usersWithWorkingHoursToday).ToList();
            TodayDate = today;

        }
    }
}
