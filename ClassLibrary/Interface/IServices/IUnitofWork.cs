using ClassLibrary.Interface.Import_Interface;
using ClassLibrary.Interface.Inter_Core;
using ClassLibrary.Interface.Masterlist_Interface;
using ClassLibrary.model.PoSummary;
using ClassLibrary.Repository.Masterlist_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface.IServices
{
    public interface IUnitofWork
    {

        ItemCodesInterface itemCodes { get; }
        UomInterface oums { get; }
        VendorInterface vendor { get; }

        PoSummaryInterface poSummary { get; }
       
        Task CompleteAsync();

    }
}
