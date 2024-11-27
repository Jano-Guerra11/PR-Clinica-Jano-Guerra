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
            if (Request.Cookies["UsuarioInfo"] != null)
            {
                // USUARIO LOGUEADO Y GUARDADO
                HttpCookie cookie = Request.Cookies["UsuarioInfo"];
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
            else if (Session["tipoUsuario"] != null  )
            {
                if(Session["tipoUsuario"].ToString() == "administrador")
                {
                    lblUsuario.Text = Session["Legajo"].ToString();
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

        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            if (this.Request.Cookies["UsuarioInfo"] != null)
            {
                HttpCookie ck = new HttpCookie("UsuarioInfo");
                ck.Expires = DateTime.Now.AddDays(-1);
                this.Response.Cookies.Add(ck);
            }
            else
            {
                Session.Remove("Legajo");
                Session.Remove("contrasena");
                Session.Remove("tipoUsuario");
            }

            Response.Redirect("Login.aspx");
        }
    }
}