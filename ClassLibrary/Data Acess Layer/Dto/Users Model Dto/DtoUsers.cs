using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto
{
    public class DtoUsers
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int RolesId { get; set; }
       
        public string RoleName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public string DateAdded { get; set; } 
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string DateModified { get; set; }
    }
}
