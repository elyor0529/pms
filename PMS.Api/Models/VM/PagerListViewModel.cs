using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Api.Models
{
    public class PagerListViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }

        public IPagedList Pager { get; set; }
    }
}