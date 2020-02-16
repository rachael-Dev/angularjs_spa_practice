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
using FIGFinance.BusinessLogic;

namespace FIGFiance.BookStore.Test.Controllers
{
    /// <summary>
    /// simple api to retrieve delivery information
    /// </summary>
    [RoutePrefix("api/Buy")]
    public class BuyController : ApiController
    {
        DeliveryInfoGenerator _DeliveryInfoGenerator;

        [AllowAnonymous]
        [Route("delivery")]
        [HttpPost]
        public HttpResponseMessage BuyBookModel(HttpRequestMessage request, [FromBody] BuyBookModel model)
        {            
            if (model == null || string.IsNullOrWhiteSpace(model.DeliveryService))
                return request.CreateResponse<string>(HttpStatusCode.BadRequest, "Please choose one ship option");

            HttpResponseMessage response = null;
            _DeliveryInfoGenerator = new DeliveryInfoGenerator();
            var info = _DeliveryInfoGenerator.GenerateDeliveryInfor(model);
            response = request.CreateResponse<string>(HttpStatusCode.OK, info);
            return response; 



        }
    }
}
