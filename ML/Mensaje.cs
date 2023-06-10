using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Mensaje
    {

        public int IdMensaje { get; set; }
        public string Contenido { get; set; }

        public List<object> Mensajes { get; set; }
    }
}


