using ClassLibrary.model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.model.UsersModel
{
    public class Department : BaseEntity
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }  
        public string AddedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateAdded { get; set; } = DateTime.Now;
        

    }
}
