using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class RolController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Rol rol = new ML.Rol();
            List<object> Roles = new List<object>();
            Roles = BL.Rol.GetAll();

            if (Roles.Count > 0)
            {
                rol.Roles = Roles;
            }

            return View(rol);
        }

        [HttpGet]
        public ActionResult Form(int? IdRol)
        {
            Object RolObj = new object();
            ML.Rol rol = new ML.Rol();



            if (IdRol != null)
            {
                rol.IdRol = IdRol.Value;

                RolObj = BL.Rol.GetById(rol.IdRol);

                if (RolObj != null)
                {
                    rol = (ML.Rol)RolObj;
                    return View(rol);
                }
                else
                {
                    ViewBag.Message = "Error al consultar la informacion del Rol";
                    return PartialView("Modal");
                }

            }

            return View(rol);
        }

        [HttpPost]

        public ActionResult Form(ML.Rol rol)
        {
            if (rol.IdRol == 0)
            {
                int QueryAdd = BL.Rol.Add(rol);

                if (QueryAdd > 0)
                {
                    ViewBag.Message = "Se he agregado el nuevo Rol";
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
                int QueryUpdate = BL.Rol.Update(rol);

                if (QueryUpdate > 0)
                {
                    ViewBag.Message = "Se he actualizado el Rol";
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

        public ActionResult Delete(int IdRol)
        {
            int QueryDelete = BL.Rol.Delete(IdRol);

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
    }
}