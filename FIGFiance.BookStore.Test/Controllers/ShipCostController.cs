
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
    /// simple api to retreive shipping cost data
    /// </summary>
    [RoutePrefix("api/ShipCosts")]
    public class ShipCostController : ApiController
    {     

        [AllowAnonymous]
        [Route("all")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {            
                HttpResponseMessage response = null;                
                var costs = new ShipCostGenerator().GetAll();
                response = request.CreateResponse<List<DeliveryServiceBase>>(HttpStatusCode.OK, costs);
                return response; 

        }

        
    }
}
