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
    [EnableCors("*", "*", "*")]
    public class DownloadandVerifyAdminController : ApiController
    {
       // [InValid]
        [Route("api/appointment/download/ID")]
        [HttpGet]
        public HttpResponseMessage Download()
        {
            //var auth = HttpContext.Current.Request.Headers["Authorization"];

            //if (InvestorService.DownloadMyInvestment("rh140025@gmail.com"))
            if (VerifyANDdownloadforADminService.DownloadList(/*UserNameServices.Get(auth))*/))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "File is saved in download folder as AppointmentList.xlsx");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }
        [Route("api/deltebyadmin/verification/create")]
        [HttpPost]
        public HttpResponseMessage createVerification(VarificationDTO V)
        {
            if (VerifyANDdownloadforADminService.createVarification(V))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Verification Code Sent");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Already Verified");
        }

        [Route("api/deltebyadmin/verification/check")]
        [HttpPost]
        public HttpResponseMessage checkVerification(VarificationDTO V)
        {
            if (VerifyANDdownloadforADminService.checkVarification(V))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "verified");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }
    }
}
