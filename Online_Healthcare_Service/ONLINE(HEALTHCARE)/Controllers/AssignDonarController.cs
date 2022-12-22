using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ONLINE_HEALTHCARE_.Controllers
{
    public class AssignDonarController : ApiController
    {

        [HttpGet]
        [Route("api/AvailableDONAR")]
        public HttpResponseMessage AvailableGet()
        {
            try
            {
                var data = AssignDonarService.AvailableGet().Take(10);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [HttpGet]
        [Route("api/CollectedDonar")]
        public HttpResponseMessage BussyGet()
        {
            try
            {
                var data = AssignDonarService.CollectedbonarGet().Take(10);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [Route("api/donar/Assign/{pid}/{id}")]
        [HttpPost]
        public HttpResponseMessage Assign(int id,int pid)
        {
            if (AssignDonarService.Assign(id,pid))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Assign Done");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }
        [HttpGet]
        [Route("api/AvailableBLOODrequest")]
        public HttpResponseMessage AvailabeBloodRequest()
        {
            try
            {
                var data = BloodBankService.AvailableGet().Take(10);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}
