using ClassLibrary.model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Data_Acess_Layer.model.Receiving
{
    public class Warehouse_Reject : BaseEntity
    {
        [Column(TypeName ="decimal(18,2)")]
        public decimal Quantity { get; set; }

        public string Remarks { get; set; }
        public string WarehouseRecievingId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime RejectByDate { get; set; }

        public bool IsActive { get; set; }
        public string RejectedBy { get; set; }


       
    }
}
