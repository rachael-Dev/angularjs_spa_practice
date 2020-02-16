using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIGFiance.BookStore.Test.Utility
{
    /// <summary>
    /// paging
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginationSet<T>
    {
        public int Page { get; set; }

        public int Count
        {
            get
            {
                return (null != this.Items) ? this.Items.Count() : 0;
            }
        }

        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}