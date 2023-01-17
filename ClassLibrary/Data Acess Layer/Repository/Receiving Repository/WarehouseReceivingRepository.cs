using ClassLibrary.Data_Acess_Layer.Dto.ImportDto;
using ClassLibrary.Data_Acess_Layer.Dto.Recieving.WareHouserReceivingDto;
using ClassLibrary.Data_Acess_Layer.model.Receiving;
using ClassLibrary.Helper;
using ClassLibrary.Interface.WareHouse_Interface;
using ClassLibrary.model.PoSummary;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

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

        public async Task<bool> EditReceivingDetails(Warehouse_Receiving recieve)
        {
            DateTime dateAdd = DateTime.Now.AddDays(31);
            var existingInfo = await _context.WarehouseRecieve.Where(x => x.Po_SummaryID == recieve.Po_SummaryID)
                                                              .FirstOrDefaultAsync();

            recieve.IsActive = recieve.IsActive = true;

            recieve.RecievingDate = DateTime.Now;

            await AddNewReceivingDetais(recieve);
            return true;


        }



        public async Task<bool> ValidateActualRemaining(Warehouse_Receiving receiving)
        {
            var validateActualRemaining = await (from PoSummary in _context.PoSummaries
                                                 join receive in _context.WarehouseRecieve on PoSummary.Id equals receive.Po_SummaryID into leftJ
                                                 from receive in leftJ.DefaultIfEmpty()
                                                 where PoSummary.IsActive == true
                                                 select new DtoPoSummaryCheckList
                                                 {
                                                     Id = PoSummary.Id,
                                                     PoNumber = PoSummary.PoNumber,
                                                     ItemCode = PoSummary.ItemCodes,
                                                     ItemDescription = PoSummary.ItemDescription,
                                                     Vendor = PoSummary.Vendorname,
                                                     UOM = PoSummary.UOM,
                                                     QuantityOrdered = PoSummary.Ordered,
                                                     ActualGood = receive != null && receive.IsActive != false ? receive.ActuallDelivered : 0,
                                                     IsActive = PoSummary.IsActive,
                                                     ActualRemaining = 0,
                                                     IsWarehouseIsActive = receive != null ? receive.IsActive : true

                                                 }).GroupBy(x => new
                                                 {
                                                     x.Id,
                                                     x.PoNumber,
                                                     x.ItemCode,
                                                     x.ItemDescription,
                                                     x.UOM,
                                                     x.QuantityOrdered,
                                                     x.IsActive,
                                                     x.IsWarehouseIsActive

                                                 }).Select(recieve => new DtoPoSummaryCheckList
                                                 {
                                                     Id = recieve.Key.Id,
                                                     PoNumber = recieve.Key.PoNumber,
                                                     ItemCode = recieve.Key.ItemCode,
                                                     ItemDescription = recieve.Key.ItemDescription,
                                                     UOM = recieve.Key.UOM,
                                                     QuantityOrdered = recieve.Key.QuantityOrdered,
                                                     ActualGood = recieve.Sum(x => x.ActualGood),
                                                     ActualRemaining = ((recieve.Key.QuantityOrdered + (recieve.Key.QuantityOrdered / 100) * 10) - (recieve.Sum(x => x.ActualGood))),
                                                     IsActive = recieve.Key.IsActive,
                                                     IsWarehouseIsActive = recieve.Key.IsWarehouseIsActive

                                                 }).Where(x => x.IsWarehouseIsActive == true)
                                                   .FirstOrDefaultAsync(x => x.Id == receiving.Po_SummaryID);

            if (validateActualRemaining == null)
                return true;
            else if (validateActualRemaining.ActualRemaining < receiving.ActuallDelivered)
                return false;
            return true;
                                      
        }

        public async Task<PagedList<DtoCancelled>> GetAllCancelledPoWithPagination(UserParameter userParams)
        {
            var cancelpo = (from PoSummary in _context.PoSummaries
                            join receive in _context.WarehouseRecieve on PoSummary.Id equals receive.Po_SummaryID into leftJ
                            from receive in leftJ.DefaultIfEmpty()

                            select new DtoCancelled
                            {
                                Id = PoSummary.Id,
                                PoNumber = PoSummary.PoNumber,
                                ItemCode = PoSummary.ItemCodes,
                                ItemDescription = PoSummary.ItemDescription,
                                Vendor = PoSummary.Vendorname,
                                QuantityOrdered = PoSummary.Ordered,
                                QuatityCancel = receive != null ? receive.ActuallDelivered : 0,
                                QuantityGood = receive != null ? receive.ActuallDelivered : 0,
                                DateCancelled = PoSummary.ImportCancelled.ToString(),
                                IsActive = PoSummary.IsActive,
                                Remarks = PoSummary.Reasons


                            }).Where(x => x.IsActive == false)
                              .Where(x => x.DateCancelled != null)
                              .Where(x => x.Remarks != null);

            return await PagedList<DtoCancelled>.CreateAsync(cancelpo, userParams.PageNumber, userParams.PageSize);             
        }

        public async Task<PagedList<DtoCancelled>> GetAllCancelledPoWithPaginationOrig(UserParameter userParams , string search)
        {
            var cancelpo = (from PoSummary in _context.PoSummaries
                            join receive in _context.WarehouseRecieve on PoSummary.Id equals receive.Po_SummaryID into leftJ
                            from receive in leftJ.DefaultIfEmpty()

                            join item in _context.PoSummaries on PoSummary.ItemCodes equals item.ItemCodes

                            select new DtoCancelled
                            {
                                Id = PoSummary.Id,
                                PoNumber = PoSummary.PoNumber,
                                ItemCode = PoSummary.ItemCodes,
                                ItemDescription = PoSummary.ItemDescription,
                                Vendor = PoSummary.Vendorname,
                                QuantityOrdered = PoSummary.Ordered,
                                QuatityCancel = receive != null ? receive.ActuallDelivered : 0,
                                QuantityGood = receive != null ? receive.ActuallDelivered : 0,
                                DateCancelled = PoSummary.ImportCancelled.ToString(),
                                IsActive = PoSummary.IsActive,
                                Remarks = PoSummary.Reasons

                            }).Where(x => x.IsActive == false)
                              .Where(x => x.DateCancelled != null)
                              .Where(x => Convert.ToString(x.PoNumber).ToLower()
                              .Contains(search.Trim().ToLower()));

            return await PagedList<DtoCancelled>.CreateAsync(cancelpo, userParams.PageNumber, userParams.PageSize);
        }



        //validation

        public async Task<bool> ValidatePoId(int id)
        {
            var validate = await _context.PoSummaries.Where(x => x.Id == id)
                                                      .Where(x => x.IsActive == true)
                                                      .FirstOrDefaultAsync();
            if (validate == null)
            {
                return false;
            }
            return true;

        }
    }
}
