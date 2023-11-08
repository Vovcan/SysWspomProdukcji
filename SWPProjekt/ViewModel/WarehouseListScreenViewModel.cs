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
        User LoginUser;
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
                WarehouseViewModel newView = new WarehouseViewModel(CurrentWarehouse, LoginUser);
                if (MainModel.UpdateViewCommand.CanExecute(newView))
                    MainModel.UpdateViewCommand.Execute(newView);
            }
        }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();



        public WarehouseListScreenViewModel(MainViewModel mainModel, User User) {
            LoginUser = User;
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
