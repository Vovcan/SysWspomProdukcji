using SWPProjekt.Model;
using SWPProjekt.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWPProjekt.ViewModel
{
    class ProjectsScreenViewModel : BaseViewModel
    {
        public ObservableCollection<Project>? ProjectList { get; set; }
        public MainViewModel MainModel { get; set; }

        private Project _currentProject;
        public Project CurrentProject
        {
            get { return _currentProject; }
            set
            {
                _currentProject = value;
                ProjectViewModel newView = new ProjectViewModel(CurrentProject);
                if (MainModel.UpdateViewCommand.CanExecute(newView))
                    MainModel.UpdateViewCommand.Execute(newView);
            }
        }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();



        public ProjectsScreenViewModel(MainViewModel mainModel)
        {
            MainModel = mainModel;
            try
            {
                ProjectList = new ObservableCollection<Project>(context.Projects.ToList());
                Debug.WriteLine("połączono");
            }
            catch
            {
                Debug.WriteLine("brak połączenia z bazą");
            }

        }
    }
}
