using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FIGFiance.Entities;
using FIGFinance.RepositoryBase;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

//AIzaSyDG9CUnfKHoTP3w4hIkQAR08OUFJ_SLOBs 

//key=API_KEY
//https://developers.google.com/books/docs/v1/using
//https://developers.google.com/api-client-library/dotnet/apis/books/v1
//https://github.com/googlearchive/google-api-dotnet-client-samples/blob/master/Books.ListMyLibrary/Program.cs
//https://www.c-sharpcorner.com/code/3301/google-books-search-with-c-sharp.aspx
//https://developers.google.com/books/docs/v1/getting_started
//https://developers.google.com/api-client-library/dotnet/apis/books/v1
//https://developers.google.com/books/docs/v1/reference/?apix=true
//https://www.googleapis.com/books/v1/volumes?q=steve


namespace FIGFinance.GoogleRepositoryImpl
{
    /// <summary>
    /// Google api
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GooglBookApi<T> : IEntityBaseRepository<T>
           where T : class, IEntityBase, new()
    {
        private readonly BooksService _booksService;

        private string _apiKey = "AIzaSyDG9CUnfKHoTP3w4hIkQAR08OUFJ_SLOBs";
        public GooglBookApi()
        {
            _booksService = new BooksService(new BaseClientService.Initializer()
            {
                ApiKey = _apiKey,
                ApplicationName = "API key 1"
            });
        }
       
        public IQueryable<T> GetAll(string query)
        {
            //https://www.googleapis.com/books/v1/volumes?q=steve

            var listquery = _booksService.Volumes.List(query);
            //listquery.MaxResults = count;
            //listquery.StartIndex = offset;
            var res = listquery.Execute();
            var books = res.Items.Select(b => new Book
            {
                ID = b.Id,
                ETag = b.ETag,
                Kind = b.Kind,
                VolumeInfor = new VolumeInformation
                {
                    Title = b.VolumeInfo.Title,
                    Subtitle = b.VolumeInfo.Subtitle,
                    Authors = b.VolumeInfo.Authors.ToList(),
                    Publisher = b.VolumeInfo.Publisher,
                    PublishDate = b.VolumeInfo.PublishedDate,
                    Description = b.VolumeInfo.Description,
                    ImagelLinks = new ImageLink { SmallThumbnail = b.VolumeInfo.ImageLinks.SmallThumbnail, Thumbnail = b.VolumeInfo.ImageLinks.Thumbnail },
                },
                //PageCount = b.VolumeInfo.PageCount,
            }).AsQueryable().Cast<T>();;
            return books;
        }
        public T GetDetail(string id)
        {
            var volumeQuery = _booksService.Volumes.Get(id);
            var res = volumeQuery.Execute();
            var book = new Book
            {
                ID = res.Id,
                ETag = res.ETag,
                Kind = res.Kind,
                VolumeInfor = new VolumeInformation
                {
                    Title = res.VolumeInfo.Title,
                    Subtitle = res.VolumeInfo.Subtitle,
                    Authors = res.VolumeInfo.Authors.ToList(),
                    Publisher = res.VolumeInfo.Publisher,
                    PublishDate = res.VolumeInfo.PublishedDate,
                    Description = res.VolumeInfo.Description,
                    ImagelLinks = new ImageLink { SmallThumbnail = res.VolumeInfo.ImageLinks.SmallThumbnail, Thumbnail = res.VolumeInfo.ImageLinks.Thumbnail },
                },
            };
            return (T)Convert.ChangeType(book, typeof(T));
        }
       
    }
}
