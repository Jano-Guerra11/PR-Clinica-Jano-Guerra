using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entidades;
namespace Negocio
{
    public class NegocioAdministradores
    {
        DaoAdministradores dao = new DaoAdministradores();
       

        public bool contraseñaAdmin(string contraseña)
        {
            administrador admin = new administrador();
            admin.Contrasena = contraseña;
            return dao.ContrasenaAdmin(admin);
        }
        public bool LegajoAdmin(string legajo)
        {
            administrador admin = new administrador();
            admin.Legajo = legajo;
            return dao.LegajoAdmin(admin);
        }
    }
}
