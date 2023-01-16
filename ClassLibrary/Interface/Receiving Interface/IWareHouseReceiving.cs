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

        Task<bool> EditReceivingDetails(Warehouse_Receiving recieve);

        Task<bool> ValidateActualRemaining(Warehouse_Receiving receiving);

        Task<PagedList<DtoCancelled>> GetAllCancelledPoWithPagination(UserParameter userParams);
        Task<PagedList<DtoCancelled>> GetAllCancelledPoWithPaginationOrig(UserParameter userParams , string search);


        Task<PagedList<DtoWareHouseReceiving>> GetAllPoSummaryWithPagination(UserParameter userParams);
        Task<PagedList<DtoWareHouseReceiving>> GetPoSummaryByStatusWithPaginationOrig(UserParameter userParams , string search);

        // Validation 
        Task<bool> ValidatePoId(int id);

    }
}
