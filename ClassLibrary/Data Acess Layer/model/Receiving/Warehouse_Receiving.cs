using ClassLibrary.model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Data_Acess_Layer.model.Receiving
{
    public class Warehouse_Receiving : BaseEntity
    {
        public int Po_SummaryID { get; set; }
        public string Ponumber { get; set; }
        public string Itemcodes{ get; set; }
        public string Uom { get; set; } 
        public string ItemDescription { get; set; }
        public string Vendor { get; set; }

        [Column(TypeName = "Date")]
        public DateTime RecievingDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime RecievingTime { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal ActuallDelivered { get; set;}


        [Column(TypeName = "decimal(18,2)")]
        public decimal QuantityGood { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal ActualGood { get; set; }

        public bool IsWareHouseRecieve { get; set; }    
        public bool IsActive { get; set; }
        
        public bool ConfirmRejectByWareHouse { get; set; }
        public string RecievedBy { get; set; }

        public int BatchCount { get; set; }

        [Column(TypeName = "Date")]
       public DateTime CancelDate { get; set; }

        public string CancelBy { get; set; }



    }
}
