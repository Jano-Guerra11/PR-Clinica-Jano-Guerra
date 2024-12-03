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
                "AND contraseña_U = '" + usuario.Contrasena_U1 + "'";
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
            string consulta = "select * from usuarios where contraseña_u = '" + usuario.Contrasena_U1 + "'";
            return ad.existe(consulta);
        }
        public int altaUsuario(Usuarios usuario)
        {
            string consulta = "INSERT INTO USUARIOS (Legajo_U,contraseña_U,tipo_U,nombreUsuario_U)" +
                " SELECT '"+usuario.Legajo_U1 + "','"+usuario.Contrasena_U1+"','"+usuario.Tipo_U1+"','"+usuario.NombreUsuario_U+"'";
          return  ad.ejecutarConsulta(consulta);
        }
    }
}
