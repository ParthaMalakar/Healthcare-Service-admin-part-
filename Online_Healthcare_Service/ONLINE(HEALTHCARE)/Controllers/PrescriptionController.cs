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
    public class PrescriptionController : ApiController
    {
        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("api/Prescriptions")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = PrescriptionService.Get().Take(10);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("api/Prescriptions/pid/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = PrescriptionService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }


        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("api/Prescription/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = PrescriptionService.Get(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [EnableCors("*", "*", "*")]
        [Route("api/Prescription/add")]
        [HttpPost]
        public HttpResponseMessage Add(PrescriptionDTO obj)
        {
            var data = PrescriptionService.Add(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [EnableCors("*", "*", "*")]
        [Route("api/Prescription/update")]
        [HttpPost]
        public HttpResponseMessage Update(PrescriptionDTO Prescription)
        {

            try
            {
                var isUpdated = PrescriptionService.Update(Prescription);
                return Request.CreateResponse(HttpStatusCode.OK, isUpdated);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [EnableCors("*", "*", "*")]
        [Route("api/Prescription/Delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeletePrescription(int id)
        {
            var isDeleted =PrescriptionService.Delete(id);

            return isDeleted ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Prescription Deleted successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Prescription Delete unsuccessfull"
                    }
                );
        }
    }
}
