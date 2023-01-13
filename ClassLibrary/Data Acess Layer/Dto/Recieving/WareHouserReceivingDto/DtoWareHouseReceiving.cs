
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ClassLibrary.Data_Acess_Layer.Dto.Recieving.WareHouserReceivingDto
{
    public class DtoWareHouseReceiving
    {
        public int Id { get; set; }   
        public int Ponumber { get; set; }
        public string PoDate { get; set; }
        public int PrNumber { get; set; }
        public string PrDate { get; set; }
        public string  ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string Vendor { get; set; }  
        public string Uom { get; set; }
        public decimal QuantityOrdered { get; set; }
        public  decimal ActualGood { get; set; }
        
        public decimal Reject { get; set; }
        public  bool IsActive { get; set; }
        public decimal ActualRemaining { get; set; }
        


    }
}
