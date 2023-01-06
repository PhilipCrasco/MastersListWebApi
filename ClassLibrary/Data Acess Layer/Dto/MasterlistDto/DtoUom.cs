namespace ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto
{
    public class DtoUom
    {

        public int Id { get; set; }
        public string UomCode { get; set; }

        public string UomDescription { get; set; }

        public string Addedby { get; set; }
        public DateTime Dateadded { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }

        

    }
}
