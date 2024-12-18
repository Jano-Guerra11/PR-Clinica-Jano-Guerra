﻿using Entidades;
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

        public DataTable verHorariosDeDia(string fecha, string legajoMedico)
        {
            string consulta = "SELECT Horario_T FROM Turnos WHERE estado_T = 'indefinido' AND Baja_T = 0 AND dia_T LIKE '" + fecha + "%' AND LegajoMedico_T = '" + legajoMedico + "'";
            return ad.obtenerTabla(consulta, "HorariosDelDia");
        }
        public int altaTurno(Turnos turno)
        {
            string consulta = "INSERT INTO Turnos (DniPaciente_T,LegajoMedico_t,dia_T,Horario_T,Estado_T,baja_t) " +
                "SELECT  '" + turno.DniPaciente + "','" + turno.LegajoMedico + "','" + turno.Dia + "','" + turno.Horario + "','indefinido',0";
            return ad.ejecutarConsulta(consulta);
        }
        public bool existeTurno(Turnos turno)
        {
            string consutla = "SELECT * FROM Turnos WHERE CodTurno_T = " + turno.CodTurno;
            return ad.existe(consutla);
        }
        public DataTable obtenerTurnos()
        {
            string consulta = "SELECT codTurno_T AS 'Codigo' ,LegajoMedico_T as 'LegajoMedico' , DniPaciente_T AS 'DniPaciente' ,nombre_P +' '+ apellido_P AS 'Paciente' ," +
                " dia_T AS 'Fecha', Horario_T AS 'Horario' , " +
                "Estado_T AS 'Estado', Observacion_T AS 'Observacion', nombre_Me +' '+apellido_Me AS 'Medico'  FROM TURNOS inner join Pacientes on turnos.dniPaciente_T = " +
                "pacientes.DNI_P inner join Medicos on turnos.LegajoMedico_T = medicos.Legajo_Me  WHERE Baja_T = 'False'";
            return ad.obtenerTabla(consulta, "turnos");
        }
        public DataTable obtenerTurnosFiltrados(Turnos turno, string opFecha, string nombreP, string apellidoP)
        {
            string consulta = "SELECT codTurno_T AS 'Codigo',nombre_P +' '+ apellido_P AS 'Paciente' ," +
                " dia_T AS 'Fecha', Horario_T AS 'Horario' , " +
                "Estado_T AS 'Estado', Observacion_T AS 'Observacion', Legajo_Me  FROM TURNOS inner join Pacientes on turnos.dniPaciente_T = " +
                "pacientes.DNI_P inner join Medicos on turnos.LegajoMedico_T = medicos.Legajo_Me " +
                "WHERE Legajo_Me = '" + turno.LegajoMedico + "'  AND nombre_P LIKE '" + nombreP + "%' " +
                " AND Estado_T LIKE '" + turno.Estado + "%' AND apellido_P LIKE '" + apellidoP + "%' AND dia_T "+opFecha+" '"+turno.Dia+"'";
            return ad.obtenerTabla(consulta, "tablaFiltrada");
        }
        public DataTable obtenerTurnosMedico(string legajoMedico)
        {

            string consulta = "SELECT codTurno_T AS 'Codigo',nombre_P +' '+ apellido_P AS 'Paciente'," +
                " dia_T AS 'Fecha', Horario_T AS 'Horario' , " +
                "Estado_T AS 'Estado', Observacion_T AS 'Observacion', Legajo_Me  FROM TURNOS inner join Pacientes on turnos.dniPaciente_T = " +
                "pacientes.DNI_P inner join Medicos on turnos.LegajoMedico_T = medicos.Legajo_Me " +
                "WHERE LegajoMedico_T = '" + legajoMedico + "'";
            return ad.obtenerTabla(consulta, "turnosMedico");
        }
        public int actualizarEstadoYObservacion(Turnos turno)
        {
            string consulta = "UPDATE Turnos SET observacion_T = '" + turno.Observacion + "' , Estado_T = '" + turno.Estado + "' " +
                "WHERE codTurno_T = " + turno.CodTurno;
            return ad.ejecutarConsulta(consulta);
        }
        public int bajaTurno(string codigo)
        {
            string consulta = "update Turnos SET Baja_T = 1 WHERE codTurno_T = " + codigo;
            return ad.ejecutarConsulta(consulta);
        } 
        public DataTable obtenerTurnosDelMesActual()
        {
            string consulta = "SELECT * FROM TURNOS where month(dia_T) = month(getdate())" +
                " and year(dia_T) = year(getdate()) and baja_T = 'false' ";
            return ad.obtenerTabla(consulta, "turnosDelMes");
        }
        public DataTable obtenerTurnosDePaciente(string dniPaciente)
        {
            string consulta = "select codTurno_T as 'codigo', nombre_Me+' '+apellido_Me AS 'Medico', FORMAT(dia_T,'dd/MM/yyyy') as 'Dia',horario_T as 'Horario', estado_T as 'Estado',observacion_T as 'Observacion',baja_T as 'Baja'" +
                " from pacientes inner join turnos on pacientes.dni_p = turnos.dniPaciente_T inner join medicos on medicos.legajo_Me = turnos.legajoMedico_T " +
                "WHERE baja_p = 'false' AND baja_Me = 'false' and dniPaciente_T = '"+dniPaciente+"'";
            return ad.obtenerTabla(consulta, "turnosDelPaciente");
        }
       
    }
}
