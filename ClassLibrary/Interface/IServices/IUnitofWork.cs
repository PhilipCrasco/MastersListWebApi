using ClassLibrary.Interface.Import_Interface;
using ClassLibrary.Interface.Inter_Core;
using ClassLibrary.Interface.Masterlist_Interface;
using ClassLibrary.Interface.User_Model_Interface;
using ClassLibrary.Interface.WareHouse_Interface;

namespace ClassLibrary.Interface.IServices
{
    public interface IUnitofWork
    {

        ItemCodesInterface itemCodes { get; }
        UomInterface oums { get; }
        VendorInterface vendor { get; }

        PoSummaryInterface poSummary { get; }

        CustomerInterface customer { get; }

        ItemCategoryInterface ItemCategory { get; }


        //Recieving

        IWareHouseReceiving wareHouseReceiving { get; }


        // User Model

        IUser user { get; }
        IRole roles { get; }
        IDepartment department { get; }
        IMainmenu mainmenu { get; }
        IModule module { get; }

       
        Task CompleteAsync();

    }
}
