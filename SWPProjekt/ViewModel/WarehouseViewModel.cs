using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWPProjekt.Model;

namespace SWPProjekt.ViewModel
{
    internal class WarehouseViewModel : BaseViewModel
    {
        public ObservableCollection<Warehouse>? Warehouse { get; set; }

        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();

        public WarehouseViewModel()
        {
            try
            {
                Warehouse = new ObservableCollection<Warehouse>(context.Warehouses.ToList());
                Debug.WriteLine("połączono");
            }
            catch
            {
                Debug.WriteLine("brak połączenia z bazą");
            }

        }
    }
}
