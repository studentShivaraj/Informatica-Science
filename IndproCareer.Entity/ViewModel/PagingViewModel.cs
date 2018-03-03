using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Entity.ViewModel
{
    public class PagingViewModel
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string SortParameter { get; set; }
        public string SortDirection { get; set; }
        public string SearchValue { get; set; }
    }
}
