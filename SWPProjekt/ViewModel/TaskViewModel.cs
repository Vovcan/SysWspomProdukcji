using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.ViewModel
{
    internal class TaskViewModel : BaseViewModel
    {
        public Model.Task CurrentTask { get; set; }
        public ProductionDatabaseContext db { get; set; }
        public Production Production { get; set; }
        public MainViewModel MainModel { get; set; }
        public ObservableCollection<User> Employees { get; set; }
        public User Author { get; set; }
        public User SelectedEmployee { get; set; }
        public TaskViewModel(Model.Task task, MainViewModel mainView, User LoginUser)
        {
            MainModel = mainView;
            CurrentTask = task;
            try
            {
                db = new ProductionDatabaseContext();
                Production = db.Productions.Single(u => u.Id == CurrentTask.Productionid);
                Author = db.Users.Where(u => u.TaskUsers.Any(p => p.Taskid == CurrentTask.Id) && u.JobTitleid==2).FirstOrDefault();
                Employees = new ObservableCollection<User>(db.Users.Where(u => u.TaskUsers.Any(p => p.Taskid == CurrentTask.Id)&& u.JobTitleid!=2));
            }
            catch
            {

            }
        }
    }
}
