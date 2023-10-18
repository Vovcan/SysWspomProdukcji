using SWPProjekt.Helpers;
using SWPProjekt.Model;
using SWPProjekt.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWPProjekt.ViewModel
{
    
    public class WarehouseListScreenViewModel : BaseViewModel
    {
        
        public ObservableCollection<Warehouse>? WarehouseList { get; set; }
        public MainViewModel MainModel { get; set; }

        private Warehouse _currentWarehouse;
        public Warehouse CurrentWarehouse
        {
            get 
            { 
                return _currentWarehouse; 
            }
            set 
            {
                _currentWarehouse = value;
                if (MainModel.UpdateViewCommand.CanExecute(CurrentWarehouse))
                    MainModel.UpdateViewCommand.Execute(CurrentWarehouse);
            }
        }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();



        public WarehouseListScreenViewModel(MainViewModel mainModel) {
            MainModel = mainModel;
            try
            {
                WarehouseList = new ObservableCollection<Warehouse>(context.Warehouses.ToList());
                Debug.WriteLine("połączono");
            }
            catch
            {
                Debug.WriteLine("brak połączenia z bazą");
            }

        }

    }
    

}
