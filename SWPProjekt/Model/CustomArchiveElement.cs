using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.Model
{
    public class CustomArchiveElement
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public float Amount { get; set; }
        public string Product { get; set; }

        public CustomArchiveElement(int Id, DateTime? Date, string Name, bool Status, float Amount, string Product)
        {
            this.Id = Id;
            this.Date = Date;
            this.Name = Name;
            this.Status = Status;
            this.Amount = Amount;
            this.Product = Product;
        }

        public CustomArchiveElement() { }
    }

}
