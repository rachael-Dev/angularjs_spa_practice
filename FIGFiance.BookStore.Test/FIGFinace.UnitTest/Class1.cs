
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net; 
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using FIGFiance.BookStore.Test.Utility;
using FIGFinance.RepositoryBase;
using FIGFiance.Entities;
using FIGFinance.GoogleRepositoryImpl;
using FIGFinance.BusinessLogic;

using NUnit.Framework;

namespace FIGFinace.UnitTest
{
    [TestFixture]
    public class Class1
    {
         [TestCase]
        public void GetAllBooks()
        {
            IEntityBaseRepository<Book> booksRepository = new GooglBookApi<Book>();
            IQueryable<Book> books = booksRepository.GetAll("Steve");
            foreach (var book in books)
             {
                 string s = book.VolumeInfor.Title;
             }
            Assert.NotNull(books);
        }

         [Test]
         public void GetBooks()
         {
             IEntityBaseRepository<Book> booksRepository = new GooglBookApi<Book>();
             IQueryable<Book> books = booksRepository.GetAll("Steve");
             foreach (var book in books)
             {
                 string s = book.VolumeInfor.Title;
             }
             Assert.NotNull(books);
         }

        [Test]
         public void GetBooksById(string id)
         {
             IEntityBaseRepository<Book> booksRepository = new GooglBookApi<Book>();
             Book books = booksRepository.GetDetail("8U2oAAAAQBAJ");             
             Assert.NotNull(books);
         }

        [Test]
        public void GetShipCosts()
        {
            var costs = new ShipCostGenerator().GetAll();
            Assert.NotNull(costs);
            Assert.AreEqual(3, costs.Count);
        }
    }
}
