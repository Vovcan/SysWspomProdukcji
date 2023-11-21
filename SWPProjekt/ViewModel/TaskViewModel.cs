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
        public User LoginUser { get; set; }
        public ObservableCollection<User> Employees { get => employees; set { employees = value; } }
        public ObservableCollection<User> AllEmployees { get => allEmployees; set { allEmployees = value; PropertyChanged(this, new PropertyChangedEventArgs("AllEmployees")); } }
        public User Author { get; set; }
        public User SelectedEmployee { get; set; }
        private ObservableCollection<User> allEmployees;
        private User modifiedEmployee;
        private ObservableCollection<User> employees;

        public User ModifiedEmployee
        {
            get { return modifiedEmployee; }
            set
            {
                modifiedEmployee = value;
                if (modifiedEmployee != null)
                    ChangeEmployee(modifiedEmployee);

            }
        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public bool Removing { get; set; } = false;
        public event PropertyChangedEventHandler PropertyChanged;
        public Visibility Visibility { get => visibility; set { visibility = value; PropertyChanged(this, new PropertyChangedEventArgs("Visibility")); } }
        public TaskViewModel(Model.Task task, MainViewModel mainView, User loginUser)
        {
            MainModel = mainView;
            CurrentTask = task;
            LoginUser = loginUser;
            AddCommand = new RelayCommand(AddList);
            CloseCommand = new RelayCommand(Close);
            RemoveCommand = new RelayCommand(RemoveList);
            try
            {  
                db = new ProductionDatabaseContext();
                Production = db.Productions.Single(u => u.Id == CurrentTask.Productionid);
                Author = db.Users.Where(u => u.TaskUsers.Any(p => p.Taskid == CurrentTask.Id) && u.JobTitleid == 2).FirstOrDefault();
                Employees = new ObservableCollection<User>(db.Users.Where(u => u.TaskUsers.Any(p => p.Taskid == CurrentTask.Id) && u.JobTitleid != 2));
            }
            catch
            {

            }
        }

        public void AddList(object o)
        {
            Visibility = Visibility.Visible;
            Removing = false;
            AllEmployees = new ObservableCollection<User>(db.Users.Where(u => !u.TaskUsers.Any(p => p.Taskid == CurrentTask.Id) && (u.JobTitleid == 4 || u.JobTitleid == 5)));
        }
        public void RemoveList(object o)
        {
            Visibility = Visibility.Visible;
            Removing = true;
            AllEmployees = Employees;
        }
        public void Close(object o)
        {
            Visibility = Visibility.Collapsed;
        }

        public void ChangeEmployee(User employee)
        {
            try
            {
                if (Removing)
                {
                    TaskUser taskUser = db.TaskUsers.Single(t => t.Taskid == CurrentTask.Id && t.Userid == employee.Id);
                    db.Remove(taskUser);
                    db.SaveChanges();   
                }
                else
                {
                    TaskUser taskUser = new TaskUser { Userid = employee.Id, Taskid = CurrentTask.Id };
                    db.Add(taskUser);
                    db.SaveChanges();
                }
                Employees = new ObservableCollection<User>(db.Users.Where(u => u.TaskUsers.Any(p => p.Taskid == CurrentTask.Id) && u.JobTitleid != 2));
                PropertyChanged(this, new PropertyChangedEventArgs("Employees"));
                Visibility = Visibility.Collapsed;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}");
            }
        }

    }
}
