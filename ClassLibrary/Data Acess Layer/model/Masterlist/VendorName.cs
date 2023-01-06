using System.Net.Http.Headers;

namespace ClassLibrary.model
{
    public class VendorName : BaseEntity
    {
        
        public string  VendorCode { get; set; }
        public string VendorcodeName { get; set; }
        public string Location { get; set; }
        public string Addedby { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsActive { get; set; }




    }
}
