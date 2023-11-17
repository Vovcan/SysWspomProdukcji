using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWPProjekt.Model;

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
        public List<Delivery> AddDostaws { get; set; }

        List<CustomArchiveElement> LocalHelpArchiveElements;
        public List<CustomArchiveElement> SaleItemsFu()
        {
            LocalHelpArchiveElements = new List<CustomArchiveElement>();
            SaleItems = new List<Sale>();
            SaleItems.AddRange(context.Sales.Where(sale => sale.Delivery.Warehouseid == CurrentWarehouse.Id));
            for(int i = 0; i < SaleItems.Count; i++)
            {
                CustomArchiveElement a = new CustomArchiveElement(SaleItems[i].Id,
                                                                  SaleItems[i].DateOfSale,
                                                                  context.Sales
                                                                    .Where(sale => sale.Id == SaleItems[i].Id)
                                                                    .Select(sale => sale.Delivery.Product.Name)
                                                                    .FirstOrDefault(),
                                                                  false,
                                                                  SaleItems[i].Amount,
                                                                  context.Sales
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
            AddDostaws = new List<Delivery>();
            AddDostaws.AddRange(context.Deliveries);
            for(int i = 0; i < AddDostaws.Count; i++)
            {
                CustomArchiveElement a = new CustomArchiveElement(AddDostaws[i].Id,
                                                                   AddDostaws[i].DeliveryDate,
                                                                   context.Deliveries
                                                                    .Where(delivery => delivery.Id == AddDostaws[i].Id)
                                                                    .Select(delivery => delivery.Product.Name)
                                                                    .FirstOrDefault(),
                                                                   true,
                                                                   AddDostaws[i].Amount,
                                                                   context.Deliveries
                                                                    .Where(delivery => delivery.Id == AddDostaws[i].Id)
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
