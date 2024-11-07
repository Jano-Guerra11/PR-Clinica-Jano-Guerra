using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DaoProvincias
    {
        AccesoDatos ad = new AccesoDatos();
        public DataTable obtenerProvincias()
        {
            string consulta = "SELECT * FROM Provincias";
            return ad.obtenerTabla(consulta, "Provincias");
        }
        public bool existeProvincia(int idProvincia)
        {
            string consulta = "SELECT * FROM Provincias WHERE IdProvincia_Pr = " + idProvincia;
           return ad.existe(consulta);
        }
    }
}
