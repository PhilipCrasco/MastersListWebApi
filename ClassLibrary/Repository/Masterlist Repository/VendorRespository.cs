using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;
using ClassLibrary.Interface.Masterlist_Interface;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repository.Masterlist_Repository
{
    public class VendorRespository : VendorInterface
    {
        private readonly StoreContext _context;

        public VendorRespository(StoreContext context)
        {
            _context = context;

        }

        public async Task<IReadOnlyList<DtoVendor>> GetAllActiveVendor()
        {
            var Vendor = _context.VendorNames.Where(x => x.IsActive == true)
                                             .Select(x => new DtoVendor
                                             {
                                                 Id = x.Id,
                                                 VendorCode= x.VendorCode,
                                                 VendorcodeName = x.VendorcodeName,
                                                 Addedby = x.Addedby,
                                                 DateAdded= x.DateAdded,


                                             });
            return await Vendor.ToListAsync();
        }

        public async Task<IReadOnlyList<DtoVendor>> GetAllInActiveVendor()
        {

            var Vendor = _context.VendorNames.Where(x => x.IsActive == false)
                                             .Select(x => new DtoVendor
                                             {
                                                 Id = x.Id,
                                                 VendorCode = x.VendorCode,
                                                 VendorcodeName = x.VendorcodeName,
                                                 Addedby = x.Addedby,
                                                 DateAdded = x.DateAdded,

                                             });
            return await Vendor.ToListAsync();
        }
    }
}
