
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using FIGFiance.BookStore.Test.Utility;
using FIGFinance.RepositoryBase;
using FIGFiance.Entities;
using FIGFinance.GoogleRepositoryImpl;
using FIGFinance.BusinessLogic;

namespace ConsoleApplication.Test
{
    class Program
    {
        /// <summary>
        /// Simple testing on apis
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IEntityBaseRepository<Book> booksRepository = new GooglBookApi<Book>();
            IQueryable<Book> books = booksRepository.GetAll("Steve");
            foreach (var book in books)
            {
                string s = book.VolumeInfor.Title;
                string smalllink = book.VolumeInfor.ImagelLinks.SmallThumbnail;
                string thumnaillink = book.VolumeInfor.ImagelLinks.Thumbnail;
            }

            Book bookDetail = booksRepository.GetDetail("8U2oAAAAQBAJ");

            var costData = new ShipCostGenerator().GetAll();
        }
    }
}
