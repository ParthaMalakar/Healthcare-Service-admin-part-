using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ONLINE_HEALTHCARE_.Controllers
{
    public class DonateMoneyController : ApiController
    {
        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("api/DonateMoney")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = DonateMoneyService.Get().Take(10);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("api/Transaction/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = DonateMoneyService.Get(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [EnableCors("*", "*", "*")]
        [Route("api/Transaction/add")]
        [HttpPost]
        public HttpResponseMessage Add(DonateMoneyDTO obj)
        {
            var data = DonateMoneyService.Add(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [EnableCors("*", "*", "*")]
        [Route("api/Transaction/update")]
        [HttpPost]
        public HttpResponseMessage Update(DonateMoneyDTO Transaction)
        {

            try
            {
                var isUpdated = DonateMoneyService.Update(Transaction);
                return Request.CreateResponse(HttpStatusCode.OK, isUpdated);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [EnableCors("*", "*", "*")]
        [Route("api/Transaction/Delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteTransaction(int id)
        {
            var isDeleted = DonateMoneyService.Delete(id);

            return isDeleted ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Transaction Deleted successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Transaction Delete unsuccessfull"
                    }
                );
        }
    }
}
