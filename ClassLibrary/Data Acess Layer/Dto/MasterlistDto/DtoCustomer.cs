using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto
{
    public class DtoCustomer
    {
        public int Id { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string MobileAddress { get; set; }
        public string Address { get; set; }
        public string DateAdded { get; set; } 
        public string AdddedBy { get; set; }
        public bool IsActive { get; set; }

    }
}
