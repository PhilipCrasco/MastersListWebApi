using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto
{
    public class DtoDepartment
    {
        public int Id { get; set; }
        public string DepartmentCode { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string AddedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public string DateAdded { get; set; }
    }
}
