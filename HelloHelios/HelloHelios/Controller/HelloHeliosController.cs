using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HelloHelios.Controller
{
    public class HelloHeliosController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}