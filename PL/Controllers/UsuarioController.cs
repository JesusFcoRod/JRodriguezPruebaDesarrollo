using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            List<object> Usuarios = new List<object>();
            Usuarios = BL.Usuario.GetAll();

            if (Usuarios.Count > 0)
            {
                usuario.Usuarios = Usuarios;
            }

            return View(usuario);
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            List<object> Roles = new List<object>();
            Object UsuarioObj = new object();

            Roles = BL.Rol.GetAll();

            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();

            if (Roles.Count > 0)
            {
                usuario.Rol.Roles = Roles;
            }

            if (IdUsuario != null)
            {
                usuario.IdUsuario = IdUsuario.Value;
                UsuarioObj = BL.Usuario.GetById(IdUsuario.Value);

                if (UsuarioObj != null)
                {
                    usuario = (ML.Usuario)UsuarioObj;
                    usuario.Rol.Roles = Roles;

                    return View(usuario);
                }
                else
                {
                    ViewBag.Message = "Error al consultar la informacion del usuario";
                    return PartialView("Modal");
                }

            }

            return View(usuario);
        }

        [HttpPost]

        public ActionResult Form(ML.Usuario usuario)
        {
            if (usuario.IdUsuario == 0)
            {
                int QueryAdd = BL.Usuario.Add(usuario);

                if (QueryAdd > 0)
                {
                    ViewBag.Message = "Se he agregado el nuevo usuario";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurro un problema al querer actualizar el registro";
                    return PartialView("Modal");
                }

            }
            else
            {
                int QueryUpdate = BL.Usuario.Update(usuario);

                if (QueryUpdate > 0)
                {
                    ViewBag.Message = "Se he agregado el nuevo usuario";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurro un problema al querer actualizar el registro";
                    return PartialView("Modal");
                }
            }
        }

        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            int QueryDelete = BL.Usuario.Delete(IdUsuario);

            if (QueryDelete > 0)
            {
                ViewBag.Message = "Se he borrado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "Ocurrio un problema al eliminar el registro";
                return PartialView("Modal");
            }
        }


        [HttpGet]
        public ActionResult LoginPersona()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPersona(ML.Usuario usuario)
        {
            Object Usuario = BL.Usuario.GetByUserName(usuario.UserName);

            if (Usuario != null)
            {
                ML.Usuario usuarioUn = (ML.Usuario)Usuario;

                if (usuarioUn.Password == usuario.Password)
                {
                    return RedirectToAction("GetAll", "Usuario");

                }
                else
                {
                    ViewBag.Message = "Credenciales Ingresadas Invalidas";
                    return PartialView("Modal");

                }
            }
            else
            {
                ViewBag.Message = "La persona no se encuantra dada de alta en la base de datos";
                return PartialView("Modal");
            }
        }


        [HttpGet]
        public ActionResult MostrarMensaje()
        {
            ML.Mensaje Mensaje = new ML.Mensaje();
            List<object> Mensajes = new List<object>();

            try
            {
                using (var client = new HttpClient())
                {
                    string urlApi = ConfigurationManager.AppSettings["urlApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var responseTask = client.GetAsync("Mensaje/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var redTask = resultServicio.Content.ReadAsAsync<List<object>>();
                        redTask.Wait();

                        foreach (var resultItem in redTask.Result)
                        {
                            ML.Mensaje resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Mensaje>(resultItem.ToString());
                            Mensajes.Add(resultItemList);
                        }
                    }
                    Mensaje.Mensajes = Mensajes;
                }

            }
            catch (Exception ex)
            {
            }

            return View(Mensaje);
        }
    }



}
