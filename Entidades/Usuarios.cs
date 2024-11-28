using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        private string Legajo_U;
        private string Contrasena_U;
        private string Tipo_U;
        private string nombreUsuario_U;

        public string Legajo_U1 { get => Legajo_U; set => Legajo_U = value; }
        public string Contrasena_U1 { get => Contrasena_U; set => Contrasena_U = value; }
        public string Tipo_U1 { get => Tipo_U; set => Tipo_U = value; }
        public string NombreUsuario_U { get => nombreUsuario_U; set => nombreUsuario_U = value; }
    }
}
