using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;
using ClassLibrary.Interface.Masterlist_Interface;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Cryptography.X509Certificates;

namespace ClassLibrary.Repository.Masterlist_Repository
{
    public class UomRepository : UomInterface
    {
        private readonly StoreContext _context;

        public UomRepository(StoreContext context)
        {
            _context = context; 
        }

        public async Task<IReadOnlyList<DtoUom>> GetAllActiveUom()
        {
            var uom = _context.Uoms.Where(x => x.IsActive == true)
                                   .Select(x => new DtoUom
                                   {
                                       Id = x.Id,
                                       UomCode= x.UomCode,
                                       UomDescription= x.UomDescription,
                                       Addedby  = x.Addedby,
                                       Dateadded= x.Dateadded,
                                       
                                   });

            return await uom.ToListAsync();
        }

        public  async Task<IReadOnlyList<DtoUom>> GetAllInActiveUom()            
        {
            var uom = _context.Uoms.Where(x => x.IsActive == false)
                                .Select(x => new DtoUom
                                {
                                    Id = x.Id,
                                    UomCode = x.UomCode,
                                    UomDescription = x.UomDescription,
                                    Addedby = x.Addedby,
                                    Dateadded = x.Dateadded,

                                });

            return await uom.ToListAsync();
        }
    }
}
