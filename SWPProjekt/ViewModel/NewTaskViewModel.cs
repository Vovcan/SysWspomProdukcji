using SWPProjekt.Helpers;
using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.ViewModel
{
    internal class NewTaskViewModel : BaseViewModel
    {
        public MainViewModel MainModel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? Deadline { get; set; }
        public Production Production { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();
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
            //Productions = new ObservableCollection<Production>(context.Productions.ToList());
        }

        public void Save(object o)
        {
            /*
            if (Validate())
            {
                Model.Task task = new Model.Task { Name = Name, Description = Description, StartDate = StartDate, Deadline = Deadline, Productionid = Production.Id };
                context.Add(task);
                context.SaveChanges();
                MainModel.UpdateViewCommand.Execute("TaskList");
            }
            else
            {
                ValidationFailedText = "Wymagane pola nie są wypełnione";
            }
            */
        }

        public bool Validate()
        {
            if (Name != "" && Name != null && Description != "" && Description != null && MainModel.LoginUser != null && Production != null)
                return true;
            else
                return false;
        }
    }
}
