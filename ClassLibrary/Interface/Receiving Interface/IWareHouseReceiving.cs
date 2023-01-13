using ClassLibrary.Data_Acess_Layer.Dto.ImportDto;
using ClassLibrary.Data_Acess_Layer.Dto.Recieving.WareHouserReceivingDto;
using ClassLibrary.Data_Acess_Layer.model.Receiving;
using ClassLibrary.Helper;
using ClassLibrary.model.PoSummary;

namespace ClassLibrary.Interface.WareHouse_Interface
{
    public interface IWareHouseReceiving
    {

        Task<bool> AddNewReceivingDetais(Warehouse_Receiving warehouse_Recieving);

        Task<bool> CancelPoSummary(PoSummary summary);

        Task<PagedList<DtoWareHouseReceiving>> GetAllPoSummaryWithPagination(UserParameter userParams);
        Task<PagedList<DtoWareHouseReceiving>> GetPoSummaryByStatusWithPaginationOrig(UserParameter userParams , string search);

        // Validation 


       
    }
}
