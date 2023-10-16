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
        public Warehouse CurrentWarehouse { get; set; }
        public WarehouseViewModel(Warehouse warehouse)
        {
            CurrentWarehouse = warehouse;
        }
    }
}
