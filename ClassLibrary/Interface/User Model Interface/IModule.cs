using ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto;
using ClassLibrary.Data_Acess_Layer.model.UsersModel;

namespace ClassLibrary.Interface.User_Model_Interface
{
    public interface IModule
    {
        Task<IReadOnlyList<DtoModule>> GetAllActiveModules();
        Task<IReadOnlyList<DtoModule>> GetAllInActiveModules();
        Task<bool> AddNewModule(Module module);

        Task<bool> UpdateModule(Module module);
        Task<bool> UpdateActiveModule(Module module);
        Task<bool> UpdateInActiveModule(Module module);


        Task<bool> ValidateModuleId(int Id);
        Task<bool> ValidMainmenuId (int Id);
        Task<bool> ExistModuleName(string moduleName);
        Task <bool> ExistSubMainMenuName (string submenuname);
    }
}
