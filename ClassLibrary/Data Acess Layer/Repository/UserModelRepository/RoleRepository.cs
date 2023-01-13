using ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto;
using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using ClassLibrary.Interface.User_Model_Interface;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data_Acess_Layer.Repository.UserModelRepository
{
    public class RoleRepository : IRole
    {
        private readonly StoreContext _context;

        public RoleRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewRole(Roles role)
        {
             await _context.Role.AddAsync(role);
            return true;
        } 

        public  async Task<IReadOnlyList<DtoRoles>> GetAllActiveRoles()
        {
            var roles = _context.Role.Where(x => x.IsActive == true)
                                      .Select(x => new DtoRoles
                                      {

                                          Id = x.Id,
                                          RoleCode = x.RoleCode,
                                          RoleName = x.RoleName,
                                          IsActive = x.IsActive,
                                          DateAdded = x.DateAdded.ToString("MM/dd/yyyy"),
                                          AddedBy = x.AddedBy,
                                         


                                      }) ; 
            return await roles.ToListAsync();
        }

        public  async Task<IReadOnlyList<DtoRoles>> GetAllInActiveRoles()
        {
            var roles = _context.Role.Where(x => x.IsActive == true)
                                      .Select(x => new DtoRoles
                                      {

                                          Id = x.Id,
                                          RoleCode = x.RoleCode,
                                          RoleName = x.RoleName,
                                          IsActive = x.IsActive,
                                          DateAdded = x.DateAdded.ToString("MM/dd/yyyy"),
                                          AddedBy = x.AddedBy,



                                      });
            return await roles.ToListAsync();
        }

        public async Task<bool> UpdateRoles(Roles role)
        {
            var updaterole = await _context.Role.Where(x => x.Id == role.Id)
                                                 .FirstOrDefaultAsync();

            updaterole.RoleCode = role.RoleCode;
            updaterole.RoleName = role.RoleName;
            updaterole.DateAdded = role.DateAdded;
            updaterole.AddedBy = role.AddedBy;

            return true;
        }

        public async Task<bool> UpdateActiveRoles(Roles role)
        {
           
            var updaterole = await _context.Role.Where(x => x.Id == role.Id)
                                              .FirstOrDefaultAsync();

            updaterole.IsActive = role.IsActive == true;

            return true;

        }

        public async  Task<bool> UpdateInActiveRoles(Roles role)
        {
          

            var updaterole = await _context.Role.Where(x => x.Id == role.Id)
                                              .FirstOrDefaultAsync();

            updaterole.IsActive = role.IsActive == false;

            return true;
        }

     


       //Validation

        public async Task<bool> ValidationCodeName(string name)
        {
            return await _context.Role.AnyAsync(x => x.RoleName == name);
            
        }

        public async Task<bool> ValidationId(int id)
        {
           var validationId = await _context.Role.FindAsync(id);

            if( validationId == null)
            {
                return false;
            }
            return true;    

            
        }
    }
}
