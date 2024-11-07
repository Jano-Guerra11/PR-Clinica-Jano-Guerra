using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        private string dni;
        private string nombre;
        private string apellido;
        private string sexo;
        private string nacionalidad;
        private string fechaNacimiento;
        private string direccion;
        private int localidad;
        private int provincia;
        private string correo;
        private string telefono;

        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Localidad { get => localidad; set => localidad = value; }
        public int Provincia { get => provincia; set => provincia = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
