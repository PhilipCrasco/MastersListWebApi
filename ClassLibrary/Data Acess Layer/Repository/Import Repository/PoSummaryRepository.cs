using ClassLibrary.Interface.Import_Interface;
using ClassLibrary.model.PoSummary;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ClassLibrary.Repository.Import_Repository
{
    public class PoSummaryRepository : PoSummaryInterface
    {
        private readonly StoreContext _context;
        
        public PoSummaryRepository(StoreContext context)
        {
            _context = context;          
        }

        public async Task<bool> AddPoSummaryRequest(PoSummary posummary)
        {
            posummary.PrDate = Convert.ToDateTime(posummary.PrDate);
            posummary.PoDate = Convert.ToDateTime(posummary.PoDate);

            var existingInfo = await _context.ItemCodes.Where(x => x.ItemCodes == posummary.ItemCodes)
                                                                 .FirstOrDefaultAsync();
            if (existingInfo == null)
            {
                return false;
            }

            posummary.ItemDescription = existingInfo.ItemDescription;
            await _context.PoSummaries.AddAsync(posummary);
            return true;
        }



        // Validation

        public async Task<bool> CheckItemCode(string itemcode)
        {
           var validateItem = await _context.ItemCodes.Where(x=> x.ItemCodes == itemcode)
                                                       .Where(x=> x.IsActive ==true)
                                                       .FirstOrDefaultAsync();

            if(validateItem == null)
                return false;

            return true;    

        }

        public async Task<bool> CheckUom(string uom)
        {
            var validateuom = await _context.Uoms.Where(x=> x.UomCode== uom)
                                                  .Where(x=> x.IsActive ==true)
                                                  .FirstOrDefaultAsync();

            if(validateuom == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Checkvendor(string vendor)
        {
            var validateVendor = await _context.VendorNames.Where(x => x.VendorcodeName == vendor)
                                                           .Where(x => x.IsActive == true)
                                                           .FirstOrDefaultAsync();

            if(validateVendor == null)
            {
                return false;
            }
              
            return true;
        }



        public async Task<bool> ValidatePoandItemcodeManual(int ponumber, string itemcode)
        {
            var validate = await _context.PoSummaries.Where(x=> x.PoNumber == ponumber)
                                                     .Where(x=> x.ItemCodes == itemcode)
                                                     .FirstOrDefaultAsync();

            if (validate == null) return false;

            

            if (validate==null)
            {
                return false;
            }
            return true;

        }
        

    }
}
