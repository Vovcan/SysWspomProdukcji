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
        //public ObservableCollection<User> Managers { get; set; }
        //public ObservableCollection<Model.Task> Tasks { get; set; }
        public ProductionDatabaseContext db { get; set; }
        public Production Production { get; set; }
        public MainViewModel MainModel { get; set; }
        public TaskViewModel(Model.Task task, MainViewModel mainView, User LoginUser)
        {
            MainModel = mainView;
            CurrentTask = task;
            try
            {
                db = new ProductionDatabaseContext();
                Production = db.Productions.Single(u => u.Id == CurrentTask.Productionid);
            }
            catch
            {

            }
        }
    }
}
