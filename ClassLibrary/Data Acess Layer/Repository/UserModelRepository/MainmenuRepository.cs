using ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto;
using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using ClassLibrary.Interface.User_Model_Interface;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data_Acess_Layer.Repository.UserModelRepository
{
    public class MainmenuRepository :IMainmenu
    {
        private readonly StoreContext _context;

        public MainmenuRepository(StoreContext context)
        {
           _context= context;
        }

        public async Task<bool> AddNewMainmenu(MainMenu mainmenu)
        {

            mainmenu.AddedBy = "Admin";
            mainmenu.ModifiedBy = "Admin";

            if (mainmenu.AddedBy == null)
                mainmenu.AddedBy = "Admin";

            
            await _context.Mainmenu.AddAsync(mainmenu);
            return true;
        }

    

        public async Task<IReadOnlyList<DtoMainMenu>> GetAllActiveMainmenu()
        {
            var mainmenu = _context.Mainmenu.Where(x => x.IsActive == true)
                                            .Select(x => new DtoMainMenu
                                            {
                                                Id = x.Id,
                                                ModuleName= x.ModuleName,
                                                DateAdded = x.DateAdded.ToString("MM/dd/yyyy"),
                                                AddedBy= x.AddedBy,
                                                ModifiedBy = x.ModifiedBy,
                                                MenuPath= x.MenuPath,
                                                IsActive= x.IsActive


                                            });

            return await mainmenu.ToListAsync();
    }

        public async Task<IReadOnlyList<DtoMainMenu>> GetAllInActiveMainmenu()
        {
            var mainmenu = _context.Mainmenu.Where(x => x.IsActive == true)
                                            .Select(x => new DtoMainMenu
                                            {
                                                Id = x.Id,
                                                ModuleName = x.ModuleName,
                                                DateAdded = x.DateAdded.ToString("MM/dd/yyyy"),
                                                AddedBy = x.AddedBy,
                                                ModifiedBy = x.ModifiedBy,
                                                MenuPath = x.MenuPath,
                                                IsActive = x.IsActive


                                            });

            return await mainmenu.ToListAsync();
        }


        public async  Task<bool> UpdateMainmenu(MainMenu main)
        {
            var mainmenu = await _context.Mainmenu.Where(x => x.Id == main.Id)
                                                  .FirstOrDefaultAsync();

           mainmenu.ModuleName = main.ModuleName;
            mainmenu.MenuPath = main.MenuPath;
            mainmenu.ModifiedBy = main.ModifiedBy;

            if (main.ModifiedBy == null)
                mainmenu.ModifiedBy = "Admin";

            return true;
        }

        public async Task<bool> UpdateActiveMainmenu(MainMenu main)
        {
            var mainmenu = await _context.Mainmenu.Where(x => x.Id == main.Id)
                                                   .FirstOrDefaultAsync();

            mainmenu.IsActive = main.IsActive = true;
            return true;
        }

        public async Task<bool> UpdateInActiveMainmenu(MainMenu main)
        {
            var mainmenu = await _context.Mainmenu.Where(x => x.Id == main.Id)
                                                  .FirstOrDefaultAsync();

            mainmenu.IsActive = main.IsActive = false;
            return true;
        }


        public async  Task<bool> ValidatemainmenuId(int id)
        {
            var valid = await _context.Mainmenu.FindAsync(id);

            if(valid == null)
                return false;
            
            return true;
        }
        public async Task<bool> ExistModuleName(string modulename)
        {
            return await _context.Mainmenu.AnyAsync(x => x.ModuleName == modulename);   
        }

     
    }
}
