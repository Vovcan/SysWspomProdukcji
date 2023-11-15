using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWPProjekt.Model;

namespace SWPProjekt.ViewModel
{
    class ArchiveScreenViewModel : BaseViewModel
    {
        public MainViewModel MainModel { get; set; }

        public Warehouse CurrentWarehouse { get; set; }

        public ArchiveScreenViewModel(MainViewModel mainModel, Warehouse CurrentWarehouse)
        {
            MainModel = mainModel;
            this.CurrentWarehouse = CurrentWarehouse;
        }
    }
}
