using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace DAO
{
    public class DaoAdministradores
    {
        AccesoDatos ad = new AccesoDatos();
       public bool existeAdministrador(administrador admin)
        {
            string consulta = "SELECT * FROM Administradores where contraseña_Ad = '" + admin.Contrasena + "' AND Legajo_Ad = '" + admin.Legajo+"'";
            return ad.existe(consulta);
        }

        public bool ContrasenaAdmin(administrador admin)
        {
            string consulta = "SELECT * FROM Administradores where contraseña_Ad = '" + admin.Contrasena + "'";
            return ad.existe(consulta);
        }
        public bool LegajoAdmin(administrador admin)
        {
            string consulta = "SELECT * FROM Administradores where Legajo_Ad = '" + admin.Legajo + "'";
            return ad.existe(consulta);
        }
    }
}
