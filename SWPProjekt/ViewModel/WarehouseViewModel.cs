using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignColors.Recommended;
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
        //-------------------------

        public List<Product> ProductList { get; set; }

        public WarehouseViewModel(Warehouse warehouse, List<Product> productname)
        {
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


            for (int i = 0; i < DeliverysId.Count; i++)
            {
                Products.AddRange(context.Products
                .Where(s => s.Id == DeliverysId[i])
                .ToList());
            }

            ProductList = Products;

            for(int i = 0;i < Products.Count; i++)
            {
                for (int j = i+1; j < Products.Count ;j++)
                {
                    if (Products[j].Name == Products[i].Name)
                    {
                        Products.RemoveAt(j);
                    }
                }

            }

            
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
                

                //Deliveries = new ObservableCollection<Delivery>(context.Deliveries.Where(x =>x.Productid == ProductList.));
            }
        }

    }

}
