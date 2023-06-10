using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static int Add(ML.Usuario usuario)
        {
            int resultado = 0;

            try
            {
                using (DL.JRodriguezPruebaDesarrolloEntities contex = new DL.JRodriguezPruebaDesarrolloEntities())
                {
                    usuario.Password = BL.Usuario.GenerarPassword(usuario);

                    var query = contex.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UserName, usuario.Password, DateTime.Parse(usuario.FechNacimiento), usuario.Rol.IdRol);
                    if (query > 0)
                    {
                        resultado = query;
                    }
                    else
                    {
                        resultado = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return resultado;
        }

        public static int Update(ML.Usuario usuario)
        {
            int resultado = 0;

            try
            {
                using (DL.JRodriguezPruebaDesarrolloEntities contex = new DL.JRodriguezPruebaDesarrolloEntities())
                {
                    var query = contex.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UserName, usuario.Password, DateTime.Parse(usuario.FechNacimiento), usuario.Rol.IdRol);
                    if (query > 0)
                    {
                        resultado = query;
                    }
                    else
                    {
                        resultado = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return resultado;
        }

        public static int Delete(int IdUsuario)
        {
            int resultado = 0;

            try
            {
                using (DL.JRodriguezPruebaDesarrolloEntities contex = new DL.JRodriguezPruebaDesarrolloEntities())
                {
                    var query = contex.UsuarioDelete(IdUsuario);

                    if (query > 0)
                    {
                        resultado = query;
                    }
                    else
                    {
                        resultado = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return resultado;
        }
        public static List<object> GetAll()
        {
            List<object> Usuarios = new List<object>();

            try
            {
                using (DL.JRodriguezPruebaDesarrolloEntities contex = new DL.JRodriguezPruebaDesarrolloEntities())
                {
                    var query = contex.UsuarioGetAll().ToList();

                    if (query.Count > 0)
                    {


                        foreach (var item in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = item.IdUsuario;
                            usuario.NombreCompleto = item.Nombre + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno;
                            usuario.UserName = item.UserName;
                            usuario.Password = item.Password;
                            usuario.FechNacimiento = item.FechaNacimiento.Value.ToString("dd/MM/yyyy");

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = item.IdRol.Value;
                            usuario.Rol.NombreRol = item.NombreRol;

                            Usuarios.Add(usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Usuarios;
        }
        public static object GetById(int IdUsuario)
        {
            object Usuario = new object();

            try
            {
                using (DL.JRodriguezPruebaDesarrolloEntities contex = new DL.JRodriguezPruebaDesarrolloEntities())
                {
                    var query = contex.UsuarioGetById(IdUsuario).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.UserName = query.UserName;
                        usuario.Password = query.Password;
                        usuario.FechNacimiento = query.FechaNacimiento.Value.ToString("dd/MM/yyyy");

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;
                        usuario.Rol.NombreRol = query.NombreRol;

                        Usuario = usuario;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Usuario;
        }

        public static Object GetByUserName(string UserName)
        {
            object Usuario = new object();

            try
            {
                using (DL.JRodriguezPruebaDesarrolloEntities contex = new DL.JRodriguezPruebaDesarrolloEntities())
                {
                    var query = contex.UsuarioGetByUserName(UserName).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Usuario usr = new ML.Usuario();

                        usr.UserName = query.UserName;
                        usr.Password = query.Password;

                        Usuario = usr;
                    }
                    else
                    {
                        Usuario = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Usuario = null;
            }
            return Usuario;
        }

        public static string GenerarPassword(ML.Usuario usuario)
        {
            string Password = usuario.ApellidoPaterno.Substring(0, 1).ToUpper() + usuario.Nombre.ToLower();

            return Password;
        }
    }
}
