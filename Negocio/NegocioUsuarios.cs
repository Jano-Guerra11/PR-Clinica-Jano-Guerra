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
        public DataRow inicioSesion(string legajo, string contrasena)
        {
            Usuarios usuario = new Usuarios();
            usuario.Legajo_U1 = legajo;
            usuario.Contrasena_U1 = contrasena;
            DataTable tablaUsuario = dao.traerUsuario(usuario);
             
            if(tablaUsuario.Rows.Count > 0  )
            {
                return tablaUsuario.Rows[0];
                
            }
            else
            { return null; }  // USUARIO INEXISTENTE
        }
        public bool validarLegajo(string legajo)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Legajo_U1 = legajo;
            return dao.existeLegajo(usuarios);
        }
        public bool validarContrasena(string contrasena)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Contrasena_U1 = contrasena;
           return dao.existeContrasena(usuarios);
        }
    }
}
