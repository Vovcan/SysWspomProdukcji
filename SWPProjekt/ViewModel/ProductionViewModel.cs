using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.ViewModel
{
    public class ProductionViewModel : BaseViewModel
    {
        public Production CurrentProduction { get; set; }
        public ObservableCollection<User> Managers { get; set; }
        public ObservableCollection<Model.Task> Tasks { get; set; }
        public ProductionDatabaseContext db { get; set; }
        public Project Project { get; set; }
        public MainViewModel MainModel { get; set; }
        public ProductionViewModel(Production production, MainViewModel mainView, User LoginUser)
        {
            MainModel = mainView;
            CurrentProduction = production;
            try
            {
                db = new ProductionDatabaseContext();
                Project = db.Projects.Single(u => u.Id == CurrentProduction.Projectid);
                Tasks = new ObservableCollection<Model.Task>(db.Tasks.Where(t => t.Productionid == CurrentProduction.Id).ToList());
                Managers = new ObservableCollection<User>(db.Users.Where(u=>u.ProductionManagers.Any(p=>p.Productionid==CurrentProduction.Id)));
            }
            catch
            {

            }
        }
    }
}
