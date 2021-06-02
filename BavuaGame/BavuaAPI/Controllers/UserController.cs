using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BavuaBL;
using BavuaDAL;

namespace BavuaAPI.Controllers
{
    [Route("api/user")]
    public class UserController : ApiController
    {
        BavuaBL.UserBL userbl = new UserBL();

        [HttpPost]
        [Route("SignUp")]
        public int SignUp(Users user)
        {
            return userbl.InsertUser(user);
        }
    }



}
