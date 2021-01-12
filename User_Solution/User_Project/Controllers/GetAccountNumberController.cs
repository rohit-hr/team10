﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using User_Project.Models;

namespace User_Project.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class GetAccountNumberController : ApiController
    {
        dbBankEntities1 entities = new dbBankEntities1();

        [HttpGet]
        public HttpResponseMessage GetAccountNumber(string id)
        {
            int customer_id = Convert.ToInt32(id);
            tblNetBanking customer = entities.tblNetBankings.Where(c => c.user_id == customer_id).FirstOrDefault();
            if (customer == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid ID");
            else
            {
                return Request.CreateResponse<int>(HttpStatusCode.OK, customer.account_number);
            }
        }
    }
}