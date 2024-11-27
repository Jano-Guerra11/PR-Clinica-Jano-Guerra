using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
namespace Vistas
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            verificarPermisos();
           

        }
        public void verificarPermisos()
        {
            if (Request.Cookies["infoUsuario"] != null)
            {
                HttpCookie cookie = Request.Cookies["infoUsuario"];
                if (cookie["tipoUsuario"] == "Administrador")
                {
                    Response.Redirect("MenuAdministrador.aspx");
                    
                }
                else
                {
                    Response.Redirect("MenuMedicos.aspx");
                    
                }

            } 
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            NegocioUsuarios negU = new NegocioUsuarios();
            DataRow usuario = negU.inicioSesion(txtDni.Text.Trim(), txtContraseña.Text.Trim());

            if (usuario != null) // existe un usuario 
            {
                string legajo = usuario["Legajo_U"].ToString();
                string contrasena = usuario["contrasena_U"].ToString();
                string tipo = usuario["tipo_u"].ToString();

                if (cbRecordarme.Checked)
                {
                    crearCookies(legajo,contrasena,tipo);
                }
                else
                {
                    crearSession(legajo,contrasena,tipo);
                }

                if(tipo == "Administrador")
                {
                    Response.Redirect("MenuAdministrador.aspx");
                }
                else
                {
                    Response.Redirect("MenuMedicos.aspx");
                }
            }

        }
        public void crearCookies(string legajo, string contrasena,string tipo)
        {

           HttpCookie cookie = new HttpCookie("UsuarioInfo");
            cookie["Legajo"] = legajo;
            cookie["contrasena"] = contrasena;
            cookie["tipoUsuario"] = tipo;
            cookie.Path = "/";

            cookie.Expires = DateTime.Now.AddDays(5);

            Response.Cookies.Add(cookie);
        }
        private void crearSession(string Legajo, string contrasena, string TipoUsuario)
        {
            
            Session["Legajo"] = Legajo;
            Session["contrasena"] = contrasena;
            Session["tipoUsuario"] = TipoUsuario;
        }

        protected void cvInicioSesion_ServerValidate(object source, ServerValidateEventArgs args)
        {
            NegocioUsuarios neg = new NegocioUsuarios();
            if (neg.validarLegajo(args.Value.ToString()))
            {
                args.IsValid = true;
            }
            else { args.IsValid = false;
                cvLegajo.Text = " Legajo Incorrecto";
            }
        }
        protected void cvContrasena_ServerValidate(object source, ServerValidateEventArgs args)
        {
            NegocioUsuarios neg = new NegocioUsuarios();
            if (neg.validarContrasena(args.Value.ToString()))
            {
                args.IsValid = true;
            }
            else { args.IsValid = false;
                cvContrasena.Text = "Contraseña Incorrecta";
            }
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
          string  contrasena = txtContraseña.Text;
            if(txtContraseña.TextMode == TextBoxMode.Password)
            {
                txtContraseña.TextMode = TextBoxMode.SingleLine;
                btnMostrar.Text = "Ocultar";
                
                txtContraseña.Attributes["Value"] = contrasena;
            }
            else
            {
                txtContraseña.TextMode = TextBoxMode.Password;
                btnMostrar.Text = "Mostrar";
               
                txtContraseña.Attributes["Value"] = contrasena;
            }
        }
    }
}