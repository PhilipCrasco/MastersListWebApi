using ClassLibrary.Interface.Import_Interface;
using ClassLibrary.Interface.Inter_Core;
using ClassLibrary.Interface.IServices;
using ClassLibrary.Interface.Masterlist_Interface;
using ClassLibrary.model.Masterlist;
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

            itemCodes = new ItemCodesRepository(_context);
            oums = new UomRepository(_context);
            vendor = new VendorRespository(_context);
            poSummary = new PoSummaryRepository(_context);
        }

        public ItemCodesInterface itemCodes { get; set;  }

        public UomInterface oums { get; private set; }

        public VendorInterface vendor { get; set; }

        public PoSummaryInterface poSummary { get; set; }

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
