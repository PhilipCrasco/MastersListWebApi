using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto
{
    public class DtoMainMenu
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string DateAdded { get; set; } 
        public string AddedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public string MenuPath { get; set; }

        public string ModifiedBy { get; set; }
    }
}
