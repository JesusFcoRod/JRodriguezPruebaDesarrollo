using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Mensaje
    {
        public static List<object> GetAll()
        {
            List<object> Mensajes = new List<object>();

            try
            {
                using (DL.JRodriguezPruebaDesarrolloEntities contex = new DL.JRodriguezPruebaDesarrolloEntities())
                {
                    var query = contex.MensajeGetAll().ToList();

                    if (query.Count > 0)
                    {
                        foreach (var item in query)
                        {
                            ML.Mensaje mensaje = new ML.Mensaje();

                            mensaje.IdMensaje = item.IdMensaje;
                            mensaje.Contenido = item.Mensaje;

                            Mensajes.Add(mensaje);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Mensajes;
        }
    }
}
