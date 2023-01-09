using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.Dto.ImportDto
{
     public class DtoPoSummary
    {
        public int Id { get; set; }
        public int PrNumber { get; set; }


        public string PrDate { get; set; }
        public int PoNumber { get; set; }

        public string PoDate { get; set; }
        public string ItemCodes { get; set; }

        public string ItemDescription { get; set; }


        public decimal Ordered { get; set; }


        public decimal Delivered { get; set; }

        public string UOM { get; set; }
        public int Unitprice { get; set; }
        public int Vendorname { get; set; }



    }
}
