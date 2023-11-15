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
    public class ArchiveListScreenViewModel : BaseViewModel
    {
        public MainViewModel MainModel { get; set; }

        public ObservableCollection<Warehouse>? WarehouseList { get; set; }

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
                ArchiveScreenViewModel newView = new ArchiveScreenViewModel(MainModel, CurrentWarehouse);
                if (MainModel.UpdateViewCommand.CanExecute(newView))
                    MainModel.UpdateViewCommand.Execute(newView);
            }
        }

        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();
        public ArchiveListScreenViewModel(MainViewModel mainModel) 
        {
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
