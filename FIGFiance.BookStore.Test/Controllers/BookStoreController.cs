
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using FIGFiance.BookStore.Test.Utility;
using FIGFinance.RepositoryBase;
using FIGFiance.Entities;


namespace FIGFiance.BookStore.Test.Controllers
{
    /// <summary>
    /// Bookstore API
    /// </summary>
    /// 
    [RoutePrefix("api/BookStore")]
    public class BookStoreController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Book> _bookRepository;

        public BookStoreController(IEntityBaseRepository<Book> booksRepository)
            : base()
        {
            _bookRepository = booksRepository;
        }

        /// <summary>
        /// Get the selected book by id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [Route("details/{id}")]
        public HttpResponseMessage Get(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var book = _bookRepository.GetDetail(id);                
                response = request.CreateResponse<Book>(HttpStatusCode.OK, book);
                return response;
            });
        }

        /// <summary>
        /// get books with paging
        /// </summary>
        /// 
        /// <param name="request"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Route("{page:int=0}/{pageSize=6}/{filter?}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<Book> books = null;
                int totalBooks = new int();
                if (!string.IsNullOrEmpty(filter))
                {                    
                    books = _bookRepository
                        .GetAll(filter)
                        .OrderBy(m => m.VolumeInfor.PublishDate)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalBooks = _bookRepository.GetAll(filter).Count();
                }
                else
                {
                    response = request.CreateResponse<PaginationSet<Book>>(HttpStatusCode.BadRequest, null);
                }
                
                //PaginationSet<MovieViewModel> pagedSet = new PaginationSet<MovieViewModel>()
                PaginationSet<Book> pagedSet = new PaginationSet<Book>()
                {
                    Page = currentPage,
                    TotalCount = totalBooks,
                    TotalPages = (int)Math.Ceiling((decimal)totalBooks / currentPageSize),
                    Items = books
                };

                response = request.CreateResponse<PaginationSet<Book>>(HttpStatusCode.OK, pagedSet);

                return response;
            });

        }
    }
}
