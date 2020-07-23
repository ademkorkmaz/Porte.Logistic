using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Porte.Logistic.Core.Biz;
using Porte.Logistic.Core.Entity;
using Porte.Logistic.Core.Repository;

namespace Porte.Logistic.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LogisticApiController : ControllerBase
    {
        // GET: api/LogisticApi
        [HttpGet]
        public IEnumerable<Box> Get()
        {

            BoxRepository repo = new BoxRepository();

            return repo.GetBoxes();
        }

        //  https://localhost:44366/api/LogisticApi/HandleOps
        [HttpGet]
        public int HandleOps()
        {
            LogisticBiz biz = new LogisticBiz();

            int res = biz.HandleLogisticOperations();
            return res;
        }

        
    }
}
