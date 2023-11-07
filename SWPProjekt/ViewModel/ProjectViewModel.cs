﻿using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.ViewModel
{
    class ProjectViewModel : BaseViewModel
    {
        public Project CurrentProject { get; set; }
        public User ProjectOwner { get; set; }
        public ProductionDatabaseContext db { get; set; }
        public ObservableCollection<Production>? ProductionList { get; set; }
        public MainViewModel MainModel { get; set; }

        private Production _currentProduction;
        public Production CurrentProduction
        {
            get { return _currentProduction; }
            set
            {
                _currentProduction = value;
                ProductionViewModel newView = new ProductionViewModel(CurrentProduction);
                if (MainModel.UpdateViewCommand.CanExecute(newView))
                    MainModel.UpdateViewCommand.Execute(newView);
            }
        }

        public ProjectViewModel(Project project, MainViewModel mainView)
        {
            MainModel = mainView;
            CurrentProject=project;
            try
            {
                db = new ProductionDatabaseContext();
                ProjectOwner = db.Users.Single(u => u.Id == project.Userid);
                ProductionList = new ObservableCollection<Production>(db.Productions.Where(p => p.Projectid == project.Id).ToList());
            }
            catch
            {

            }
            
        }
    }
}
