using ClassLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.model.Masterlist
{
    public class ItemCategory : BaseEntity
    {
        public string ItemCategoryName { get; set; }
        public DateTime DatetAdded { get; set; }
        public string AddedBy { get; set; }
        public bool IsActive { get; set; }



    }
}
