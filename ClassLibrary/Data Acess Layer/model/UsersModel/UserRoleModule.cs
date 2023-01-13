using ClassLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.model.UsersModel
{
    public class UserRoleModule : BaseEntity
    {
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public bool IsAdmin { get; set; }   

    }
}
