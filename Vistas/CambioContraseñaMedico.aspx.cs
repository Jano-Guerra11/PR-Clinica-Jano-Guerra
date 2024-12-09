using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class CambioContraseñaMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            verificarPermisos();
            }
        }
        public void verificarPermisos()
        {
            if (Request.Cookies["infoUsuario"] != null)
            {
                HttpCookie cookie = Request.Cookies["infoUsuario"];
                if (cookie["tipoUsuario"].ToLower() == "administrador")
                {
                    lblUsuario.Text = cookie["Nombre"];
                    Session["legajo"] = cookie["Legajo"];
                }
                else Response.Redirect("MenuMedicos.aspx");
            }
            else if (Session["tipoUsuario"] != null)
            {
                if (Session["tipoUsuario"].ToString().ToLower() == "administrador")
                {
                    lblUsuario.Text = Session["Nombre"].ToString();
                    Session["legajo"] = Session["Legajo"].ToString();
                }
                else Response.Redirect("MenuMedicos.aspx");

            }
            else Response.Redirect("Login.aspx");
        }

        protected void cvContraseña_ServerValidate(object source, ServerValidateEventArgs args)
        {
            NegocioUsuarios neg = new NegocioUsuarios();
            
            DataRow usuario = neg.inicioSesion(Session["legajo"].ToString(), args.Value.ToString());
            if (usuario != null)
            {
                string contraseña = usuario["contrasena_U"].ToString();

                if (contraseña == args.Value.ToString())
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                    cvContraseña.Text = "Contraseña Incorrecta";
                }
            }
            else
            {
                args.IsValid = false;
                cvContraseña.Text = "Contraseña Incorrecta";
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            NegocioUsuarios negUs = new NegocioUsuarios();
            if (negUs.cambioContraseña(Session["legajo"].ToString(), txtContraseña2.Text))
            {
                lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = "Modificada con exito";
            }
            else
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Error al modificar";
            }
            txtContraseña.Text = string.Empty;
            txtContraseña1.Text = string.Empty;
            txtContraseña2.Text = string.Empty;
                   

        }
    }
}