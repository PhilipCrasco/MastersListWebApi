using ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto;
using ClassLibrary.Data_Acess_Layer.model.UsersModel;

namespace ClassLibrary.Interface.User_Model_Interface
{
    public interface IMainmenu
    {

        Task<IReadOnlyList<DtoMainMenu>> GetAllActiveMainmenu ();
        Task<IReadOnlyList<DtoMainMenu>> GetAllInActiveMainmenu();

        Task<bool> AddNewMainmenu(MainMenu mainmenu);

        Task<bool> UpdateMainmenu(MainMenu main);

        Task<bool> UpdateActiveMainmenu(MainMenu main);

        Task<bool> UpdateInActiveMainmenu(MainMenu main);

        Task<bool> ValidatemainmenuId(int id);
        Task<bool> ExistModuleName(string modulename);





    }
}
