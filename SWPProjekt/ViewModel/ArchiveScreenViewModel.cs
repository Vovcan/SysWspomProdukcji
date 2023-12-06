using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWPProjekt.Model;
using Microsoft.EntityFrameworkCore;

namespace SWPProjekt.ViewModel
{
    class ArchiveScreenViewModel : BaseViewModel
    {
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();
        public MainViewModel MainModel { get; set; }
        public Warehouse CurrentWarehouse { get; set; }

        private List<CustomArchiveElement> _customArchiveElements;
        public List<CustomArchiveElement> CustomArchiveElements
        {
            get
            {
                return _customArchiveElements;
            }
            set
            {
                _customArchiveElements = value;
                OnPropertyChanged(nameof(CustomArchiveElements));
            } 
        }

        public List<Sale> SaleItems { get; set; }
        public List<Delivery> AddDeliveries { get; set; }
        public List<ProductionDelivery> ProductionDeliveryList { get; set; }

        List<CustomArchiveElement> LocalHelpArchiveElements;
        public List<CustomArchiveElement> SaleItemsFu()
        {
            LocalHelpArchiveElements = new List<CustomArchiveElement>();
            SaleItems = new List<Sale>();
            SaleItems.AddRange(context.Sales.Where(sale => sale.Delivery.Warehouseid == CurrentWarehouse.Id));
            for(int i = 0; i < SaleItems.Count; i++)
            {
                CustomArchiveElement a = new CustomArchiveElement(SaleItems[i].Id,SaleItems[i].DateOfSale,context.Sales
                                                                    .Where(sale => sale.Id == SaleItems[i].Id)
                                                                    .Select(sale => sale.Delivery.Product.Name)
                                                                    .FirstOrDefault(),false,SaleItems[i].Amount,context.Sales
                                                                    .Where(sale => sale.Id == SaleItems[i].Id)
                                                                    .Select(sale => sale.Delivery.Unit.Name)
                                                                     .FirstOrDefault());

                LocalHelpArchiveElements.Add(a);
            }
            
            return LocalHelpArchiveElements;
        }

        public List<CustomArchiveElement> DeliveryItemsFu()
        {
            LocalHelpArchiveElements = new List<CustomArchiveElement>();
            AddDeliveries = new List<Delivery>();
            AddDeliveries.AddRange(context.Deliveries.Where(delivery => delivery.Warehouseid == CurrentWarehouse.Id));
            for(int i = 0; i < AddDeliveries.Count; i++)
            {
                CustomArchiveElement a = new CustomArchiveElement(AddDeliveries[i].Id,AddDeliveries[i].DeliveryDate,context.Deliveries
                                                                    .Where(delivery => delivery.Id == AddDeliveries[i].Id)
                                                                    .Select(delivery => delivery.Product.Name)
                                                                    .FirstOrDefault(),true,AddDeliveries[i].Amount,context.Deliveries
                                                                    .Where(delivery => delivery.Id == AddDeliveries[i].Id)
                                                                    .Select(delivery => delivery.Unit.Name)
                                                                    .FirstOrDefault());
                LocalHelpArchiveElements.Add(a);
            }
            return LocalHelpArchiveElements;
        }

        public ArchiveScreenViewModel(MainViewModel mainModel, Warehouse CurrentWarehouse)
        {
            MainModel = mainModel;
            this.CurrentWarehouse = CurrentWarehouse;
            CustomArchiveElements = new List<CustomArchiveElement>();
            CustomArchiveElements.AddRange(SaleItemsFu());
            CustomArchiveElements.AddRange(DeliveryItemsFu());
        }
    }
}
