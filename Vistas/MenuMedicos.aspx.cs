using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class MenuMedicos : System.Web.UI.Page
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
                if (cookie["tipoUsuario"] == "medico")
                {
                    //TIENE ACCESO MEDICO
                    lblUsuario.Text = cookie["Legajo"];
                }
                else
                {
                    // NO TIENE ACCESO MEDICO ES ADMINISTRADOR
                    Response.Redirect("MenuAdministrador.aspx");
                }
            }
            else
            {
                //EL USUARIO NO ESTA LOGUEADO
                Response.Redirect("Login.aspx");
            }
        }

        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            if (this.Request.Cookies["infoUsuario"]!= null)
            {
                HttpCookie ck = new HttpCookie("infoUsuario");
                ck.Expires = DateTime.Now.AddDays(-1);
                this.Response.Cookies.Add(ck);                
            }
            Response.Redirect("Login.aspx");
        }
    }
}