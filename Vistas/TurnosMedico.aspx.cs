using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        NegocioTurnos negTurn = new NegocioTurnos();
        string legajo;
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
                if (cookie["tipoUsuario"] == "medico")
                {
                    lblUsuario.Text = cookie["Nombre"];
                  
                    Session["lm"] = cookie["Legajo"];
                    cargarTablaTurnos();
                }
                else { Response.Redirect("MenuAdministrador.aspx"); }
            }
            else if (Session["tipoUsuario"] != null)
            {
                if (Session["tipoUsuario"].ToString() == "medico")
                {
                    lblUsuario.Text = Session["Nombre"].ToString();
                    Session["lm"] = Session["Legajo"].ToString();
                    cargarTablaTurnos();
                }
                else { Response.Redirect("MenuAdministrador.aspx");}
            }
            else{ Response.Redirect("Login.aspx");}
        }
        public void cargarTablaTurnos()
        {    
            if(txtNombre.Text == string.Empty && txtApellido.Text == string.Empty && txtFecha.Text == string.Empty
                 && ddlEstado.SelectedIndex == 0)
            {
           grdTurnos.DataSource = negTurn.obtenerTurnosMedico(Session["lm"].ToString());
           grdTurnos.DataBind();
            }
            else
            {
                grdTurnos.DataSource = negTurn.obtenerTurnosFiltrados(txtNombre.Text, txtApellido.Text, txtFecha.Text, ddlComparacionFecha.Text, ddlEstado.SelectedValue,Session["lm"].ToString());
                grdTurnos.DataBind();
            }
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            cargarTablaTurnos();
        }
        protected void grdTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            {
               Label lblFecha = (Label)e.Row.FindControl("lbl_it_Fecha");
                DateTime fecha = Convert.ToDateTime(((Label)e.Row.FindControl("lbl_it_Fecha")).Text);
                
                lblFecha.Text = fecha.ToString("dd/MM/yyyy");
            }
            else if(e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Edit)
            {
                Label lblFecha = (Label)e.Row.FindControl("lbl_Eit_Fecha");
                DateTime fecha = Convert.ToDateTime(((Label)e.Row.FindControl("lbl_Eit_Fecha")).Text);
                lblFecha.Text = fecha.ToString("dd/MM/yyyy");
            }
        }
        protected void grdTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdTurnos.EditIndex = e.NewEditIndex;
            cargarTablaTurnos();
        }
        protected void grdTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowindex = e.RowIndex;
            GridViewRow fila = grdTurnos.Rows[rowindex];
            int numero = Convert.ToInt32(((Label)grdTurnos.Rows[e.RowIndex].FindControl("lbl_eit_Numero")).Text);
            string observacion = ((TextBox)grdTurnos.Rows[e.RowIndex].FindControl("txt_eit_Observacion")).Text;
            string estado = ((DropDownList)fila.FindControl("ddlEstados")).SelectedValue.ToString();

            if(negTurn.dejarEstadoYobservacion(numero, observacion, estado))
            {
                lblMensaje.Text = "Agregado correctamente";
            }
            else {lblMensaje.Text = " no se agrego"; }
            grdTurnos.EditIndex = -1;
            cargarTablaTurnos();
        }
        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtFecha.Text = string.Empty;
            ddlEstado.SelectedIndex = 0;
            cargarTablaTurnos();
        }
        protected void grdTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdTurnos.EditIndex = -1;
            cargarTablaTurnos();
        }
    }
}