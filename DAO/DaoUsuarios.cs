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
        public DataTable traerUsuario(Usuarios usuario)
        {
            string consulta = "SELECT * FROM usuarios WHERE Legajo_U = '" + usuario.Legajo_U1 + "' " +
                "AND contrasena_U = '" + usuario.Contrasena_U1 + "'";
           DataTable Tabla =  ad.obtenerTabla(consulta, "usuario");
            return Tabla;

        }
        public bool existeLegajo(Usuarios usuario)
        {
            string consulta = "select * from usuarios where legajo_u = '" + usuario.Legajo_U1 + "'";
           return ad.existe(consulta);
        }
        public bool existeContrasena(Usuarios usuario)
        {
            string consulta = "select * from usuarios where contrasena_u = '" + usuario.Contrasena_U1 + "'";
            return ad.existe(consulta);
        }
    }
}
