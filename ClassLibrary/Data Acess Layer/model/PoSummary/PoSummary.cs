using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace ClassLibrary.model.PoSummary
{
    public class PoSummary : BaseEntity
    {

        public int PrNumber { get; set; }

        [Column(TypeName = "Date")]
        public DateTime PrDate { get; set; } = DateTime.Now;
        public int PoNumber { get; set; }
        public string ItemCodes { get; set; }

        public string ItemDescription { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Ordered { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Delivered { get; set; }

        public string UOM { get; set; }
        public int Unitprice { get; set; }
        public int Vendorname { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime ImportDate { get; set; }    
        public DateTime? ImportCancelled { get; set; }


    }
}
