using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class CombinedDeliveryData
    {
        public int Id { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string ProducerName { get; set; } 

        public float Amount { get; set; }

        public int CurrentAmount { get; set; }

        public float FullPrice { get; set; }

        public string UnitName { get; set; }
}

