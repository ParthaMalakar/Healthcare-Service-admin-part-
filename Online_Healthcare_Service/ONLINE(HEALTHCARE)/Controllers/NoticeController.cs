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
    public class NoticeController : ApiController
    {
        [Route("api/Notice/get/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = NoticeService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Notice/get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            //id = id + ".com";
            var data = NoticeService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Notice/create")]
        [HttpPost]
        public HttpResponseMessage Create(NoticeDTO s)
        {
            if (NoticeService.Create(s))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data inserted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

        [Route("api/Notice/update")]
        [HttpPost]
        public HttpResponseMessage Update(NoticeDTO s)
        {
            if (NoticeService.Update(s))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data updated");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

        [Route("api/Notice/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            //id = id + ".com";
            if (NoticeService.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }
    }
}
