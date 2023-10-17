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
    public class WarehouseViewModel : BaseViewModel
    {
        public Warehouse CurrentWarehouse { get; set; }

        public Product SelectedProduct { get; set; }

        ProductionDatabaseContext context = new ProductionDatabaseContext();

        public List<int> Product { get; set; }

        public List<string> Names { get; set; }

        public List<int> Delivery { get; set; }

        public int Id { get; set; }

        public WarehouseViewModel(Warehouse warehouse)
        {
            CurrentWarehouse = warehouse;
            Delivery = context.Deliveries
                .Where(x => x.Warehouseid == CurrentWarehouse.Id)
                .Select(d => d.Id)
                .ToList();

            Product = new List<int>();

            for (int i = 0; i < Delivery.Count; i++)
            {
                Product.AddRange(context.Deliveries
                .Where(x => x.Id == Delivery[i])
                .Select(d => d.Productid)
                .ToList());
            }
            Names = new List<string>();

            for (int i = 0; i < Product.Count; i++)
            {
                Names.AddRange(context.Products
                .Where(s => s.Id == Product[i])
                .Select(u => u.Name)
                .ToList());
            }
            
        }

    }

}
