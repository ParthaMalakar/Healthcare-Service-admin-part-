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
    public class PatientAuthController : ApiController
    {
        [HttpPost]
        [Route("api/patientAuth/login")]
        public HttpResponseMessage Login(UserDTO u)
        {
            var data = AuthService.Authenticate(u.Email, u.Password);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Invalid username or password");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/patientAuth/logout/{uid}")]
        public HttpResponseMessage Logout(int uid)
        {
            var data = AuthService.Logout(uid);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully Logged Out");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Already Loggedout");
        }
    }
}
