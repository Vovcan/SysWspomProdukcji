using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using MaterialDesignColors.Recommended;
using SWPProjekt.Helpers;
using SWPProjekt.Model;

namespace SWPProjekt.ViewModel
{
    public class WarehouseViewModel : BaseViewModel
    { 
        public Warehouse CurrentWarehouse { get; set; }

        ProductionDatabaseContext context = new ProductionDatabaseContext();

        public List<int> DeliverysId { get; set; }

        public List<Product> Products { get; set; }

        public Product Product { get; set; }

        public List<string> ProductsName { get; set; }

        public List<int> Delivery { get; set; }

        public List<Delivery> Deliveries { get; set; }

        public int Id { get; set; }

        public List<Product> ProductList { get; set; }
    
        public List<Product> SelectedProducts { get; set; }
        public RelayCommand CreateNewDelivery { get; set; }

        private List<CombinedDeliveryData> _combinedDelivery;

        //-------------------------

        private Visibility _yourStackPanelVisibility;
        public Visibility YourStackPanelVisibility
        {
            get { return _yourStackPanelVisibility; }
            set
            {
                _yourStackPanelVisibility = value;
                OnPropertyChanged(nameof(YourStackPanelVisibility));
            }
        }
        private void CreateDelivery(object a)
        {
            YourStackPanelVisibility = Visibility.Visible;
        }
        public WarehouseViewModel(Warehouse warehouse)
        {
            CreateNewDelivery = new RelayCommand(CreateDelivery);
            CurrentWarehouse = warehouse;
            Delivery = context.Deliveries
                .Where(x => x.Warehouseid == CurrentWarehouse.Id)
                .Select(d => d.Id)
                .ToList();

            DeliverysId = new List<int>();

            for (int i = 0; i < Delivery.Count; i++)
            {
                DeliverysId.AddRange(context.Deliveries
                .Where(x => x.Id == Delivery[i])
                .Select(d => d.Productid)
                .ToList());
            }
            Products = new List<Product>();
            ProductList = new List<Product>();
            Deliveries = new List<Delivery>();
            for (int i = 0; i < DeliverysId.Count; i++)
            {
                Products.AddRange(context.Products
                .Where(s => s.Id == DeliverysId[i])
                .ToList());
            }

            ProductList.AddRange(Products);
            HashSet<string> productNames = new HashSet<string>();
            List<Product> uniqueProducts = new List<Product>();
            foreach (var product in Products)
            {
                if (productNames.Add(product.Name))
                {
                    uniqueProducts.Add(product);
                }
            }
            Products = uniqueProducts;

        }
        public Product _selectedProduct;

        public Product SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                SelectedProducts = new List<Product>();
                SelectedProducts.AddRange(ProductList.Where(x => x.Name == _selectedProduct.Name).ToList());

                for (int i = 0; i < SelectedProducts.Count(); i++)
                {
                    Deliveries.AddRange(context.Deliveries.Where(x => x.Productid == SelectedProducts[i].Id).ToList());
                }
                var DelyverysList = new List<CombinedDeliveryData>();

                for (int i = 0; i < Deliveries.Count(); i++)
                {
                    CombinedDeliveryData combinedData = new CombinedDeliveryData();

                    combinedData.Id = Deliveries[i].Id;
                    combinedData.DeliveryDate = Deliveries[i].DeliveryDate;
                    combinedData.ExpirationDate = Deliveries[i].ExpirationDate;
                    //combinedData.ProducerName = SelectedProducts[i].Producer; // stary kod, powodował błąd gdy dostaw było więcej od Selected Products
                    combinedData.ProducerName = Deliveries[i].Product.Producer; // nowy kod, chyba działa poprawnie
                    combinedData.Amount = Deliveries[i].Amount;
                    combinedData.CurrentAmount = Deliveries[i].CurrentAmount;
                    combinedData.FullPrice = Deliveries[i].FullPrice;
                    combinedData.UnitName = context.Units
                        .Where(x => x.Id == Deliveries[i].Unitid)
                        .Select(d => d.Name)
                        .FirstOrDefault();

                    DelyverysList.Add(combinedData);

                }
                CombinedDelivery = DelyverysList;
                Deliveries.Clear();
            }
        }
        public List<CombinedDeliveryData> CombinedDelivery
        {
            get 
            { 
                return _combinedDelivery; 
            }
            set 
            {
                _combinedDelivery = value;
                OnPropertyChanged(nameof(CombinedDelivery));
            }
        }
    }
}
