using ClassLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.model.UsersModel
{
    public class Module : BaseEntity
    {
        public MainMenu MainMenu { get; set; }
        public int MainMenuId { get; set; }
        public string SubmenuName { get; set; }
        public string ModuleName { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string AddedBy { get; set; }
        public bool ISActive { get; set; } = true;

        

    }
}
