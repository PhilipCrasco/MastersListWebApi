using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto
{
    public class DtoRoles
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public bool IsActive { get; set; }
        public string DateAdded { get; set; }
        public string AddedBy { get; set; }
        public string DateModified { get; set; }
    }
}
