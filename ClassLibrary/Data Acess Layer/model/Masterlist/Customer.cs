using ClassLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.model.Masterlist
{
    public class Customer : BaseEntity
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string MobileAddress { get; set; }
        public string Address { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string AdddedBy { get; set; }
        public bool IsActive { get; set; }

       


        

    }
}
