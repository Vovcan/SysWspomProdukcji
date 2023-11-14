using SWPProjekt.Helpers;
using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.ViewModel
{
    internal class TaskListScreenViewModel : BaseViewModel
    {
        User LoginUser;
        public RelayCommand CreateCommand { get; set; }
        public ObservableCollection<Model.Task>? TaskList { get; set; }
        public MainViewModel MainModel { get; set; }

        private Model.Task _currentTask;
        public Model.Task CurrentTask
        {
            get { return _currentTask; }
            set
            {
                _currentTask = value;
                TaskViewModel newView = new TaskViewModel(CurrentTask, MainModel, LoginUser);
                if (MainModel.UpdateViewCommand.CanExecute(newView))
                    MainModel.UpdateViewCommand.Execute(newView);
            }
        }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();



        public TaskListScreenViewModel(MainViewModel mainModel, User user)
        {
            CreateCommand = new RelayCommand(Create);
            LoginUser = user;
            MainModel = mainModel;
            try
            {
                TaskList = new ObservableCollection<Model.Task>(context.Tasks.ToList());
                Debug.WriteLine("połączono");
            }
            catch
            {
                Debug.WriteLine("brak połączenia z bazą");
            }

        }

        public void Create(Object o)
        {
            MainModel.UpdateViewCommand.Execute(new NewTaskViewModel(MainModel));
        }
    }
}
