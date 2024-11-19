using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace Negocio
{
    public class NegocioLocalidades
    {
        DaoLocalidades dao = new DaoLocalidades();
        DaoProvincias daoProv = new DaoProvincias();    
        public DataTable obtenerLocalidadesDeProvincia(int idProvincia)
        {
  
           return  dao.obtenerLocalidadesDeProvincia(idProvincia);
        }
        public DataTable obtenerTodasLasLocalidades()
        {
            return dao.obtenerTodasLasLocalidades();
        }
    }
}
