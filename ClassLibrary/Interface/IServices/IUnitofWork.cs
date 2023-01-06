using ClassLibrary.Interface.Inter_Core;
using ClassLibrary.Interface.Masterlist_Interface;
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
       
        Task CompleteAsync();

    }
}
