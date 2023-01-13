using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto
{
    public class DtoItemCategory
    {
        public int Id { get; set; }
        public string ItemCategoryName { get; set; }
        public string DatetAdded { get; set; }
        public string AddedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
