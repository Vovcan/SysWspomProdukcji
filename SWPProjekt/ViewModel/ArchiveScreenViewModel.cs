using Microsoft.EntityFrameworkCore;
using SWPProjekt.Model;
using System.Collections.Generic;
using System.Linq;

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
        public List<ProductionDelivery> ProductionDeliveryItems { get; set; }
        public List<LostProduct> LostItems { get; set; }

        List<CustomArchiveElement> LocalHelpArchiveElements;
        public List<CustomArchiveElement> SaleItemsFunction()
        {
            LocalHelpArchiveElements = new List<CustomArchiveElement>();
            SaleItems = new List<Sale>();
            SaleItems.AddRange(context.Sales.Where(sale => sale.Delivery.Warehouseid == CurrentWarehouse.Id)
                .Include(sale => sale.Delivery).ThenInclude(delivery => delivery.Product)
                .Include(sale => sale.Delivery).ThenInclude(delivery => delivery.Unit));
            for (int i = 0; i < SaleItems.Count; i++)
            {
                CustomArchiveElement a = new CustomArchiveElement(SaleItems[i].Delivery.Id,"Sprzedane",
                                    SaleItems[i].DateOfSale,SaleItems[i].Delivery.Product.Name, false,
                                    SaleItems[i].Amount,SaleItems[i].Delivery.Unit.Name);

                LocalHelpArchiveElements.Add(a);
            }
            
            return LocalHelpArchiveElements;
        }

        public List<CustomArchiveElement> DeliveryItemsFunction()
        {
            LocalHelpArchiveElements = new List<CustomArchiveElement>();
            AddDeliveries = new List<Delivery>();
            AddDeliveries.AddRange(context.Deliveries.Where(delivery => delivery.Warehouseid == CurrentWarehouse.Id)
                .Include(delivery=>delivery.Unit)
                .Include(delivery => delivery.Product));
            for (int i = 0; i < AddDeliveries.Count; i++)
            {
                CustomArchiveElement a = new CustomArchiveElement(AddDeliveries[i].Id, "Nowa dostawa/partia",
                                    AddDeliveries[i].DeliveryDate,AddDeliveries[i].Product.Name, true,
                                    AddDeliveries[i].Amount,AddDeliveries[i].Unit.Name);

                LocalHelpArchiveElements.Add(a);
            }
            return LocalHelpArchiveElements;
        }

        public List<CustomArchiveElement> ProductionItemsFunction()
        {
            LocalHelpArchiveElements = new List<CustomArchiveElement>();
            ProductionDeliveryItems = new List<ProductionDelivery>();
            ProductionDeliveryItems.AddRange(context.ProductionDeliveries.Where(pd => pd.Delivery.Warehouseid == CurrentWarehouse.Id)
                .Include(pd=>pd.Delivery).ThenInclude(delivery=>delivery.Product)
                .Include(pd => pd.Delivery).ThenInclude(delivery => delivery.Unit));
            for (int i = 0; i < ProductionDeliveryItems.Count; i++)
            {
                CustomArchiveElement a = new CustomArchiveElement(ProductionDeliveryItems[i].Delivery.Id,"Przekazane na produkcję", ProductionDeliveryItems[i].Date,
                                    ProductionDeliveryItems[i].Delivery.Product.Name, false, ProductionDeliveryItems[i].Amount,
                                    ProductionDeliveryItems[i].Delivery.Unit.Name);

                LocalHelpArchiveElements.Add(a);
            }

            return LocalHelpArchiveElements;
        }

        public List<CustomArchiveElement> LostItemsFunction()
        {
            LocalHelpArchiveElements = new List<CustomArchiveElement>();
            LostItems = new List<LostProduct>();
            LostItems.AddRange(context.LostProducts.Where(lp => lp.Delivery.Warehouseid == CurrentWarehouse.Id)
                .Include(pd => pd.Delivery).ThenInclude(delivery => delivery.Product)
                .Include(pd => pd.Delivery).ThenInclude(delivery => delivery.Unit));
            for (int i = 0; i < LostItems.Count; i++)
            {
                CustomArchiveElement a = new CustomArchiveElement(LostItems[i].Delivery.Id, "Utracony produkt", LostItems[i].Date,
                                    LostItems[i].Delivery.Product.Name, false, LostItems[i].Amount,
                                    LostItems[i].Delivery.Unit.Name);

                LocalHelpArchiveElements.Add(a);
            }

            return LocalHelpArchiveElements;
        }

        public ArchiveScreenViewModel(MainViewModel mainModel, Warehouse CurrentWarehouse)
        {
            MainModel = mainModel;
            this.CurrentWarehouse = CurrentWarehouse;
            CustomArchiveElements = new List<CustomArchiveElement>();
            CustomArchiveElements.AddRange(SaleItemsFunction());
            CustomArchiveElements.AddRange(DeliveryItemsFunction());
            CustomArchiveElements.AddRange(ProductionItemsFunction());
            CustomArchiveElements.AddRange(LostItemsFunction());
        }
    }
}
