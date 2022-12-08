using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ONLINE_HEALTHCARE_.Controllers
{
    public class PatientController : ApiController
    {
        [HttpGet]
        [Route("api/Patients")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = PatientService.Get().Take(10);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [HttpGet]
        [Route("api/Patient/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = PatientService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Patient/add")]
        [HttpPost]
        public HttpResponseMessage Add(PatientDTO obj)
        {
            var data = PatientService.Add(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [Route("api/Patient/update")]
        [HttpPost]
        public HttpResponseMessage Update(PatientDTO Patient)
        {

            try
            {
                var isUpdated = PatientService.Update(Patient);
                return Request.CreateResponse(HttpStatusCode.OK, isUpdated);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [Route("api/Patient/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeletePatient(int id)
        {
            var isDeleted = PatientService.Delete(id);

            return isDeleted ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Patient Deleted successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Patient Delete unsuccessfully"
                    }
                );
        }
    }
}
