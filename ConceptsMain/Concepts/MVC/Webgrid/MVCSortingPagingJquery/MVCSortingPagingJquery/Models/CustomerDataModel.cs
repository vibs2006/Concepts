using System.Collections.Generic;

namespace MVCSortingPagingJquery.Models
{
    public class CustomerDataModel
    {
        public List<CustomerInfo> Customer { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
        public int NoOfPages { get; set; }
    }
}