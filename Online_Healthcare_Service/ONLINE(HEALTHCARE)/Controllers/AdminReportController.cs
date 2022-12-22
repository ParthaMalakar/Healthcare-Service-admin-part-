using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ONLINE_HEALTHCARE_.Controllers
{
    public class AdminReportController : ApiController
    {
        [EnableCors("*", "*", "*")]
        [Route("api/Report/get/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = AdminReportService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [EnableCors("*", "*", "*")]
        [Route("api/AdminReport/Recived/{id}")]
        [HttpPost]
        public HttpResponseMessage recivedByEmails(string id)
        {
            id = id + ".com";
            var data = AdminReportService.recivedByEmails(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Report/send/{id}")]
        [HttpGet]
        public HttpResponseMessage sendByEmails(string id)
        {
            id = id + ".com";
            var data = AdminReportService.sendByEmails(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Report/create")]
        [HttpPost]
        public HttpResponseMessage Create(AdminReportDTO s)
        {
            if (AdminReportService.Create(s))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data inserted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

        [Route("api/Report/update")]
        [HttpPost]
        public HttpResponseMessage Update(AdminReportDTO s)
        {
            if (AdminReportService.Update(s))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data updated");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

        [Route("api/Report/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {

            if (AdminReportService.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

        [Route("api/report/Admin/create")]
        [HttpPost]
        public HttpResponseMessage InvestorReportCreate(AdminReportDTO s)
        {
          /*  var auth = HttpContext.Current.Request.Headers["Authorization"];
            s.sender = UserNameService.Get(auth);*/
            if (AdminReportService.InCreate(s))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data inserted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

        [Route("api/Report/id/inc")]
        [HttpGet]
        public HttpResponseMessage repotByIdInc()
        {
            var data = AdminReportService.sortByIdInc();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Report/id/dec")]
        [HttpGet]
        public HttpResponseMessage repotByIdDec()
        {
            var data = AdminReportService.sortByIdDec();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
