using ClassLibrary.model;

namespace ClassLibrary.Data_Acess_Layer.model.UsersModel
{
    public class UserRoleModule : BaseEntity
    {

        
        public int RoleModuleId { get; set; }
        
        public int rolemoduleIdformodule { get; set; }

        public Roles Roles { get; set; }
        public int RoleId { get; set; }

        public Module Module { get; set; }
        public int ModuleId { get; set; }
        public bool IsAdmin { get; set; }   

    }
}
