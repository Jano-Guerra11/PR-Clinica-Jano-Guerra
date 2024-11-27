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
            if (Request.Cookies["UsuarioInfo"] != null)
            {
                // USUARIO LOGUEADO
                HttpCookie cookie = Request.Cookies["UsuarioInfo"];
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
            else if (Session["tipoUsuario"] != null)
            {
                if (Session["tipoUsuario"].ToString() == "medico")
                {
                    //TIENE ACCESO MEDICO
                    lblUsuario.Text = Session["Legajo"].ToString();
                }
                else
                {
                    // NO TIENE ACCESO MEDICO, ES ADMINISTRADOR
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
            if (this.Request.Cookies["UsuarioInfo"]!= null)
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