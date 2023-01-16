using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace ClassLibrary.model.PoSummary
{
    public class PoSummary : BaseEntity
    {

        public int PrNumber { get; set; }

        [Column(TypeName = "Date")]
        public DateTime PrDate { get; set; } 
        public int PoNumber { get; set; }

        [Column(TypeName = "Date")]
        public DateTime PoDate { get; set; }

        public string ItemCodes { get; set; }

        public string ItemDescription { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Ordered { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Delivered { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Billed { get; set; }

        public string UOM { get; set; }
        public int Unitprice { get; set; }
        public string Vendorname { get; set; }

        public string Reasons { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime ImportDate { get; set; } = DateTime.Now;   
        public DateTime? ImportCancelled { get; set; }


    }
}
