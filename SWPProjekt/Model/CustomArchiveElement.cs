using System;

namespace SWPProjekt.Model
{
    public class CustomArchiveElement
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public float Amount { get; set; }
        public string UnitName { get; set; }

        public CustomArchiveElement(int Id,string Type, DateTime? Date,
            string Name, bool Status, float Amount, string Unit)
        {
            this.Id = Id;
            this.Type = Type;
            this.Date = Date;
            this.Name = Name;
            this.Status = Status;
            this.Amount = Amount;
            this.UnitName = Unit;
        }

        public CustomArchiveElement() { }
    }

}
