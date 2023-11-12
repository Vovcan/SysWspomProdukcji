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
    class NewProductionViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public MainViewModel MainModel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? PlannedFinishDate { get; set; }
        public Project Project { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();
        public ObservableCollection<Project>? Projects { get; set; }
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

        public NewProductionViewModel(MainViewModel mainModel)
        {
            SaveCommand = new RelayCommand(Save);
            MainModel = mainModel;
            Projects = new ObservableCollection<Project>(context.Projects.ToList());
        }

        public void Save(object o)
        {
            if (Validate())
            {
                Production production = new Production { Name = Name, Description = Description, StartDate = StartDate, PlannedFinishDate = PlannedFinishDate, Projectid=Project.Id};
                context.Add<Production>(production);
                context.SaveChanges();
                MainModel.UpdateViewCommand.Execute("ProductionList");
            }
            else
            {
                ValidationFailedText = "Wymagane pola nie są wypełnione";
            }
        }

        public bool Validate()
        {
            if (Name != "" && Name != null && Description != "" && Description != null && MainModel.LoginUser != null && Project != null)
                return true;
            else
                return false;
        }
    }
}
