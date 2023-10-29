using SWPProjekt.Helpers;
using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.ViewModel
{
    internal class NewProjectViewModel : BaseViewModel
    {
        public MainViewModel MainModel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? PlannedFinishDate { get; set; }
        public RelayCommand SaveProjectCommand { get; set; }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();

        public NewProjectViewModel(MainViewModel mainModel)
        {
            SaveProjectCommand = new RelayCommand(SaveProject);
            MainModel = mainModel;
        }

        public void SaveProject(object o)
        {
            if (Validate())
            {
                Debug.WriteLine("Walidacja udana");
                Debug.WriteLine(Name);
                Debug.WriteLine(Description);
                Debug.WriteLine(StartDate);
                Debug.WriteLine(PlannedFinishDate);
                Project project = new Project {Name=Name,Description=Description,StartDate=StartDate,ProjectTime=PlannedFinishDate,Userid=MainModel.LoginUser.Id };
                context.Add<Project>(project);
                context.SaveChanges();
                MainModel.UpdateViewCommand.Execute("ProjectsScreen");
            }
            else
            {
                Debug.WriteLine("Walidacja nieudana");
            }
        }

        public bool Validate()
        {
            if (Name != "" && Description != "" && MainModel.LoginUser!=null)
                return true;
            else
                return false;
        }
    }
}
