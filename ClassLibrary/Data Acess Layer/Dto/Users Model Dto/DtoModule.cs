using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto
{
    public class DtoModule
    {
        public int Id { get; set; }
        public int MainMenuId { get; set; }
        public string MainMenuName { get; set; }
        public string SubmenuName { get; set; }
        public string ModuleName { get; set; }
        public string DateAdded { get; set; } 
        public string AddedBy { get; set; }

        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
