using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Helper
{
    public class UserParameter
    {
        private const int MaxPageSize = 2000;
        public int PageNumber { get; set; } = 1;
        public int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize)? MaxPageSize : value;
        }

     
       



    }
}
