using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.ViewModel
{
    public class ProductionViewModel : BaseViewModel
    {
        public Production CurrentProduction { get; set; }
        public ProductionViewModel(Production production)
        {
            CurrentProduction = production;
        }
    }
}
