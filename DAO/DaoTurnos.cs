using System;
using System.Collections.Generic;
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
        
    }
}
