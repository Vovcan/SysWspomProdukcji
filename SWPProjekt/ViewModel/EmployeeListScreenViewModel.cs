using SWPProjekt.Helpers;
using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace SWPProjekt.ViewModel
{
    class EmployeeListScreenViewModel : BaseViewModel
    {
        User LoginUser;
        public RelayCommand CreateCommand { get; set; }
        public ObservableCollection<User>? EmployeeList { get; set; }
        public MainViewModel MainModel { get; set; }

        private User _currentEmployee;
        public User CurrentEmployee
        {
            get { return _currentEmployee; }
            set
            {
                _currentEmployee = value;
                EmployeeScreenViewModel newView = new EmployeeScreenViewModel(CurrentEmployee, MainModel, LoginUser);
                if (MainModel.UpdateViewCommand.CanExecute(newView))
                    MainModel.UpdateViewCommand.Execute(newView);
            }
        }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();



        public EmployeeListScreenViewModel(MainViewModel mainModel, User loginUser)
        {
            LoginUser = loginUser;
            MainModel = mainModel;
            CreateCommand = new RelayCommand(Create);
            try
            {
                EmployeeList = new ObservableCollection<User>(context.Users.Include(u=>u.JobTitle).ToList());
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public void Create(Object o)
        {
            if (LoginUser.JobTitleid == 1)
            {
                MainModel.UpdateViewCommand.Execute(new NewAccountViewModel(MainModel,LoginUser));
            }
            else
            {
                MessageBox.Show("Nie masz dostępu do tego komponentu");
            }

        }
    }
}
