using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWPProjekt.Model;

namespace SWPProjekt.ViewModel
{
    public class TimeHistoryOfUserViewModel : BaseViewModel
    {
        public MainViewModel MainModel { get; set; }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();
        public User User { get; set; }
        public List<WorkingHour> WorkingHours { get; set; }
        public TimeHistoryOfUserViewModel(MainViewModel mainModel, User user) 
        {
            MainModel = mainModel;
            User = user;
            WorkingHours = context.WorkingHours.Where(x => x.Userid == User.Id).ToList();

        }
    }
}
