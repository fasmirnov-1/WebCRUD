using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebCRUD.Controllers
{
    public class JanrController : ApiController
    {
        [HttpGet()]
        public Janr[] GetAllJanrs()
        {
            Janr[] janrs = null;

            using (IOJanr ioJanrs = new IOJanr())
            {
                janrs = ioJanrs.GetAllJanrs().ToArray();
            }

            return janrs;
        }

        [HttpGet()]
        public Janr GetJanrByID(Guid ID)
        {
            Janr janr = null;

            using (IOJanr ioJanr = new IOJanr())
            {
                janr = ioJanr.GetJanrByID(ID);
            }

            return janr;
        }

        [HttpDelete()]
        public void RemoveJanrByID(Guid ID)
        {
            using (IOJanr ioJanr = new IOJanr())
            {
                ioJanr.RemoveJanr(ID);
            }
        }

        [HttpPut()]
        public void AddJanr(Janr janr)
        {
            using (IOJanr ioJanr = new IOJanr())
            {
                ioJanr.AddJanr(janr);
            }
        }
    }
}