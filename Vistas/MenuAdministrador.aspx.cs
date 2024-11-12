using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                // USUARIO LOGUEADO Y GUARDADO
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
            else if (Convert.ToInt32(Session["yaInicio"]) != 1 )
            {
                //EL USUARIO NO ESTA LOGUEADO
                Response.Redirect("Login.aspx");
            }
        }

        protected void lbPacientes_Click(object sender, EventArgs e)
        {
            
        }

        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            if (this.Request.Cookies["infoUsuario"] != null)
            {
                Request.Cookies["infoUsuario"].Expires = DateTime.Now.AddDays(-1);
                this.Response.Cookies.Add(Request.Cookies["infoUsuario"]);

            }
            Session["yaInicio"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}