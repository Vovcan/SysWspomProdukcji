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
    
    public class WarehouseListScreenViewModel
    {
        
        public ObservableCollection<Warehouse>? WarehouseList { get; set; }

        private Warehouse _currentWarehouse;
        public Warehouse CurrentWarehouse
        {
            get { return _currentWarehouse; }
            set 
            { 
                _currentWarehouse = value;
                var mainItem = new MenuItem();
                mainItem.Name = "WarehouseBtn";
                MainMenu mainMenu = new MainMenu();
                mainMenu.MenuItem_Click(mainItem, null);
            }
        }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();

        public WarehouseListScreenViewModel() {
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
