using ClassLibrary.Data_Acess_Layer.Dto.ImportDto;
using ClassLibrary.Data_Acess_Layer.Dto.Recieving.WareHouserReceivingDto;
using ClassLibrary.Data_Acess_Layer.model.Receiving;
using ClassLibrary.Helper;
using ClassLibrary.Interface.WareHouse_Interface;
using ClassLibrary.model.PoSummary;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data_Acess_Layer.Repository.Receiving_Repository
{
    public class WarehouseReceivingRepository : IWareHouseReceiving
    {
        private readonly StoreContext _context;

        public WarehouseReceivingRepository(StoreContext context)
        {
            _context = context;
        }

        public async  Task<bool> AddNewReceivingDetais(Warehouse_Receiving warehouse_Recieving)
        {
           await _context.WarehouseRecieve.AddAsync(warehouse_Recieving);
            return true;
        }

       

        public async Task<PagedList<DtoWareHouseReceiving>> GetAllPoSummaryWithPagination(UserParameter userParams)
        {
            var poSummary = (from PoSummary in _context.PoSummaries
                             where PoSummary.IsActive == true
                             join warehouse in _context.WarehouseRecieve
                             on PoSummary.Id equals warehouse.Po_SummaryID into leftJ
                             from receive in leftJ.DefaultIfEmpty()

                             select new DtoWareHouseReceiving
                             {
                                 Id = PoSummary.Id,
                                 Ponumber = PoSummary.PoNumber,
                                 PoDate = PoSummary.PoDate.ToString("MM/dd/yyyy"),
                                 PrNumber = PoSummary.PrNumber,
                                 PrDate = PoSummary.PrDate.ToString("MM/dd/yyyy"),
                                 ItemCode = PoSummary.ItemCodes,
                                 ItemDescription = PoSummary.ItemDescription,
                                 Vendor = PoSummary.Vendorname,
                                 Uom = PoSummary.UOM,
                                 QuantityOrdered = PoSummary.Ordered,
                                 IsActive = PoSummary.IsActive,
                                 ActualRemaining = 0,
                                 ActualGood = receive != null && receive.IsActive != false ? receive.ActuallDelivered : 0, // Use the variable that use for addPoSummary

                             }).GroupBy(x => new
                             {

                                 x.Id,
                                 x.Ponumber,
                                 x.PoDate,
                                 x.PrNumber,
                                 x.PrDate,
                                 x.ItemCode,
                                 x.ItemDescription,
                                 x.Uom,
                                 x.Vendor,
                                 x.QuantityOrdered,
                                 x.IsActive


                             }).Select(receive => new DtoWareHouseReceiving
                             {
                                 Id = receive.Key.Id,
                                 Ponumber = receive.Key.Ponumber,
                                 PoDate = receive.Key.PoDate,
                                 PrNumber = receive.Key.PrNumber,
                                 PrDate = receive.Key.PrDate,
                                 ItemCode = receive.Key.ItemCode,
                                 ItemDescription = receive.Key.ItemDescription,
                                 Uom = receive.Key.Uom,
                                 Vendor = receive.Key.Vendor,
                                 QuantityOrdered = receive.Key.QuantityOrdered,
                                 ActualGood = receive.Sum(x => x.ActualGood),
                                 ActualRemaining = receive.Key.QuantityOrdered - (receive.Sum(x => x.ActualGood)),
                                 IsActive = receive.Key.IsActive,

                             })
                             .OrderBy(x => x.Ponumber)
                             .Where(x => x.ActualRemaining != 0 && (x.ActualRemaining > 0))
                             .Where(x => x.IsActive == true);

            return await PagedList<DtoWareHouseReceiving>.CreateAsync(poSummary, userParams.PageNumber, userParams.PageSize);

                           
        }

        public async Task<PagedList<DtoWareHouseReceiving>> GetPoSummaryByStatusWithPaginationOrig(UserParameter userParams , string search)
        {
           var poSummary = (from PoSummary in _context.PoSummaries
                            where PoSummary.IsActive == true
                            join warehouse in _context.WarehouseRecieve
                            on PoSummary.Id equals warehouse.Po_SummaryID into leftJ
                            from receive in leftJ.DefaultIfEmpty()
                            
                            select new DtoWareHouseReceiving
                            {
                                Id = PoSummary.Id,
                                Ponumber = PoSummary.PoNumber,
                                PoDate = PoSummary.PoDate.ToString("MM/dd/yyyy"),
                                PrNumber = PoSummary.PrNumber,
                                PrDate = PoSummary.PrDate.ToString("MM/dd/yyyy"),
                                ItemCode = PoSummary.ItemCodes,
                                ItemDescription = PoSummary.ItemDescription,
                                Vendor = PoSummary.Vendorname,
                                Uom = PoSummary.UOM,
                                QuantityOrdered = PoSummary.Ordered,
                                IsActive = PoSummary.IsActive,
                                ActualRemaining = 0,
                                ActualGood = receive != null && receive.IsActive !=false ? receive.ActuallDelivered: 0,

                            }).GroupBy(x => new
                            {
                                x.Id,
                                x.Ponumber,
                                x.PoDate,
                                x.PrNumber,
                                x.PrDate,
                                x.ItemCode,
                                x.ItemDescription,
                                x.Uom,
                                x.Vendor,
                                x.QuantityOrdered,
                                x.IsActive

                            }). Select(receive => new DtoWareHouseReceiving
                            {
                                Id = receive.Key.Id,
                                Ponumber = receive.Key.Ponumber,
                                PoDate = receive.Key.PoDate,
                                PrNumber = receive.Key.PrNumber,
                                PrDate = receive.Key.PrDate,
                                ItemCode = receive.Key.ItemCode,
                                ItemDescription = receive.Key.ItemDescription,
                                Uom = receive.Key.Uom,
                                Vendor = receive.Key.Vendor,
                                QuantityOrdered = receive.Key.QuantityOrdered,
                                ActualGood = receive.Sum(x => x.ActualGood),
                                ActualRemaining = receive.Key.QuantityOrdered - (receive.Sum(x => x.ActualGood)),
                                IsActive = receive.Key.IsActive,

                            }).OrderBy(x=> x.Ponumber)
                               .Where(x => x.ActualRemaining != 0 &&(x.ActualRemaining > 0))
                               .Where(x => x.IsActive == true)
                               .Where(x => Convert.ToString(x.ItemDescription).ToLower()
                               .Contains(search.Trim().ToLower()));


            return await PagedList<DtoWareHouseReceiving>.CreateAsync(poSummary, userParams.PageNumber, userParams.PageSize);
        }


        public async Task<bool> CancelPoSummary(PoSummary summary)
        {
            var cancel = await _context.PoSummaries.Where(x => x.Id == summary.Id)
                                                   .FirstOrDefaultAsync();

            cancel.IsActive = summary.IsActive = false;
            cancel.ImportCancelled = summary.ImportCancelled;

            return true;
            
        }

       
    }
}
