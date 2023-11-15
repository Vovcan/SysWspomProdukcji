using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using SWPProjekt.Helpers;
using SWPProjekt.Model;

namespace SWPProjekt.ViewModel
{
    class SaleScreenViewModel : BaseViewModel
    {
        ProductionDatabaseContext context = new ProductionDatabaseContext();
        public Sale NewSale { get; set; }
        public RelayCommand CreateNewSale { get; set; }
        private string _amount;
        public string Amount
        {
            get { return _amount; }
            set
            {
                // Перевірка наявності символів, окрім цифр
                if (IsNumeric(value))
                {
                    _amount = value;
                }
                else
                {
                    MessageBox.Show("W tym polu wolno wpisywać tylko cyfry");
                }
            }
        }
        private string _selingPrice;
        public string SelingPrice
        {
            get { return _selingPrice; }
            set
            {
                if (IsNumeric(value))
                {
                    _selingPrice = value;
                }
                else
                {
                    MessageBox.Show("W tym polu wolno wpisywać tylko cyfry");
                }
            }
        }

        private List<Warehouse> _warehauses;
        public List<Warehouse> Warehauses
        {
            get
            {
                return _warehauses;
            }
            set
            {
                _warehauses = value;
                OnPropertyChanged(nameof(Warehauses));
            }
        }
        private Warehouse _selectedWarehouse;
        public Warehouse SelectedWarehouse
        {
            get
            {
                return _selectedWarehouse;
            }
            set
            {
                _selectedWarehouse = value;
                OnPropertyChanged(nameof(SelectedWarehouse));
                Deliverys = new ObservableCollection<Delivery>();
                var deliveriesToAdd = context.Deliveries.Where(x => x.Warehouseid == SelectedWarehouse.Id).ToList();
                foreach (var delivery in deliveriesToAdd)
                {
                    Deliverys.Add(delivery);
                }
            }
        }
        private ObservableCollection<Delivery> _deliverys;
        public ObservableCollection<Delivery> Deliverys
        {
            get
            {
                return _deliverys;
            }
            set
            {
                _deliverys = value;
                OnPropertyChanged(nameof(Deliverys));
            }
        }
        private Delivery _selectedDelivery;
        public Delivery SelectedDelivery
        {
            get => _selectedDelivery;
            set
            {
                _selectedDelivery = value;
                OnPropertyChanged(nameof(Warehauses));
            }
        }

        public void FindData()
        {
            Warehauses = new List<Warehouse>();
            Warehauses.AddRange(context.Warehouses.ToList());
        }

        public void CreateSale(object a)
        {
            NewSale = new Sale();
            NewSale.Deliveryid = SelectedDelivery.Id;
            NewSale.Id = context.Sales.Count() + 1;
            NewSale.Price = Convert.ToInt32(SelingPrice);
            NewSale.Amount = Convert.ToInt32(Amount);
            context.Add<Sale>(NewSale);
            context.SaveChanges();
            MessageBox.Show("Utworzyłeś nową sprzedaże");
        }

        public SaleScreenViewModel()
        {
            FindData();
            CreateNewSale = new RelayCommand(CreateSale);
        }
        private List<CombinedDeliveryData> _combinedDelivery;
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

        private bool IsNumeric(string text)
        {
            Regex regex = new Regex("^[0-9]+$");

            return regex.IsMatch(text);
        }
    }
}
