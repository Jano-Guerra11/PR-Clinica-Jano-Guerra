using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioEspecialidades
    {
        DaoEspecialidades dao = new DaoEspecialidades();
        public DataTable obtenerEspecialidades()
        {

           return dao.ObtenerEspecialidades();
        }
    }
}
