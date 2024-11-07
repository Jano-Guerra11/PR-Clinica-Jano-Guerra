using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        private string Legajo;
        private string dni;
        private string nombre;
        private string apellido;
        private string sexo;
        private string nacionalidad;
        private string fechaNacimiento;
        private string direccion;
        private int idLocalidad;
        private int  idProvincia;
        private string correo;
        private string telefono;
        private int idEspecialidad;
        private string diasAtencion;
        private string horarioAtencion;
        private string Contrasena;

        public string Legajo1 { get => Legajo; set => Legajo = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int idLocalidad1 { get => idLocalidad; set => idLocalidad = value; }
        public int idProvincia1 { get => idProvincia; set => idProvincia = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int idEspecialidad1 { get => idEspecialidad; set => idEspecialidad = value; }
        public string DiasAtencion { get => diasAtencion; set => diasAtencion = value; }
        public string HorarioAtencion { get => horarioAtencion; set => horarioAtencion = value; }
        public string Contrasena1 { get => Contrasena; set => Contrasena = value; }
    }
}
