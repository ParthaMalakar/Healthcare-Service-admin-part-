using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Http;
using BLL.DTOs;

namespace ONLINE_HEALTHCARE_.Controllers
{
    public class HospitalController:ApiController
    {

        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("api/hospitals")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = HospitalService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }


        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("api/hospital/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = HospitalService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }



        [Route("api/hospital/add")]
        [HttpPost]
        public HttpResponseMessage Add(HospitalDTO obj)
        {
            var data = HospitalService.Add(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [EnableCors("*", "*", "*")]
        [Route("api/hospital/update")]
        [HttpPost]
        public HttpResponseMessage Update(HospitalDTO blood)
        {

            try
            {
                var isUpdated = HospitalService.Update(blood);
                return Request.CreateResponse(HttpStatusCode.OK, isUpdated);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [EnableCors("*", "*", "*")]
        [Route("api/hospital/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var isDeleted = HospitalService.Delete(id);

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

        [Route("api/hospital/{id}/Doctor")]
        [HttpGet]
        public HttpResponseMessage GetwithDoctor(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, HospitalService.GetwithDoctor(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [EnableCors("*", "*", "*")]
        [Route("api/DocList/{id}")]
        [HttpGet]
        public HttpResponseMessage GeTdoc(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, HospitalService.Doctor(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




    }
}