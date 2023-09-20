using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.ViewModel
{
    internal class WarehouseListScreenViewModel
    {
        // na razie magazyny dodane na sztywno jako test. Docelowo będą wczytywane z bazy danych
        public ObservableCollection<Warehouse> WarehouseList { get; set; } = new ObservableCollection<Warehouse>();
        public WarehouseListScreenViewModel() {

            //WarehouseList.Add(new Warehouse("magazyn1","adres1","zip1",false));
            //WarehouseList.Add(new Warehouse("magazyn2", "adres2", "zip2", true));
        }
        
        
    }
}
