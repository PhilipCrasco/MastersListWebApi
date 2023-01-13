using ClassLibrary.model;

namespace ClassLibrary.Data_Acess_Layer.model.UsersModel
{
    public class Roles : BaseEntity
    {
        public string RoleName { get; set; }    
        public string RoleCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateAdded {get; set; } = DateTime .Now;
        public string AddedBy { get; set; } 
        public DateTime? DateModified { get; set; }
    }
}
