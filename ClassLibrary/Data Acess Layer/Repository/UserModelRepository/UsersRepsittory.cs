using ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto;
using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using ClassLibrary.Interface.User_Model_Interface;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.Collections.Immutable;

namespace ClassLibrary.Data_Acess_Layer.Repository.UserModelRepository
{
    public  class UsersRepsittory : IUser
    {
        private readonly StoreContext _context;

        public UsersRepsittory(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<DtoUsers>> GetAllActiveUsers()
        {
            var user = _context.users.Where(x => x.IsActive == true)
                                      .Select(x => new DtoUsers
                                      {
                                          Id = x.Id,
                                          FullName = x.FullName,
                                          UserName = x.UserName,
                                          Password = x.Password,
                                          RolesId = x.RolesId,
                                          RoleName = x.Roles.RoleName,
                                          DepartmentId = x.DepartmentId,
                                          DepartmentName = x.Department.DepartmentName,
                                          DateAdded = x.DateAdded.ToString("MM/dd/yyyy"),
                                          AddedBy = x.AddedBy,
                                         IsActive= x.IsActive

                                      });

            return await user.ToListAsync();
           
        }

        public async Task<IReadOnlyList<DtoUsers>> GetAllInActiveUsers()
        {
            var user = _context.users.Where(x => x.IsActive == false)
                                     .Select(x => new DtoUsers
                                     {
                                         Id = x.Id,
                                         FullName = x.FullName,
                                         UserName = x.UserName,
                                         Password = x.Password,
                                         RolesId = x.RolesId,
                                         RoleName = x.Roles.RoleName,
                                         DepartmentId = x.DepartmentId,
                                         DepartmentName = x.Department.DepartmentName,
                                         DateAdded = x.DateAdded.ToString("MM/dd/yyyy"),
                                         AddedBy = x.AddedBy,
                                         IsActive = x.IsActive

                                     });

            return await user.ToListAsync();

        }

        public async Task<bool> AddNewUsers(Users users)
        {
           var user = await _context.users.AddAsync(users);
            return true;
        }

        public async Task<bool> UpdateUsers(Users users)
        {
           var updateuser = await _context.users.Where(x=> x.Id == users.Id)
                                          .FirstOrDefaultAsync();

            updateuser.FullName = users.FullName;
            updateuser.UserName = users.UserName;
            updateuser.Password = users.Password;
            updateuser.RolesId= users.RolesId;
            updateuser.DepartmentId= users.DepartmentId;
            updateuser.AddedBy = users.AddedBy;
            updateuser.DateAdded = users.DateAdded;

            return true; 
        }

        public async Task<bool> UpdateActiveUsers(Users users)
        {
            var updateuser = await _context.users.Where(x => x.Id == users.Id)
                                         .FirstOrDefaultAsync();

            updateuser.IsActive = users.IsActive = true;
            return true;
        }

        public async Task<bool> UpdateInActiveUsers(Users users)
        {

            var updateuser = await _context.users.Where(x => x.Id == users.Id)
                                         .FirstOrDefaultAsync();

            updateuser.IsActive = users.IsActive = true;
            return true;
        }

        // validation


        public async Task<bool> ValidateDepartmentId(int id)
        {
            var validate = await _context.Departments.FindAsync(id);
             if(validate == null)
                return false;
             return true;     
        }

        public async Task<bool> ValidateRoleId(int id)
        {
            var validate = await _context.Role.FindAsync(id);
            if (validate == null)
                return false;
            return true;
        }

        public async Task<bool> ValidateUserId(int Id)
        {
            var validate = await _context.users.FindAsync(Id);
            if (validate == null)
                return false;
            return true;
        }
        public async Task<bool> ExistingUsername(string username)
        {
            return await _context.users.AnyAsync(x => x.UserName == username);
           
        }

       
    }
}
