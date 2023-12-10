using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NPOI.SS.Formula.Functions;
using SWPProjekt.Helpers;
using SWPProjekt.Model;

namespace SWPProjekt.ViewModel
{
    class HoursScreenViewModel : BaseViewModel
    {
        public MainViewModel MainModel { get; set; }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();
        public List<User>? Employees { get; set; }
        public List<CombinedUser> combinedUsers { get; set; }
        public DateTime TodayDate { get; set; }

        public RelayCommand CreateNewWorkingHours { get; set; }

        DateTime today = DateTime.Today;

        DateTime Nextday = DateTime.Today.AddDays(1);

        public void TableGenerator(List<CombinedUser> combinedUsers)
        {
            var usersWithTasks1 = context.TaskUsers
    .Where(taskUser => taskUser.Task.FinishDate == today && taskUser.User.JobTitleid!=2)
    .Select(taskUser => Tuple.Create(taskUser.User, taskUser.Task))
    .ToList();

            for (int i = 0; i < usersWithTasks1.Count; i++)
            {
                
                CombinedUser a = new CombinedUser(usersWithTasks1[i].Item1.Id, usersWithTasks1[i].Item1.Name, usersWithTasks1[i].Item1.Surname, usersWithTasks1[i].Item1.JobTitleid, usersWithTasks1[i].Item2.Name, usersWithTasks1[i].Item2.Id);
                combinedUsers.Add(a);
            }
        }

        public void CreateNewWorkingHoursFu(object a)
        {
            List<CombinedUser> sortedAndFilteredUsers = combinedUsers
            .Where(user => user.HoursNumber != 0)
            .OrderBy(user => user.HoursNumber)
            .ToList();
            List<WorkingHour> ListToAdd = new List<WorkingHour>();
            for(int i = 0;i < sortedAndFilteredUsers.Count; i++)
            {
                var b = new WorkingHour();
                b.Date = today;
                b.Hours = sortedAndFilteredUsers[i].HoursNumber;
                b.Userid = sortedAndFilteredUsers[i].Id;
                b.Productionid = context.Tasks.Where(x => x.Id == sortedAndFilteredUsers[i].TaskId).Select(x => x.Productionid).FirstOrDefault();
                ListToAdd.Add(b);
                context.Add<WorkingHour>(b);

                try
                {
                    Production updatedProduction = context.Productions.SingleOrDefault(p => p.Id == b.Productionid);
                    User updatedUser = context.Users.SingleOrDefault(u => u.Id == b.Userid);
                    updatedProduction.ProductionPrice += b.Hours * (float)updatedUser.SalaryByHour;
                }
                catch (Exception e)
                {
                    Debug.Print(e.ToString());
                }
            }
            context.SaveChanges();
            MessageBox.Show("Utworzyłeś godziny pracy");
        }
        public HoursScreenViewModel(MainViewModel mainModel) 
        {
            MainModel = mainModel;
            combinedUsers = new List<CombinedUser>();
            TodayDate = today;
            TableGenerator(combinedUsers);
            CreateNewWorkingHours = new RelayCommand(CreateNewWorkingHoursFu);
        }
    }
}
