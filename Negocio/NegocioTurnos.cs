using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace Negocio
{
    public class NegocioTurnos
    {
        DaoTurnos dao = new DaoTurnos();
        public DataTable obtenerHorariosDeDia(string fecha)
        {
            return dao.verHorariosDeDia(fecha);
        }
    }
}
