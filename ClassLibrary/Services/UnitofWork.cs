using ClassLibrary.Data_Acess_Layer.Repository;
using ClassLibrary.Data_Acess_Layer.Repository.Masterlist_Repository;
using ClassLibrary.Data_Acess_Layer.Repository.Receiving_Repository;
using ClassLibrary.Data_Acess_Layer.Repository.UserModelRepository;
using ClassLibrary.Interface.Import_Interface;
using ClassLibrary.Interface.Inter_Core;
using ClassLibrary.Interface.IServices;
using ClassLibrary.Interface.Masterlist_Interface;
using ClassLibrary.Interface.User_Model_Interface;
using ClassLibrary.Interface.WareHouse_Interface;
using ClassLibrary.Persistence;
using ClassLibrary.Repository.Import_Repository;
using ClassLibrary.Repository.Masterlist_Repository;

namespace ClassLibrary.Services
{
    public class UnitofWork : IUnitofWork, IDisposable
    {
        private readonly StoreContext _context;



        public UnitofWork(StoreContext context)
        {
            _context = context;

            user = new UsersRepsittory(_context); 
            roles = new RoleRepository(_context);
            department = new DepartmentRepository(_context);
            mainmenu = new MainmenuRepository(_context);


            itemCodes = new ItemCodesRepository(_context);
            oums = new UomRepository(_context);
            vendor = new VendorRespository(_context);
            poSummary = new PoSummaryRepository(_context);
            customer = new CustomerRepository(_context);
            ItemCategory = new ItemCategoryRepository(_context);


            wareHouseReceiving = new WarehouseReceivingRepository(_context);



            

        }

        public ItemCodesInterface itemCodes { get; set;  }

        public UomInterface oums { get; private set; }

        public VendorInterface vendor { get; set; }

        public PoSummaryInterface poSummary { get; set; }

        public CustomerInterface customer { get; set; }

        public ItemCategoryInterface ItemCategory { get; set; }


        public IUser user { get; private set; }
        public IRole roles { get; private set; }
        public IDepartment department { get; private set; }
        public IMainmenu mainmenu { get; private set; }


        public IWareHouseReceiving wareHouseReceiving { get; set; }

        

        public async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
