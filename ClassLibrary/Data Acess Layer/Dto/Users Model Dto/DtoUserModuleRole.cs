using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto
{
    public class DtoUserModuleRole
    {

        public string RoleName { get; set; }
        public string MainMenu { get; set; }
        public int MainMenuId { get; set; }
        public string SubMenu { get; set; }
        public string ModuleName { get; set; }

        public string MenuPath { get; set; }

        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
       public bool IsActive { get; set; }
    }
}
