using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace Negocio
{
    public class NegocioProvincias
    {
        DaoProvincias dao = new DaoProvincias();
        public DataTable obtenerProvincias()
        {
            return dao.obtenerProvincias();
        }
    }
}
