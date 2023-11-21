using SWPProjekt.Helpers;
using SWPProjekt.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace SWPProjekt.ViewModel
{
    public class ProductionViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Visibility visibility = Visibility.Collapsed;
        private ObservableCollection<User>? managersToModify;
        private User? modifiedManager;
        public User? ModifiedManager
        {
            get { return modifiedManager; }
            set
            {
                modifiedManager = value;
                if (modifiedManager != null)
                    ChangeManager(modifiedManager);
            }
        }
        public Visibility Visibility { get => visibility; set { visibility = value; PropertyChanged(this, new PropertyChangedEventArgs("Visibility")); } }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public bool Removing { get; set; } = false;
        public event PropertyChangedEventHandler PropertyChanged;
        public Production CurrentProduction { get; set; }
        public User? SelectedManager { get; set; }
        public ObservableCollection<User>? Managers { get; set; }
        public ObservableCollection<User>? ManagersToModify { get => managersToModify; set { managersToModify = value; PropertyChanged(this, new PropertyChangedEventArgs("ManagersToModify")); } }
        public ObservableCollection<Model.Task>? Tasks { get; set; }
        public ProductionDatabaseContext db { get; set; }
        public Project? Project { get; set; }
        public MainViewModel MainModel { get; set; }
        public User LoginUser { get; set; }
        public Model.Task? SelectedTask { get; set; }
        public ProductionViewModel(Production production, MainViewModel mainView, User loginUser)
        {
            MainModel = mainView;
            CurrentProduction = production;
            LoginUser = loginUser;
            AddCommand = new RelayCommand(AdditionList);
            CloseCommand = new RelayCommand(Close);
            RemoveCommand = new RelayCommand(RemovalList);
            db = new ProductionDatabaseContext();
            try
            {       
                Project = db.Projects.Single(u => u.Id == CurrentProduction.Projectid);
                Tasks = new ObservableCollection<Model.Task>(db.Tasks.Where(t => t.Productionid == CurrentProduction.Id).ToList());
                Managers = new ObservableCollection<User>(db.Users.Where(u => u.ProductionManagers.Any(p => p.Productionid == CurrentProduction.Id)));
            }
            catch
            {

            }
        }

        public void AdditionList(object o)
        {
            ManagersToModify = null;
            Visibility = Visibility.Visible;
            Removing = false;
            ManagersToModify = new ObservableCollection<User>(db.Users.Where(u => !u.ProductionManagers.Any(p => p.Productionid == CurrentProduction.Id) && u.JobTitleid == 2));
        }
        public void RemovalList(object o)
        {
            ManagersToModify = null;
            Visibility = Visibility.Visible;
            Removing = true;
            ManagersToModify = Managers;
        }
        public void Close(object o)
        {
            Visibility = Visibility.Collapsed;
        }

        public void ChangeManager(User manager)
        {
            try
            {
                if (Removing)
                {
                    ProductionManager productionManager = db.ProductionManagers.Single(t => t.Productionid == CurrentProduction.Id && t.Userid == manager.Id);
                    db.Remove(productionManager);
                    db.SaveChanges();
                }
                else
                {
                    ProductionManager productionManager = new ProductionManager { Userid = manager.Id, Productionid = CurrentProduction.Id };
                    db.Add(productionManager);
                    db.SaveChanges();
                }
                Managers = new ObservableCollection<User>(db.Users.Where(u => u.ProductionManagers.Any(p => p.Productionid == CurrentProduction.Id)));
                PropertyChanged(this, new PropertyChangedEventArgs("Managers"));
                Visibility = Visibility.Collapsed;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}");
            }
        }
    }
}
