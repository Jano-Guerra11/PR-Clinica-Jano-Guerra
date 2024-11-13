using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public  class JornadaLaboral
    {
        private string LegajoMedico;
        private string DiaAtencion;
        private string Ingreso;
        private string egreso;

        public JornadaLaboral()
        {

        }
        public JornadaLaboral(string legajoMedico, string diaAtencion, string ingreso, string egreso)
        {
            LegajoMedico = legajoMedico;
            DiaAtencion = diaAtencion;
            Ingreso = ingreso;
            this.egreso = egreso;
        }

        public string LegajoMedico1 { get => LegajoMedico; set => LegajoMedico = value; }
        public string DiaAtencion1 { get => DiaAtencion; set => DiaAtencion = value; }
        public string Ingreso1 { get => Ingreso; set => Ingreso = value; }
        public string Egreso { get => egreso; set => egreso = value; }
    }
}
