using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace SL.Controllers
{
    public class MensajeController : ApiController
    {

        [HttpGet]
        [Route("api/Mensaje/GetAll")]

        public IHttpActionResult GetAll()
        {
            List<object> Mensajes = new List<object>();

            Mensajes = BL.Mensaje.GetAll();

            if (Mensajes.Count > 0)
            {
                return Ok(Mensajes);
            }
            else
            {
                return NotFound();
            }
        }
    }
}