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
    public class AdminAuthController : ApiController
    {
        [HttpPost]
        [Route("api/AdminAuth/login")]
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
        [Route("api/AdminAuth/logout/{uid}")]
        public HttpResponseMessage Logout(int uid)
        {
            var data = AuthService.Logout(uid);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully Logged Out");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Already Loggedout");
        }
        [Route("api/admin/add")]
        [HttpPost]
        public HttpResponseMessage Add(AdminDTO obj)
        {
            var data = AdminService.Add(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [HttpGet]
        [Route("api/Admin/byemail/{id}")]
        public HttpResponseMessage GetbyEmail(string id)
        {
            id = id + ".com";
            var data = AdminService.GetByEmail(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
