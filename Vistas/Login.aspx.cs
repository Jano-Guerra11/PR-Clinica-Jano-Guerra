using System;
using System.Collections.Generic;
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
            if (this.Request.Cookies["Legajo"] != null && this.Request.Cookies["Contraseña"] != null)
            {
                txtContraseña.Text = Request.Cookies["Contraseña"].Value; 
                txtDni.Text = Request.Cookies["Legajo"].Value;
                lblMensaje.Text = Request.Cookies["Contraseña"].Value;
            }
            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string legajo = txtDni.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            
            NegocioUsuarios negU = new NegocioUsuarios();
            crearCookies(legajo,contraseña );

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
        public void crearCookies(string legajo,string contraseña)
        {
            if (cbRecordarme.Checked == true)
            {
                HttpCookie ckL = new HttpCookie("Legajo", legajo);
                HttpCookie ckC = new HttpCookie("Contraseña", contraseña);
                ckL.Expires = DateTime.Now.AddMinutes(5);
                ckC.Expires = DateTime.Now.AddMinutes(5);
                this.Response.Cookies.Add(ckL);
                this.Response.Cookies.Add(ckC);
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
    }
}