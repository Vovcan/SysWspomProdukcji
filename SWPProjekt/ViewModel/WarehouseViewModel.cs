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
        public List<int> Delivery { get; set; }
        public List<Delivery> Deliveries { get; set; }
        public List<Product> ProductList { get; set; }
        public List<Product> SelectedProducts { get; set; }
        public RelayCommand CreateNewDelivery { get; set; }
        public RelayCommand CreateNewUnit { get; set; }

        private bool isNewDeliveryButtonPressed = false;

        private bool isNewUnitButtonPressed = false;

        private List<CombinedDeliveryData> _combinedDelivery;

        // --- new unit button binding

        private Brush textUnitForeground;

        private Brush buttonUnitBackground;
        public Brush ButtonUnitBackground
        {
            get {

                return isNewUnitButtonPressed ? Brushes.White : new SolidColorBrush(Color.FromRgb(0, 120, 212)); 
            }
            set
            {
                buttonUnitBackground = value;
                OnPropertyChanged(nameof(ButtonUnitBackground)); 
            }
        }
        public Brush TextUnitForeground
        {
            get {

                return isNewUnitButtonPressed ? new SolidColorBrush(Color.FromRgb(0, 120, 212)) : Brushes.White; 
            }
            set
            {
                textUnitForeground = value;
                OnPropertyChanged(nameof(TextUnitForeground)); 
            }
        }

        // --- new delivery button binding

        private Brush textDeliveryForeground;

        private Brush buttonDeliveryBackground;
        public Brush ButtonDeliveryBackground
        {
            get
            {

                return isNewDeliveryButtonPressed ? Brushes.White : new SolidColorBrush(Color.FromRgb(0, 120, 212));
            }
            set
            {
                buttonDeliveryBackground = value;
                OnPropertyChanged(nameof(ButtonDeliveryBackground));
            }
        }
        public Brush TextDeliveryForeground
        {
            get
            {

                return isNewDeliveryButtonPressed ? new SolidColorBrush(Color.FromRgb(0, 120, 212)) : Brushes.White;
            }
            set
            {
                textDeliveryForeground = value;
                OnPropertyChanged(nameof(TextDeliveryForeground));
            }
        }

        private Visibility stackPanelVisibility = Visibility.Collapsed;
        public Visibility StackPanelVisibility
        {
            get { return stackPanelVisibility; }
            set
            {
                if (stackPanelVisibility != value)
                {
                    stackPanelVisibility = value;
                    OnPropertyChanged(nameof(StackPanelVisibility));
                }
            }
        }

        private Visibility unitFormVisibility = Visibility.Collapsed;
        public Visibility UnitFormVisibility
        {
            get { return unitFormVisibility; }
            set
            {
                if (unitFormVisibility != value)
                {
                    unitFormVisibility = value;
                    OnPropertyChanged(nameof(UnitFormVisibility));
                }
            }
        }
        private DateTime _newexpirationdate { get; set; }
        public DateTime Newexpirationdate
        {
            get { return _newexpirationdate; }
            set { 
                _newexpirationdate = value; 
                OnPropertyChanged(nameof(Newexpirationdate)); 
            }
        }
        private DateTime _newdeliverydate { get; set; }
        public DateTime NewDeliveryDate
        {
            get { return _newdeliverydate; }
            set
            {
                _newdeliverydate = value;
                OnPropertyChanged(nameof(NewDeliveryDate));
            }
        }
        public string NewAmount { get; set; }
        public List<Unit> units { get; set; }

        private Unit _selectedUnit;
        public Unit SelectedUnit
        {
            get{return _selectedUnit;}
            set{_selectedUnit = value;}
        }

        private void CreateDelivery(object a)
        {
            StackPanelVisibility = Visibility.Visible;
            isNewDeliveryButtonPressed = !isNewDeliveryButtonPressed;
            if (isNewDeliveryButtonPressed)
            {
                ButtonDeliveryBackground = Brushes.White;
                TextDeliveryForeground = new SolidColorBrush(Color.FromRgb(0, 120, 212));
            }
            else
            {
                ButtonDeliveryBackground = new SolidColorBrush(Color.FromRgb(0, 120, 212));
                TextDeliveryForeground = Brushes.White;
            }
            Delivery NewDeliveryData = new Delivery();
            NewDeliveryData.Id = context.Deliveries.Count() + 1;
            NewDeliveryData.ExpirationDate = Newexpirationdate;
            NewDeliveryData.DeliveryDate = NewDeliveryDate;
            NewDeliveryData.Amount = Convert.ToInt32(NewAmount);
        }
        private void CreateUnit(object a)
        {
            UnitFormVisibility = Visibility.Visible;
            isNewUnitButtonPressed = !isNewUnitButtonPressed;
            if (isNewUnitButtonPressed){
                ButtonUnitBackground = Brushes.White;
                TextUnitForeground = new SolidColorBrush(Color.FromRgb(0, 120, 212)); 
            }else{
                ButtonUnitBackground = new SolidColorBrush(Color.FromRgb(0, 120, 212));
                TextUnitForeground = Brushes.White;}

        }
        public WarehouseViewModel(Warehouse warehouse)
        {
            CreateNewDelivery = new RelayCommand(CreateDelivery);
            CreateNewUnit = new RelayCommand(CreateUnit);
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


            units = new List<Unit>();
            units.AddRange(context.Units);

        }
        private Product _selectedProduct;

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
