using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIPE.Servico.Controllers
{
    public class LoginServicoController : ApiController
    {
        // GET: api/LoginServico
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LoginServico/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LoginServico
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LoginServico/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LoginServico/5
        public void Delete(int id)
        {
        }
    }
}
