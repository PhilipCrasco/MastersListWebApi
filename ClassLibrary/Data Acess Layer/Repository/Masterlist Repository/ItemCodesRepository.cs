using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;
using ClassLibrary.Interface.Inter_Core;
using ClassLibrary.model.Masterlist;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repository.Masterlist_Repository
{
    public class ItemCodesRepository : ItemCodesInterface
    {

        private  readonly StoreContext _context;

        public ItemCodesRepository(StoreContext context)
        {
            _context = context;
        }

     
        public async Task<IReadOnlyList<DtoItemcodes>> GetAllActiveItem()
        {
            var itemscode = _context.ItemCodes.Where(x => x.IsActive == true)
                                                     .Select(x => new DtoItemcodes
                                                     {
                                                         Id = x.Id,
                                                         ItemCodes = x.ItemCodes,
                                                         ItemDescription = x.ItemDescription,
                                                         ItemCategoryId = x.ItemCategoryId,
                                                         ItemCategoryDecription = x.ItemCategory.ItemCategoryName,
                                                         Uom = x.Uom.UomCode,
                                                         UomId = x.UomId,
                                                         Dateadded = x.Dateadded.ToString("MM/dd/yyyy"),
                                                         Addedby = x.Addedby,
                                                         IsActive = x.IsActive



                                                     }) ;
            return await itemscode.ToListAsync();
        }

        public async Task<IReadOnlyList<DtoItemcodes>> GetAllInActiveItem()
        {
            var itemscode = _context.ItemCodes.Where(x => x.IsActive == false)
                                                    .Select(x => new DtoItemcodes
                                                    {
                                                        Id = x.Id,
                                                        ItemCodes = x.ItemCodes,
                                                        ItemDescription = x.ItemDescription,
                                                        ItemCategoryId = x.ItemCategoryId,
                                                        ItemCategoryDecription = x.ItemCategory.ItemCategoryName,
                                                        Uom = x.Uom.UomCode,
                                                        UomId = x.UomId,
                                                        Dateadded = x.Dateadded.ToString("MM/dd/yyyy"),
                                                        Addedby = x.Addedby,
                                                        IsActive = x.IsActive


                                                    });

            return await itemscode.ToListAsync();



        }

        public async Task<bool> AddItem(ItemCode itemcode)
        {
            await _context.AddAsync(itemcode);
            return true;
        }

        public async Task<bool> UpdateItemCode(ItemCode itemcode)
        {
            var updateitem = await _context.ItemCodes.Where(x => x.Id == itemcode.Id)
                                                               .FirstOrDefaultAsync();
            if (updateitem == null)
            {
            
                return false;   
            }


            updateitem.ItemCodes = itemcode.ItemCodes;
               updateitem.ItemDescription = itemcode.ItemDescription;
               updateitem.UomId = itemcode.UomId;
               updateitem.Addedby = itemcode.Addedby;
               updateitem.Dateadded = itemcode.Dateadded;

            return true;
        }

        public async Task<bool> UpdateActiveItem(ItemCode itemcode)
        {
            var updateitem = await _context.ItemCodes.Where(x => x.Id == itemcode.Id)
                                                             .FirstOrDefaultAsync();

            if(updateitem == null)
            {
                return false;
            }

            updateitem.IsActive = updateitem.IsActive = true;
            return true;
        }

        public async Task<bool> UpdateInActive(ItemCode itemcode)
        {
            var updateitem = await _context.ItemCodes.Where(x => x.Id == itemcode.Id)
                                                             .FirstOrDefaultAsync();

            if (updateitem == null)
            {
                return false;
            }

            updateitem.IsActive = updateitem.IsActive = false;
            return true;
        }


        //Validation 


        public async Task<bool> ValidateUomId(int id)
        {
            var validationUomId = await _context.Uoms.FindAsync(id);
            
            if(validationUomId== null)
            {
                return false;
            }
            return true;

            
        }
    
        public async Task<bool> ValidateCodeExist(string itemcode)
        {
            return await _context.ItemCodes.AnyAsync(x => x.ItemCodes == itemcode);
        }

        public async Task<bool> ValidateItemCategoryId(int Id)
        {
            var validatecitemcateg = await _context.ItemCategories.FindAsync(Id);
            if(validatecitemcateg == null)
            {
                return false;
            }
            return true;
        }


    }
}
