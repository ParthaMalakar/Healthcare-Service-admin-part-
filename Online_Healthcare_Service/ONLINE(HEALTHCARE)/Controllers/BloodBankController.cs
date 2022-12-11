using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Http;

namespace ONLINE_HEALTHCARE_.Controllers
{
    public class BloodBankController : ApiController
    {

        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("api/bloodbanks")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = BloodBankService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("api/bloodbank/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = BloodBankService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/bloodbank/add")]
        [HttpPost]
        public HttpResponseMessage Add(BloodBankDTO obj)
        {
            var data = BloodBankService.Add(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [EnableCors("*", "*", "*")]
        [Route("api/bloodbank/update")]
        [HttpPost]
        public HttpResponseMessage Update(BloodBankDTO blood)
        {

            try
            {
                var isUpdated = BloodBankService.Update(blood);
                return Request.CreateResponse(HttpStatusCode.OK, isUpdated);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [EnableCors("*", "*", "*")]
        [Route("api/bloodbank/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var isDeleted = BloodBankService.Delete(id);

            return isDeleted ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = " Deleted successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = " Delete unsuccessful"
                    }
                );
        }

    }
}