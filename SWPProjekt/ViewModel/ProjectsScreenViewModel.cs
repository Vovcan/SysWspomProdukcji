using SWPProjekt.Helpers;
using SWPProjekt.Model;
using SWPProjekt.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWPProjekt.ViewModel
{
    class ProjectsScreenViewModel : BaseViewModel
    {
        User LoginUser;
        public RelayCommand CreateProjectCommand { get; set; }
        public ObservableCollection<Project>? ProjectList { get; set; }
        public MainViewModel MainModel { get; set; }

        private Project _currentProject;
        public Project CurrentProject
        {
            get { return _currentProject; }
            set
            {
                _currentProject = value;
                ProjectViewModel newView = new ProjectViewModel(CurrentProject,MainModel, LoginUser);
                if (MainModel.UpdateViewCommand.CanExecute(newView))
                    MainModel.UpdateViewCommand.Execute(newView);
            }
        }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();



        public ProjectsScreenViewModel(MainViewModel mainModel, User loginUser)
        {
            LoginUser = loginUser;
            MainModel = mainModel;
            CreateProjectCommand = new RelayCommand(CreateProject);
            try
            {
                ProjectList = new ObservableCollection<Project>(context.Projects.ToList());
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public void CreateProject(Object o)
        {
            if(LoginUser.JobTitleid == 3)
            {
                MainModel.UpdateViewCommand.Execute(new NewProjectViewModel(MainModel));
            }
            else
            {
                MessageBox.Show("Nie masz dostępu do tego komponentu");
            }

        }
    }
}
