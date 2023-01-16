using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.Dto.Recieving.WareHouserReceivingDto
{
    public class DtoPoSummaryCheckList
    {
        public int Id { get; set; }
        public int PoNumber { get; set; }
        public int PrNumber { get; set; }
        public DateTime PrDate { get; set; }
        public DateTime PoDate { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string Vendor { get; set; }
        public string UOM { get; set; }
        public decimal QuantityOrdered { get; set; }
        public decimal ActualGood { get; set; }
        public decimal ActualRemaining { get; set; }
        public bool IsActive { get; set; }
        public bool IsWarehouseReceived { get; set; }
        public bool IsWarehouseIsActive { get; set; }
    }
}
