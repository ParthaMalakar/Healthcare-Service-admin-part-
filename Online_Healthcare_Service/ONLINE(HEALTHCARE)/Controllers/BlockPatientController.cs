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
    [EnableCors("*", "*", "*")]
    public class BlockPatientController : ApiController
    {
        [HttpGet]
        [Route("api/ActivePatients")]
        public HttpResponseMessage ActiveGet()
        {
            try
            {
                var data = BlockPatientService.ActiveGet().Take(10);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [HttpGet]
        [Route("api/BlockPatients")]
        public HttpResponseMessage BlockGet()
        {
            try
            {
                var data = BlockPatientService.BlockGet().Take(10);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [Route("api/Patient/Block/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(int id)
        {
            if (BlockPatientService.Block(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Block Successfully done");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }
    }
}
