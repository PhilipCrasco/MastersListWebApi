using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;
using ClassLibrary.Data_Acess_Layer.model.Masterlist;
using ClassLibrary.Interface.Masterlist_Interface;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data_Acess_Layer.Repository.Masterlist_Repository
{
    public class ItemCategoryRepository : ItemCategoryInterface
    {

        private readonly StoreContext _context;

        public ItemCategoryRepository(StoreContext context)
        {
            _context = context;
        }
    
        public async  Task<bool> AddnewItemCategory(ItemCategory itemCategory)
        {
            var ItemCategory = await _context.ItemCategories.AddAsync(itemCategory);
            return true;

        }

        public async Task<IReadOnlyList<DtoItemCategory>> GetAllActiveItemCategory()
        {
            var itemCateg = _context.ItemCategories.Where(x => x.IsActive == true)
                                                         .Select(x => new DtoItemCategory
                                                         {

                                                             Id = x.Id,
                                                             ItemCategoryName = x.ItemCategoryName,
                                                             DatetAdded = x.DatetAdded.ToString("MM/dd/yyyy"),
                                                             AddedBy = x.AddedBy,
                                                             IsActive = x.IsActive


                                                         }) ; 
            

            return await itemCateg.ToListAsync();   

        }

        public async Task<IReadOnlyList<DtoItemCategory>> GetAllInActiveItemCategory()
        {
            var itemCateg = _context.ItemCategories.Where(x => x.IsActive == false)
                                                         .Select(x => new DtoItemCategory
                                                         {

                                                             Id = x.Id,
                                                             ItemCategoryName = x.ItemCategoryName,
                                                             DatetAdded = x.DatetAdded.ToString("MM/dd/yyyy"),
                                                             AddedBy = x.AddedBy,
                                                             IsActive = x.IsActive


                                                         });
            

            return await itemCateg.ToListAsync();

        }
        public async Task<bool> UpdateItemCategory(ItemCategory itemCategory)
        {
            var itemcateg = await _context.ItemCategories.Where(x => x.Id == itemCategory.Id)
                                                           .FirstOrDefaultAsync();
            if (itemcateg != null)
            {

                itemcateg.ItemCategoryName = itemCategory.ItemCategoryName;
                itemcateg.AddedBy = itemCategory.AddedBy;
                itemcateg.DatetAdded = itemcateg.DatetAdded;
                return true;
            }
            return false;

        }
        public async Task<bool> UpdateActiveItemCategory(ItemCategory itemCategory)
        {
            var itemcateg = await _context.ItemCategories.Where(x => x.Id == itemCategory.Id)
                                                         .FirstOrDefaultAsync();
            if (itemcateg != null)
            {


                itemcateg.IsActive = itemCategory.IsActive = true;
                return true;

            }
            return false;
        }

        public async Task<bool> UpdateInActiveItemCategory(ItemCategory itemCategory)
        {
            var itemcateg = await _context.ItemCategories.Where(x => x.Id == itemCategory.Id)
                                                          .FirstOrDefaultAsync();
            if (itemcateg != null)
            {


                itemcateg.IsActive = itemCategory.IsActive = false;
                return true;
            }
            return false;
        }

      

        // validation

        public async Task<bool> ValidatedCategoryName(string CategoryName)
        {
            return await _context.ItemCategories.AnyAsync(x=> x.ItemCategoryName== CategoryName);
        }
    }
}
