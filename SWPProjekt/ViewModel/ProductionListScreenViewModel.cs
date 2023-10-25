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
                if (MainModel.UpdateViewCommand.CanExecute(CurrentProduction))
                    MainModel.UpdateViewCommand.Execute(CurrentProduction);
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
    }
}

