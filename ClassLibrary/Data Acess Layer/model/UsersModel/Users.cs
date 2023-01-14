using ClassLibrary.model;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.model.UsersModel
{
    public class Users : BaseEntity
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Roles Roles { get; set; }
        public int RolesId { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }





    }
}
