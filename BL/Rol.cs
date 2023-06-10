using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static int Add(ML.Rol rol)
        {
            int query = 0;

            try
            {
                using (DL.JRodriguezPruebaDesarrolloEntities contex = new DL.JRodriguezPruebaDesarrolloEntities())
                {
                    query = contex.RolAdd(rol.NombreRol);
                }
            }
            catch (Exception ex)
            {
                query = 0;
            }
            return query;

        }

        public static int Update(ML.Rol rol)
        {
            int query = 0;
            try
            {
                using (DL.JRodriguezPruebaDesarrolloEntities contex = new DL.JRodriguezPruebaDesarrolloEntities())
                {
                    query = contex.RolUpdate(rol.IdRol, rol.NombreRol);
                }
            }
            catch (Exception ex)
            {
                query = 0;
            }
            return query;
        }

        public static int Delete(int IdRol)
        {
            int query = 0;
            try
            {
                using (DL.JRodriguezPruebaDesarrolloEntities contex = new DL.JRodriguezPruebaDesarrolloEntities())
                {
                    query = contex.RolDelete(IdRol);
                }
            }
            catch (Exception ex)
            {
                query = 0;
            }
            return query;
        }
        public static List<object> GetAll()
        {
            List<object> Roles = new List<object>();

            try
            {
                using (DL.JRodriguezPruebaDesarrolloEntities contex = new DL.JRodriguezPruebaDesarrolloEntities())
                {
                    var query = contex.RolGetAll().ToList();

                    if (query.Count > 0)
                    {
                        foreach (var item in query)
                        {
                            ML.Rol rol = new ML.Rol();

                            rol.IdRol = item.IdRol;
                            rol.NombreRol = item.NombreRol;

                            Roles.Add(rol);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Roles;
        }


        public static object GetById(int IdRol)
        {
            object Rol = new object();

            try
            {
                using (DL.JRodriguezPruebaDesarrolloEntities contex = new DL.JRodriguezPruebaDesarrolloEntities())
                {
                    var query = contex.RolGetById(IdRol).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Rol rol = new ML.Rol();

                        rol.IdRol = query.IdRol;
                        rol.NombreRol = query.NombreRol;


                        Rol = rol;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Rol;
        }
    }
}
