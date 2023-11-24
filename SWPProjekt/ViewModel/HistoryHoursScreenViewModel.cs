using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWPProjekt.Model;

namespace SWPProjekt.ViewModel
{
    public class HistoryHoursScreenViewModel : BaseViewModel
    {
        public MainViewModel MainModel { get; set; }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();
        public List<User> ListaPracownikow { get; set; }

        private User _currentUser;
        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                TimeHistoryOfUserViewModel newView = new TimeHistoryOfUserViewModel(MainModel,CurrentUser);
                if (MainModel.UpdateViewCommand.CanExecute(newView))
                    MainModel.UpdateViewCommand.Execute(newView);
            }
        }
        public HistoryHoursScreenViewModel(MainViewModel mainModel) 
        {
            MainModel = mainModel;
            ListaPracownikow = new List<User>();
            ListaPracownikow = context.Users.Where(x => x.JobTitleid == 5).ToList();

        }
    }
}
