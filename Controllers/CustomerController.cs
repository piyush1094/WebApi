using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication10.Models;
using WebApplication10.Util;

namespace WebApplication10.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly CampDbContext context;
        public CustomerController()
        {
            context = new CampDbContext();
        }
        public Customer Postcustomerss(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            customer.Password = Hashing.HashPassword(customer.Password);
            context.customers.Add(customer);
            context.SaveChanges();

            return customer;
        }

        public HttpResponseMessage Postlogin(string Username, string password)
        {
            var currentaccount = context.customers.SingleOrDefault(a => a.Username.Equals(Username));
            if(currentaccount!=null)
            {
                  if (Hashing.ValidatePassword(password, currentaccount.Password))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, value: TokenManager.GenerateToken(Username));
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, message: "invalid username and password");
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, message: "invalid username and password");
        }
    }
}
