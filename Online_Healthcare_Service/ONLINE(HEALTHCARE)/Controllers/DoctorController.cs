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
    public class DoctorController : ApiController
    {
        [HttpGet]
        [Route("api/doctors")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = DoctorService.Get().Take(10);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [HttpGet]
        [Route("api/doctor/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = DoctorService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/doctor/add")]
        [HttpPost]
        public HttpResponseMessage Add(DoctorDTO obj)
        {
            var data = DoctorService.Add(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [Route("api/doctor/update")]
        [HttpPost]
        public HttpResponseMessage Update(DoctorDTO doctor)
        {
            
            try
            {
                var isUpdated = DoctorService.Update(doctor);
                return Request.CreateResponse(HttpStatusCode.OK, isUpdated);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [Route("api/doctor/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteDoctor(int id)
        {
            var isDeleted = DoctorService.Delete(id);

            return isDeleted ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Customer Deleted successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Customer Delete unsuccessfully"
                    }
                );
        }
    }
}
