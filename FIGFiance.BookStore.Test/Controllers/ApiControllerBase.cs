using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FIGFinance.Logger;
using FIGFinance.RepositoryBase;
using FIGFiance.Entities;

namespace FIGFiance.BookStore.Test.Controllers
{
    /// <summary>
    /// HttpResponse with error handling
    /// </summary>
    public class ApiControllerBase : ApiController
    {
        public ApiControllerBase()
        {

        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;

            try
            {
                response = function.Invoke();
            }
            catch (DbUpdateException ex)
            {
                LoggerHelper.Log(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(ex);
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }    
    }
}