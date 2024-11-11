using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            verificarPermisos();
        }
        public void verificarPermisos()
        {
            if (Request.Cookies["infoUsuario"] != null)
            {
                // USUARIO LOGUEADO
                HttpCookie cookie = Request.Cookies["infoUsuario"];
                if (cookie["tipoUsuario"] == "administrador")
                {
                    //TIENE ACCESO
                    lblUsuario.Text = cookie["Legajo"];
                }
                else
                {
                    // NO TIENE ACCESO
                    Response.Redirect("MenuMedicos.aspx");
                }
            }
            else
            {
                //EL USUARIO NO ESTA LOGUEADO
                Response.Redirect("Login.aspx");
            }
        }

        protected void lbPacientes_Click(object sender, EventArgs e)
        {
            
        }
    }
}