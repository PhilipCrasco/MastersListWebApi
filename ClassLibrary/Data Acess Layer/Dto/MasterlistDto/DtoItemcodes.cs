using ClassLibrary.model;
using ClassLibrary.model.Masterlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto
{
    public class DtoItemcodes
    {
        public int Id { get; set; }
        public string ItemCodes { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCodeId { get; set; }
        public int ItemCategoryId { get; set; }
        public string ItemCategoryDecription { get; set; }

        public string Uom { get; set; }
        public int UomId { get; set; }
        public int BufferLevel { get; set; }
        public string Dateadded { get; set; } 
        public string Addedby { get; set; }
        public bool IsActive { get; set; }
    }
}
