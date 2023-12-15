using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using System.Windows;
using SWPProjekt.Helpers;
using SWPProjekt.Model;
using System.Text.RegularExpressions;

namespace SWPProjekt.ViewModel
{
    public class LostProductsViewModel : BaseViewModel
    {
        public MainViewModel MainModel { get; set; }

        ProductionDatabaseContext context = new ProductionDatabaseContext();
        public LostProduct LostProduct { get; set; }
        public RelayCommand CreateLost { get; set; }

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
                var deliveriesToAdd = context.Deliveries
                .Where(x => x.Warehouseid == SelectedWarehouse.Id)
                .ToList();
                var unitIds = deliveriesToAdd.Select(delivery => delivery.Unitid).ToList();
                var units = context.Units
                    .Where(unit => unitIds.Contains(unit.Id))
                    .ToList();
                var deliveriesWithUnits = deliveriesToAdd
                    .Join(units,
                        delivery => delivery.Unitid,
                        unit => unit.Id,
                        (delivery, unit) =>
                        {
                            delivery.Unit = unit;
                            return delivery;
                        })
                    .ToList();

                foreach (var delivery in deliveriesWithUnits)
                {
                    Deliverys.Add(delivery);
                }
            }
        }
        private string _amount;
        public string Amount
        {
            get { return _amount; }
            set
            {
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
        public LostProductsViewModel(MainViewModel mainModel)
        {
            MainModel = mainModel;
            FindData();
            CreateLost = new RelayCommand(CreateLostFu);
        }

        void CreateLostFu(object a)
        {
            if (SelectedDelivery == null || Amount == "")
            {
                MessageBox.Show("Wypełnij wszystkie pola");
            }
            else if (SelectedDelivery.CurrentAmount < Convert.ToSingle(Amount))
            {
                MessageBox.Show("Obecna ilość w magazynie jest mniejsza");
            }
            else
            {
                LostProduct = new LostProduct();
                LostProduct.Amount = (float)Convert.ToDouble(Amount);
                LostProduct.Date = DateTime.Now;
                LostProduct.Deliveryid = SelectedDelivery.Id;
                if (int.TryParse(_amount, out int amountValue))
                {
                    SelectedDelivery.CurrentAmount -= amountValue;
                    context.Add<LostProduct>(LostProduct);
                    context.SaveChanges();
                    MessageBox.Show("Podane dane są zapisane");
                }
                else
                {
                    MessageBox.Show("Podaj poprawną liczbę");
                }
            } 
        }
        private bool IsNumeric(string text)
        {
            Regex regex = new Regex("^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$");

            return regex.IsMatch(text);
        }
    }
}
