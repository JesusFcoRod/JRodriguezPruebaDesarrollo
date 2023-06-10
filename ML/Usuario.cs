﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FechNacimiento { get; set; }
        public string NombreCompleto { get; set; }
        public ML.Rol Rol { get; set; }
        public List<object> Usuarios { get; set; }
    }
}
