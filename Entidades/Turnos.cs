using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turnos
    {
        private int codTurno;
        private string dniPaciente;
        private string legajoMedico;
        private string dia;
        private TimeSpan horario;
        private string estado;
        private string observacion;
        private bool baja;

        public int CodTurno { get => codTurno; set => codTurno = value; }
        public string DniPaciente { get => dniPaciente; set => dniPaciente = value; }
        public string LegajoMedico { get => legajoMedico; set => legajoMedico = value; }
        public string Dia { get => dia; set => dia = value; }
        public TimeSpan Horario { get => horario; set => horario = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public bool Baja { get => baja; set => baja = value; }
    }
}
