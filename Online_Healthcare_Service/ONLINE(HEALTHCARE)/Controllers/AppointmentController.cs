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
    public class AppointmentController : ApiController
    {
        [HttpGet]
        [Route("api/Appointments")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = AppointmentService.Get().Take(10);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [HttpGet]
        [Route("api/Appointment/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = AppointmentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Appointment/add")]
        [HttpPost]
        public HttpResponseMessage Add(AppointmentDTO obj)
        {
            var data = AppointmentService.Add(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [Route("api/Appointment/update")]
        [HttpPost]
        public HttpResponseMessage Update(AppointmentDTO Appointment)
        {

            try
            {
                var isUpdated = AppointmentService.Update(Appointment);
                return Request.CreateResponse(HttpStatusCode.OK, isUpdated);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [Route("api/Appointment/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteAppointment(int id)
        {
            var isDeleted = AppointmentService.Delete(id);

            return isDeleted ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Appointment Deleted successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Appointment Delete unsuccessfully"
                    }
                );
        }
    }
}
