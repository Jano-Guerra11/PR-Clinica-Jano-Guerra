using DAO;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioUsuarios
    {
        DaoUsuarios dao = new DaoUsuarios();
        public int inicioSesion(string legajo, string contrasena)
        {
            Usuarios usuario = new Usuarios();
            usuario.Legajo_U1 = legajo;
            usuario.Contrasena_U1 = contrasena;
            DataRow datosUsuario = dao.traerUsuario(usuario);
            if(datosUsuario != null )
            {
                if (datosUsuario["Tipo_U"].ToString().ToLower() == "administrador")
                {
                    return 1; // USUARIO ADMINISTRADOR
                }
                else { return 2; }  // USUARIO MEDICO
            }
            else
            { return 0; }  // USUARIO INEXISTENTE
        }
    }
}
