using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;
using ClassLibrary.Interface.Masterlist_Interface;
using ClassLibrary.model.Masterlist;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

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
                                       IsActive = x.IsActive
                                       
                                       
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
                                    IsActive = x.IsActive

                                });

            return await uom.ToListAsync();

        }
        public  async Task<bool> AddUom(Uom uom)
        {
            var adduom = await _context.AddAsync(uom);
            return true;
        }

        public async Task<bool> UpdateUom(Uom uom)
        {
            var updateUom = await _context.Uoms.Where(x =>x.Id == uom.Id)
                                   .FirstOrDefaultAsync();

            if (updateUom == null)
            {
                return false;
            }
             updateUom.UomCode = uom.UomCode;
            updateUom.UomDescription = uom.UomDescription;
            updateUom.Dateadded = uom.Dateadded;    
            updateUom.Addedby = uom.Addedby;


            return true;
        }

        public async  Task<bool> UpdateActiveUom(Uom uom)
        {
            var updateUom = await _context.Uoms.Where(x => x.Id == uom.Id)
                                 .FirstOrDefaultAsync();

            if (updateUom == null)
            {
                return false;
            }
            updateUom.IsActive = uom.IsActive = true;


            return true;
        }

        public async  Task<bool> UpdateInActiveUom(Uom uom)
        {
            var updateUom = await _context.Uoms.Where(x => x.Id == uom.Id)
                     .FirstOrDefaultAsync();

            if (updateUom == null)
            {
                return false;
            }
            updateUom.IsActive = uom.IsActive = false;


            return true;
        }




        // Validation


        public async Task<bool> ItemCodeExist(string itemcode)
        {
            return await _context.Uoms.AnyAsync(x=> x.UomCode== itemcode);
        }

        public async  Task<bool> ValidateUomDescription(string uomdiscription)
        {
            return await _context.Uoms.AnyAsync(x => x.UomDescription == uomdiscription);
        }


    }
}
