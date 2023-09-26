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
    internal class WarehouseListScreenViewModel
    {
        public ObservableCollection<Warehouse>? WarehouseList { get; set; }
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
