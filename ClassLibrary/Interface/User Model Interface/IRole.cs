using ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto;
using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface.User_Model_Interface
{
     public interface IRole
    {
        Task<IReadOnlyList<DtoRoles>> GetAllActiveRoles ();
        Task<IReadOnlyList<DtoRoles>> GetAllInActiveRoles();
        Task<bool> AddNewRole(Roles role);

        Task<bool> UpdateRoles(Roles role);
        Task<bool> UpdateActiveRoles(Roles role);
        Task<bool> UpdateInActiveRoles(Roles role);
        //Valdidation

        Task<bool> ValidationCodeName (string name);
        Task <bool> ValidationId (int id);
    }
}
