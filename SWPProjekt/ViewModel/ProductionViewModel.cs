using SWPProjekt.Helpers;
using SWPProjekt.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace SWPProjekt.ViewModel
{
    public class ProductionViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Visibility visibility = Visibility.Collapsed;
        private Visibility inResourceVisibility = Visibility.Collapsed;
        private Visibility outResourceVisibility = Visibility.Collapsed;
        private ObservableCollection<User>? managersToModify;
        private User? modifiedManager;
        private Product? selectedProduct;
        private ObservableCollection<Product>? allProducts;
        private ObservableCollection<Delivery>? allDeliveries;
        private ObservableCollection<Warehouse>? allWarehouses;
        private ObservableCollection<Unit>? allUnits;
        private float materialPrice = 0;
        private float laborPrice = 0;

        public User? ModifiedManager
        {
            get { return modifiedManager; }
            set
            {
                modifiedManager = value;
                if (modifiedManager != null)
                    ChangeManager(modifiedManager);
            }
        }
        public Visibility Visibility { get => visibility; set { visibility = value; PropertyChanged(this, new PropertyChangedEventArgs("Visibility")); } }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand AddResource { get; set; }
        public RelayCommand SaveInResource { get; set; }
        public RelayCommand SaveOutResource { get; set; }
        public bool Removing { get; set; } = false;
        public event PropertyChangedEventHandler PropertyChanged;
        public Production CurrentProduction { get; set; }
        public User? SelectedManager { get; set; }
        public ObservableCollection<ProductionDelivery>? UsedMaterials { get; set; }
        public ObservableCollection<ProductionDelivery>? ProducedMaterials { get; set; }
        public ObservableCollection<User>? Managers { get; set; }
        public ObservableCollection<User>? ManagersToModify { get => managersToModify; set { managersToModify = value; PropertyChanged(this, new PropertyChangedEventArgs("ManagersToModify")); } }
        public ObservableCollection<Model.Task>? Tasks { get; set; }
        public ProductionDatabaseContext db { get; set; }
        public Project? Project { get; set; }
        public MainViewModel MainModel { get; set; }
        public User LoginUser { get; set; }
        public Model.Task? SelectedTask { get; set; }
        public float MaterialPrice { get => materialPrice; set => materialPrice = value; }
        public float LaborPrice { get => laborPrice; set => laborPrice = value; }
        public ProductionViewModel(Production production, MainViewModel mainView, User loginUser)
        {
            MainModel = mainView;
            CurrentProduction = production;
            LoginUser = loginUser;
            AddCommand = new RelayCommand(AdditionList);
            CloseCommand = new RelayCommand(Close);
            RemoveCommand = new RelayCommand(RemovalList);
            AddResource = new RelayCommand(ResourceForm);
            SaveInResource = new RelayCommand(SaveResourceIn);
            SaveOutResource = new RelayCommand(SaveResourceOut);
            db = new ProductionDatabaseContext();
            try
            {
                Project = db.Projects.Single(u => u.Id == CurrentProduction.Projectid);
                Tasks = new ObservableCollection<Model.Task>(db.Tasks.Where(t => t.Productionid == CurrentProduction.Id).ToList());
                Managers = new ObservableCollection<User>(db.Users.Where(u => u.ProductionManagers.Any(p => p.Productionid == CurrentProduction.Id)));
                UsedMaterials = new ObservableCollection<ProductionDelivery>(db.ProductionDeliveries.Where(d => d.Productionid == CurrentProduction.Id && d.InOut == 1).Include(d => d.Delivery).ThenInclude(d => d.Product).Include(d => d.Delivery).ThenInclude(d => d.Unit));
                ProducedMaterials = new ObservableCollection<ProductionDelivery>(db.ProductionDeliveries.Where(d => d.Productionid == CurrentProduction.Id && d.InOut == 0).Include(d => d.Delivery).ThenInclude(d => d.Product).Include(d => d.Delivery).ThenInclude(d => d.Unit));
                foreach (ProductionDelivery u in UsedMaterials)
                {
                    MaterialPrice += u.Delivery.PriceByUnit * u.Amount;
                }
                LaborPrice = CurrentProduction.ProductionPrice - CurrentProduction.OtherPayments - MaterialPrice;
            }
            catch
            {

            }
        }

        public void AdditionList(object o)
        {
            ManagersToModify = null;
            Visibility = Visibility.Visible;
            Removing = false;
            ManagersToModify = new ObservableCollection<User>(db.Users.Where(u => !u.ProductionManagers.Any(p => p.Productionid == CurrentProduction.Id) && u.JobTitleid == 2));
        }
        public void RemovalList(object o)
        {
            ManagersToModify = null;
            Visibility = Visibility.Visible;
            Removing = true;
            ManagersToModify = Managers;
        }
        public void Close(object o)
        {
            Visibility = Visibility.Collapsed;
        }

        public void ChangeManager(User manager)
        {
            try
            {
                if (Removing)
                {
                    ProductionManager productionManager = db.ProductionManagers.Single(t => t.Productionid == CurrentProduction.Id && t.Userid == manager.Id);
                    db.Remove(productionManager);
                    db.SaveChanges();
                }
                else
                {
                    ProductionManager productionManager = new ProductionManager { Userid = manager.Id, Productionid = CurrentProduction.Id };
                    db.Add(productionManager);
                    db.SaveChanges();
                }
                Managers = new ObservableCollection<User>(db.Users.Where(u => u.ProductionManagers.Any(p => p.Productionid == CurrentProduction.Id)));
                PropertyChanged(this, new PropertyChangedEventArgs("Managers"));
                Visibility = Visibility.Collapsed;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}");
            }
        }

        public Visibility InResourceVisibility { get => inResourceVisibility; set { inResourceVisibility = value; PropertyChanged(this, new PropertyChangedEventArgs("InResourceVisibility")); } }
        public Visibility OutResourceVisibility { get => outResourceVisibility; set { outResourceVisibility = value; PropertyChanged(this, new PropertyChangedEventArgs("OutResourceVisibility")); } }
        public ObservableCollection<Product>? AllProducts { get => allProducts; set { allProducts = value; PropertyChanged(this, new PropertyChangedEventArgs("AllProducts")); } }
        public ObservableCollection<Delivery>? AllDeliveries { get => allDeliveries; set { allDeliveries = value; PropertyChanged(this, new PropertyChangedEventArgs("AllDeliveries")); } }
        public ObservableCollection<Warehouse>? AllWarehouses { get => allWarehouses; set { allWarehouses = value; PropertyChanged(this, new PropertyChangedEventArgs("AllWarehouses")); } }
        public ObservableCollection<Unit>? AllUnits { get => allUnits; set { allUnits = value; PropertyChanged(this, new PropertyChangedEventArgs("AllUnits")); } }
        public Product? SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedProduct"));
                SelectedDelivery = null;
                try
                {
                    AllDeliveries = new ObservableCollection<Delivery>(db.Deliveries.Where(d => d.Productid == SelectedProduct.Id).Include(d => d.Unit).Include(d => d.Warehouse).ToList());
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"{e.Message}");
                }
            }
        }
        public Delivery? SelectedDelivery { get; set; }
        public Warehouse? SelectedWarehouse { get; set; }
        public Unit? SelectedUnit { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int AddedAmount { get; set; }

        public void ResourceForm(object parameter)
        {
            if (parameter.ToString() == "In")
            {
                OutResourceVisibility = Visibility.Collapsed;
                if (InResourceVisibility == Visibility.Visible)
                {
                    InResourceVisibility = Visibility.Collapsed;
                }
                else
                {
                    InResourceVisibility = Visibility.Visible;
                    try
                    {
                        AllProducts = new ObservableCollection<Product>(db.Products.ToList());
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine($"{e.Message}");
                    }

                }
            }
            else
            {
                InResourceVisibility = Visibility.Collapsed;
                if (OutResourceVisibility == Visibility.Visible)
                {
                    OutResourceVisibility = Visibility.Collapsed;
                }
                else
                {
                    OutResourceVisibility = Visibility.Visible;
                    try
                    {
                        AllProducts = new ObservableCollection<Product>(db.Products.ToList());
                        AllWarehouses = new ObservableCollection<Warehouse>(db.Warehouses.ToList());
                        AllUnits = new ObservableCollection<Unit>(db.Units.ToList());
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine($"{e.Message}");
                    }
                }
            }
        }

        public void SaveResourceIn(object o)
        {
            if (SelectedDelivery == null || SelectedProduct == null)
            {
                MessageBox.Show("Wypełnij wszystkie pola");
                return;
            }
            if (AddedAmount > SelectedDelivery.CurrentAmount)
            {
                MessageBox.Show("Wybrana ilość jest większa od dostępnej ilośći surowca");
                return;
            }
            if (AddedAmount <= 0)
            {
                MessageBox.Show("Ilość musi być większa od 0");
                return;
            }

            try
            {
                ProductionDelivery pd = new ProductionDelivery { Productionid = CurrentProduction.Id, Deliveryid = SelectedDelivery.Id, Date = DateTime.Now, InOut = 1, Amount = AddedAmount };
                db.Add<ProductionDelivery>(pd);
                SelectedDelivery.CurrentAmount -= pd.Amount;
                CurrentProduction.ProductionPrice += SelectedDelivery.PriceByUnit * pd.Amount;
                db.SaveChanges();
                MainModel.UpdateViewCommand.Execute(new ProductionViewModel(CurrentProduction, MainModel, LoginUser));
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}");
            }
        }
        public void SaveResourceOut(object o)
        {
            if (SelectedProduct == null || SelectedUnit == null || SelectedWarehouse == null)
            {
                MessageBox.Show("Wypełnij wszystkie pola");
                return;
            }
            if (AddedAmount <= 0)
            {
                MessageBox.Show("Ilość musi być większa od 0");
                return;
            }

            try
            {
                Delivery newDelivery = new Delivery { Productid = SelectedProduct.Id, DeliveryDate = DateTime.Now, Amount = AddedAmount, ExpirationDate = ExpirationDate, CurrentAmount = AddedAmount, Unitid = SelectedUnit.Id, DeliveryNumber = db.Deliveries.Count() + 1, FullPrice = 0, PriceByUnit = 0, Warehouseid = SelectedWarehouse.Id };
                ProductionDelivery pd = new ProductionDelivery { Productionid = CurrentProduction.Id, Delivery = newDelivery, Date = DateTime.Now, InOut = 0, Amount = AddedAmount };
                db.Add<ProductionDelivery>(pd);
                db.SaveChanges();
                MainModel.UpdateViewCommand.Execute(new ProductionViewModel(CurrentProduction, MainModel, LoginUser));
            }
            catch (Exception e)
            {
                MessageBox.Show("Nastąpił błąd podczas połączenia z bazą");
            }
        }
    }
}
