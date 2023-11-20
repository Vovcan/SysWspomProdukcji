using SWPProjekt.Helpers;
using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SWPProjekt.ViewModel
{
    internal class TaskViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Visibility visibility = Visibility.Collapsed;

        public Model.Task CurrentTask { get; set; }
        public ProductionDatabaseContext db { get; set; }
        public Production Production { get; set; }
        public MainViewModel MainModel { get; set; }
        public ObservableCollection<User> Employees { get; set; }
        public ObservableCollection<User> AllEmployees { get; set; }
        public User Author { get; set; }
        public User SelectedEmployee { get; set; }
        private User addedEmployee;

        public User AddedEmployee
        {
            get { return addedEmployee; }
            set { addedEmployee = value;
                AddEmployee(addedEmployee);
            }
        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Visibility Visibility { get => visibility; set { visibility = value; PropertyChanged(this, new PropertyChangedEventArgs("Visibility")); } }
        public TaskViewModel(Model.Task task, MainViewModel mainView, User LoginUser)
        {
            MainModel = mainView;
            CurrentTask = task;
            try
            {
                AddCommand = new RelayCommand(Add);
                CloseCommand = new RelayCommand(Close);
                db = new ProductionDatabaseContext();
                Production = db.Productions.Single(u => u.Id == CurrentTask.Productionid);
                Author = db.Users.Where(u => u.TaskUsers.Any(p => p.Taskid == CurrentTask.Id) && u.JobTitleid == 2).FirstOrDefault();
                Employees = new ObservableCollection<User>(db.Users.Where(u => u.TaskUsers.Any(p => p.Taskid == CurrentTask.Id) && u.JobTitleid != 2));
                AllEmployees = new ObservableCollection<User>(db.Users.Where(u => !u.TaskUsers.Any(p => p.Taskid == CurrentTask.Id) && (u.JobTitleid == 4 || u.JobTitleid==5)));
            }
            catch
            {

            }
        }

        public void Add(object o)
        {
            Visibility = Visibility.Visible;
        }
        public void Close(object o)
        {
            Visibility = Visibility.Collapsed;
        }

        public void AddEmployee(User employee)
        {
            try
            {
                TaskUser taskUser = new TaskUser { Userid = employee.Id, Taskid = CurrentTask.Id };
                db.Add(taskUser);
                db.SaveChanges();
                MainModel.UpdateViewCommand.Execute(new TaskViewModel(CurrentTask, MainModel, MainModel.LoginUser));
            }
            catch{}   
        }
    }
}
