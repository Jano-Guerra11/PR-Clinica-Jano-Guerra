using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
namespace Vistas
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        /* este form se va a ingresar el dni y la contraseña y dependiendo de a que rama pertenezca(administrador o medico)
         * se va a redirigir a la secuencia de formularios correspondientes al presionar el boton ingresar 
          */
        
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
                    
                    Response.Redirect("MenuMedicos.aspx");
                }
                else
                {
                    
                    Response.Redirect("MenuAdministrador.aspx");
                }
            }
            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string legajo = txtDni.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            
            NegocioUsuarios negU = new NegocioUsuarios();
           

            if (this.Request.Cookies["infoUsuario"] != null)
            {
            HttpCookie cookie = new HttpCookie("infoUsuario");
            cookie.Expires = DateTime.Now.AddDays(-1);
            this.Response.Cookies.Add(cookie);
            }
           
            crearCookies(legajo, contraseña);

            Session["yaInicio"] = 1;

            switch (negU.inicioSesion(legajo,contraseña))
            {
                case 1:
                    Server.Transfer("MenuAdministrador.aspx");
                    
                    break;
                case 2:
                    Server.Transfer("MenuMedicos.aspx");
                   
                    break;
                case 0:
                    lblMensaje.Text = "USUARIO INCORRECTO";
                    break;
            }
           
        }
        public void crearCookies(string legajo, string contrasena)
        {
            NegocioUsuarios Neg = new NegocioUsuarios();
           int x = Neg.inicioSesion(legajo,contrasena);
            if (cbRecordarme.Checked)
            {

                if (x != 0)
                {
                    // SI EL USUARIO ES CORRECTO CREO UNA COOKIE NUEVA CON EL USUARIO
                    HttpCookie cookie = new HttpCookie("infoUsuario");
                    this.Response.Cookies.Add(cookie);
                    cookie["Legajo"] = legajo;
                    cookie["Contrasena"] = contrasena;
                    if (x == 1)
                    {
                        cookie["tipoUsuario"] = "administrador";
                    }
                    else { cookie["tipoUsuario"] = "medico"; }

                    cookie.Expires = DateTime.Now.AddHours(2);

                    Response.Cookies.Add(cookie);
                }
                
            }
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