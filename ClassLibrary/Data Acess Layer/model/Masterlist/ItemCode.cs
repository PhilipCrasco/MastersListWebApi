using System.ComponentModel;

namespace ClassLibrary.model.Masterlist
{
    public class ItemCode : BaseEntity
    {
        public string ItemCodes { get; set; }
        public string ItemDescription { get; set; }

        public Uom Uom { get; set; }
        public int UomId { get; set; }
        public DateTime Dateadded { get; set; } = DateTime.Now;
        public string Addedby { get; set; }
        public bool IsActive { get; set; }
        
    }
}
