using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class administrador
    {
        private string legajo;
        private string dni;
        private string nombre;
        private string apellido;
        private string contrasena;

        public string Legajo { get => legajo; set => legajo = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
    }
}
