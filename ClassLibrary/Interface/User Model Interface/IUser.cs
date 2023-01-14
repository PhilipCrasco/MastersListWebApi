using ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto;
using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface.User_Model_Interface
{
     public interface IUser
    {

        Task<IReadOnlyList<DtoUsers>> GetAllActiveUsers();
        Task<IReadOnlyList<DtoUsers>> GetAllInActiveUsers();

        Task<bool> AddNewUsers(Users users);

        Task<bool> UpdateUsers(Users users);
        Task<bool> UpdateActiveUsers(Users users);
        Task<bool> UpdateInActiveUsers(Users users);



        // validation

        Task<bool> ValidateRoleId(int id);
        Task<bool> ValidateDepartmentId(int id);

        Task<bool> ValidateUserId(int Id);

        Task<bool> ExistingUsername(string username);



    }
}
