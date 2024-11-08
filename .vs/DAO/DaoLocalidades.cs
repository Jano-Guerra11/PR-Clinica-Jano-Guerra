using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DaoLocalidades
    {
        AccesoDatos ad = new AccesoDatos();
        public DataTable obtenerLocalidadesDeProvincia(int idProvincia)
        {
            string consulta = "SELECT IdLocalidad,NombreLocalidad FROM Localidades WHERE IdProvincia = " + idProvincia;
          return  ad.obtenerTabla(consulta, "LocalidadesDeProvincia");
        }
    }
}
