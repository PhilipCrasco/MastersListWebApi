namespace ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto
{
    public class DtoVendor
    {
       public int Id { get; set; }
        public string VendorCode { get; set; }
        public string VendorcodeName { get; set; }
        public string Location { get; set; }
        public string Addedby { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsActive { get; set; }

    }
}
