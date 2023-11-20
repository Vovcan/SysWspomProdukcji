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

namespace SWPProjekt.ViewModel
{
    internal class NewTaskViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public MainViewModel MainModel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? Deadline { get; set; }
        public Production Production { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();
        public ObservableCollection<Production>? Productions { get; set; }
        public ObservableCollection<User>? Employees { get; set; }
        public int Priority { get; set; }
        private string validationFailedText;
        public string ValidationFailedText
        {
            get => validationFailedText;
            set
            {
                validationFailedText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ValidationFailedText"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public NewTaskViewModel(MainViewModel mainModel)
        {
            SaveCommand = new RelayCommand(Save);
            MainModel = mainModel;
            Productions = new ObservableCollection<Production>(context.Productions.ToList());
        }

        public void Save(object o)
        {   
            if (Validate())
            {
                Model.Task task = new Model.Task { Name = Name, Description = Description, StartDate = StartDate,Priority=Priority,CreationDate= DateTime.Now, Deadline = Deadline, Productionid = Production.Id };
                TaskUser taskUser = new TaskUser {Task=task,Userid=MainModel.LoginUser.Id };
                context.Add(taskUser);
                context.SaveChanges();
                MainModel.UpdateViewCommand.Execute("TasksScreen");
            }
        }

        public bool Validate()
        {
            if (Priority < 1 || Priority> 10)
            {
                ValidationFailedText = "Priorytet ma błędną wartość. Podaj liczbę całkowitą od 1 do 10";
                return false;
            }
            else if (Name == "" || Description == "" || MainModel.LoginUser == null || Production == null)
            {
                ValidationFailedText = "Wymagane pola nie są wypełnione";
                return false;
            }
            else
            {
                return true;
            }     
        }
    }
}
