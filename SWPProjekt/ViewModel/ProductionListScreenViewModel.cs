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
    internal class ProductionListScreenViewModel : BaseViewModel
    {
        public ObservableCollection<Production>? ProductionList { get; set; }
        public MainViewModel MainModel { get; set; }

        private Production _currentProduction;
        public Production CurrentProduction
        {
            get { return _currentProduction; }
            set
            {
                _currentProduction = value;
                ProductionViewModel newView = new ProductionViewModel(CurrentProduction, MainModel);
                if (MainModel.UpdateViewCommand.CanExecute(newView))
                    MainModel.UpdateViewCommand.Execute(newView);
            }
        }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();



        public ProductionListScreenViewModel(MainViewModel mainModel)
        {
            MainModel = mainModel;
            try
            {
                ProductionList = new ObservableCollection<Production>(context.Productions.ToList());
                Debug.WriteLine("połączono");
            }
            catch
            {
                Debug.WriteLine("brak połączenia z bazą");
            }

        }

        public void Create(Object o)
        {
            MainModel.UpdateViewCommand.Execute(new NewProductionViewModel(MainModel));
        }
    }
}

