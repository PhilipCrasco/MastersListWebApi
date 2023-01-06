namespace ClassLibrary.model.Masterlist
{
    public class Uom : BaseEntity
    {
        
        public string UomCode { get; set; }
       
        public string UomDescription { get; set; }

        public string Addedby { get; set; }
        public DateTime Dateadded { get; set; }= DateTime.Now;
        public bool IsActive { get; set; }
    }
}
