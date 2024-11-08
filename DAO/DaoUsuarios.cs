using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DaoUsuarios
    {
        AccesoDatos ad = new AccesoDatos(); 
        public DataRow traerUsuario(Usuarios usuario)
        {
            string consulta = "SELECT * FROM usuarios WHERE Legajo_U = '" + usuario.Legajo_U1 + "' " +
                "AND contrasena_U = '" + usuario.Contrasena_U1 + "'";
           DataTable Tabla =  ad.obtenerTabla(consulta, "usuario");
            return Tabla.Rows[0];

        }
    }
}
