using ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto;
using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using ClassLibrary.Interface.User_Model_Interface;
using ClassLibrary.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ClassLibrary.Data_Acess_Layer.Repository.UserModelRepository
{
    public class ModuleRepository :IModule
    {
        private readonly StoreContext _context;
        public ModuleRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<DtoModule>> GetAllActiveModules()
        {
            var module = _context.Modules.Where(x => x.ISActive == true)
                                         .Select(x => new DtoModule
                                         {
                                             Id= x.Id,
                                             MainMenuId= x.MainMenuId,
                                             MainMenuName = x.MainMenu.ModuleName,
                                             SubmenuName= x.SubmenuName,
                                             ModuleName= x.ModuleName,
                                             AddedBy= x.AddedBy,
                                             ModifiedBy= x.ModifiedBy,
                                             DateAdded = x.DateAdded.ToString("MM/dd/yyyy"),
                                             IsActive = x.ISActive

                                         });

            return await module.ToListAsync();
        }

        public async Task<IReadOnlyList<DtoModule>> GetAllInActiveModules()
        {
            var module = _context.Modules.Where(x => x.ISActive == true)
                                        .Select(x => new DtoModule
                                        {
                                            Id = x.Id,
                                            MainMenuId = x.MainMenuId,
                                            MainMenuName = x.MainMenu.ModuleName,
                                            SubmenuName = x.SubmenuName,
                                            ModuleName = x.ModuleName,
                                            AddedBy = x.AddedBy,
                                            ModifiedBy = x.ModifiedBy,
                                            DateAdded = x.DateAdded.ToString("MM/dd/yyyy"),
                                            IsActive = x.ISActive

                                        });

            return await module.ToListAsync();

        }
        public async Task<bool> AddNewModule(Module module)
        {
            
            module.ModifiedBy = "Admin";
            if(module.AddedBy == null)
                module.AddedBy = "Admin";

            await _context.Modules.AddAsync(module);
            return true;
        }
        public async Task<bool> UpdateModule(Module module)
        {
            var modules = await _context.Modules.Where(x=> x.Id ==module.Id)
                                                .FirstOrDefaultAsync();

            modules.MainMenuId = module.MainMenuId;
           modules.SubmenuName = module.SubmenuName;
            modules.ModuleName = module.ModuleName;
            modules.ModifiedBy =module.ModifiedBy;

            if (module.ModifiedBy == null)
                modules.ModifiedBy = "Admin";

            return true;
           
            
        }

        public async Task<bool> UpdateActiveModule(Module module)
        {
            var modules = await _context.Modules.Where(x => x.Id == module.Id)
                                              .FirstOrDefaultAsync();

            modules.ISActive = module.ISActive = true;

            return true;
        }

        public async Task<bool> UpdateInActiveModule(Module module)
        {
            var modules = await _context.Modules.Where(x => x.Id == module.Id)
                                              .FirstOrDefaultAsync();

            modules.ISActive = module.ISActive = true;

            return true;
        }


        public async  Task<bool> ValidateModuleId(int Id)
        {
           var validate = await _context.Modules.FindAsync(Id);    

            if(validate == null)
                return false;
            return true;

        }

        public async Task<bool> ValidMainmenuId(int Id)
        {
            var validate = await _context.Mainmenu.FindAsync(Id);
            if(validate == null) 
                return false;
            return true;
        }

        public async Task<bool> ExistModuleName(string moduleName)
        {
           return await _context.Modules.AnyAsync(x => x.ModuleName == moduleName);
        }

        public async Task<bool> ExistSubMainMenuName(string submenuname)
        {
            return await _context.Modules.AnyAsync(x => x.SubmenuName == submenuname);
        }


    }
}
