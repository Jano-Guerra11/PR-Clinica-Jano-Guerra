using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DaoTurnos
    {
        AccesoDatos ad = new AccesoDatos();
        
        public DataTable diasYHorariosOcupados()
        {
            string consulta = "SELECT dia_T,Horario_T FROM Turnos WHERE estado_T = 'indefinido' AND Baja_T = 0";
           return ad.obtenerTabla(consulta, "turnosOcupados");
        }
        
        public DataTable verHorariosDeDia(string fecha,string legajoMedico)
        {
            string consulta = "SELECT Horario_T FROM Turnos WHERE estado_T = 'indefinido' AND Baja_T = 0 AND dia_T LIKE '"+fecha+"%' AND LegajoMedico_T = '"+legajoMedico+"'";
            return ad.obtenerTabla(consulta, "HorariosDelDia");
        }
        public int altaTurno(Turnos turno)
        {
            string consulta = "INSERT INTO Turnos (DniPaciente_T,LegajoMedico_t,dia_T,Horario_T,Estado_T,baja_t) " +
                "SELECT '" + turno.DniPaciente + "','" + turno.LegajoMedico + "','" + turno.Dia + "','" + turno.Horario + "','indefinido',0";
          return  ad.ejecutarConsulta(consulta);
        }
        public bool existeTurno(Turnos turno)
        {
            string consutla = "SELECT * FROM Turnos WHERE CodTurno_T = '" + turno.CodTurno + "'";
            return ad.existe(consutla);
        }
        public DataTable obtenerTurnos()
        {
            string consulta = "SELECT codTurno_T AS 'Codigo', DniPaciente_T AS 'Dni del paciente', nombre_P AS 'Paciente'," +
                "LegajoMedico_T AS 'Legajo Medico', Nombre_Me AS 'Medico',dia_T AS 'Fecha', Horario_T AS 'Horario' ," +
                "Estado_T AS 'Estado', Observacion_T AS 'Observacion' FROM TURNOS inner join Pacientes on turnos.dniPaciente_T = " +
                "pacientes.DNI_P inner join Medicos on turnos.LegajoMedico_T = medicos.Legajo_Me";
          return  ad.obtenerTabla(consulta, "turnos");
        }
    }
}
