using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        NegocioTurnos negTurn = new NegocioTurnos();
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
                    cargarTablaTurnos();
                }
                else
                {
                    // NO TIENE ACCESO MEDICO ES ADMINISTRADOR
                    Response.Redirect("MenuAdministrador.aspx");
                }
            }
            else if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "medico")
                {
                    //TIENE ACCESO MEDICO
                    lblUsuario.Text = Session["legajo"].ToString();
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

        public void cargarTablaTurnos()
        {
            
            string nombre = txtNombre.Text; 
            string apellido = txtApellido.Text;
            string fecha = txtFecha.Text;
            string opFecha = ddlComparacionFecha.SelectedValue;
            string estado = ddlEstado.SelectedItem.Text;
            string legajo = lblUsuario.Text;

            grdTurnos.DataSource = negTurn.obtenerTurnosDeMedico(nombre,apellido,fecha,opFecha,estado,legajo);
            grdTurnos.DataBind();
        }

        protected void grdTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            cargarTablaTurnos();
        }

        protected void grdTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
               Label lblFecha = (Label)e.Row.FindControl("lbl_it_Fecha");
                DateTime fecha = Convert.ToDateTime(((Label)e.Row.FindControl("lbl_it_Fecha")).Text);
                
                lblFecha.Text = fecha.ToString("dd/MM/yyyy");

            }
        }
    }
}