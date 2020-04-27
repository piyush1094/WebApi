
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication10.Models;
using WebApplication10.Util;

namespace WebApplication10.Controllers
{
    public class LoginController : ApiController
    {
        private readonly CampDbContext context;
        public LoginController()
        {
            context = new CampDbContext();
        }
        //[HttpPost]
        //public HttpResponseMessage Validlogin(string Username, string password)
        //{
        //    var currentaccount = context.customers.SingleOrDefault(a => a.Username.Equals(Username));
        //    if (currentaccount != null)
        //    {
        //        if (Hashing.ValidatePassword(password, currentaccount.Password))
        //        {
        //            var token = TokenManager.GenerateToken(Username);
        //            return Request.CreateResponse(HttpStatusCode.OK, value: TokenManager.GenerateToken(Username));
        //        }
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, message: "invalid username and password");
        //    }
        //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, message: "invalid username and password");
        //}

        [HttpPost]
        public HttpResponseMessage Validlogin(login user)
        {
            var currentaccount = context.customers.SingleOrDefault(a => a.Username.Equals(user.Username));
            if (currentaccount != null)
            {
                if (Hashing.ValidatePassword(user.password, currentaccount.Password))
                {
                    var token = TokenManager.GenerateToken(user.Username);
                    return Request.CreateResponse(HttpStatusCode.OK, value: TokenManager.GenerateToken(user.Username));
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, message: "invalid username and password");
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, message: "invalid username and password");
        }


        //public IHttpActionResult setsession(string data)
        //{
        //    HttpContext.Current.Session.Add("token", data);
        //    return Ok("session data set");
        //}

        //public HttpResponseMessage Validlogin(string Username, string password)
        //{

        //    if (Username=="admin"&&password=="admin")
        //    {
        //            return Request.CreateResponse(HttpStatusCode.OK, value: TokenManager.GenerateToken(Username));
        //    }
        //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, message: "invalid username and password");
        //}
    }
}
