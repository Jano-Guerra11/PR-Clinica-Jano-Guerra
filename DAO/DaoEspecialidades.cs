using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DaoEspecialidades
    {
        AccesoDatos ad = new AccesoDatos();
        public DataTable ObtenerEspecialidades()
        {
            string consulta = "SELECT * FROM Especialidades";
            return ad.obtenerTabla(consulta, "Especialidades");
        } 

        public DataTable cantidadDeTurnosDeCadaEsp()
        {
            string consulta = "SELECT nombreEspecialidad_Esp AS 'Especialidad',count(legajoMedico_T) AS 'Cantidad de solicitudes' " +
                " FROM especialidades inner join medicos on especialidades.idEspecialidad_Esp " +
                "= medicos.idEspecialidad inner join turnos on turnos.legajoMedico_T = medicos.legajo_Me " +
                "WHERE baja_Me = 'false' AND baja_T = 'false' group by nombreEspecialidad_Esp order by 'Cantidad de solicitudes' desc";
            return ad.obtenerTabla(consulta, "solicitudesDeCadaEsp");
        }
    }
}
