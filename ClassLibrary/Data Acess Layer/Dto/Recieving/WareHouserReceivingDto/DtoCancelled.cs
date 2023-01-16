namespace ClassLibrary.Data_Acess_Layer.Dto.Recieving.WareHouserReceivingDto
{
    public  class DtoCancelled
    {
        public int Id { get; set; }
        public int PoNumber { get; set; }
        public string ItemCode { get; set; }

        public string ItemDescription { get; set; } 
        public  string Vendor { get; set; }

        public decimal QuantityOrdered { get; set; }
        public decimal QuatityCancel { get; set; }

        public decimal QuantityGood { get; set; }   

        public string DateCancelled { get; set; }
        public string Remarks { get; set; }
       
        public bool IsActive { get; set; }  

    }
}
