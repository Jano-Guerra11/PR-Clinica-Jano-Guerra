using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
namespace Vistas
{
    public partial class ABMLPaciente : System.Web.UI.Page
    {
        NegocioPacientes negPac = new NegocioPacientes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                verificarPermisos();
                cargarGridView();
                cargarDdlProvincias();

            }
            lblMensajeBorrar.Text = string.Empty;
            lblMensaje.Text = string.Empty;
        }
        public void verificarPermisos()
        {
            if (Request.Cookies["infoUsuario"] != null)
            {
                // USUARIO LOGUEADO Y GUARDADO
                HttpCookie cookie = Request.Cookies["infoUsuario"];
                if (cookie["tipoUsuario"].ToLower() == "administrador")
                {
                    //TIENE ACCESO
                    lblUsuario.Text = cookie["Nombre"];
                }
                else
                {
                    // NO TIENE ACCESO
                    Response.Redirect("MenuMedicos.aspx");
                }
            }
            else if (Session["tipoUsuario"] != null)
            {
                if (Session["tipoUsuario"].ToString().ToLower() == "administrador")
                {
                    lblUsuario.Text = Session["Nombre"].ToString();
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
        public void cargarGridView()
        {
            grdPacientes.DataSource = negPac.obtenerTablaPacientes();
            grdPacientes.DataBind();
        }
        public void cargarDdlProvincias()
        {
            NegocioProvincias negProv = new NegocioProvincias();
            DataTable Provincias = negProv.obtenerProvincias();

            ddlProvincia.DataSource = Provincias;
            ddlProvincia.DataTextField = "NombreProvincia_Pr";
            ddlProvincia.DataValueField = "IdProvincia_Pr";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccione provincia --", "0"));
        }
        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue.ToString());
            cargarDdlLocalidades(idProvincia);
        }
        public void cargarDdlLocalidades(int idProvincia)
        {
            ddlLocalidad.Items.Clear();
            NegocioLocalidades negLoc = new NegocioLocalidades();
            DataTable dt = negLoc.obtenerLocalidadesDeProvincia(idProvincia);

            ddlLocalidad.DataSource = dt;
            ddlLocalidad.DataTextField = "NombreLocalidad";
            ddlLocalidad.DataValueField = "IdLocalidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione localidad --", "0"));
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            NegocioPacientes neg = new NegocioPacientes();
            Paciente paciente = cargarDatosPaciente();

            if (neg.AltaPaciente(paciente))
            {
                lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = "Paciente Agregado correctamente";
            }
            else
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "No se pudo agregar el paciente, o el paciente ya existe o ocurrio un error inesperado";
            }
            TablaFiltrada();
            ResetearControles();
        }
        public Paciente cargarDatosPaciente()
        {
            Paciente paciente = new Paciente();
            paciente.Dni = txtDni.Text;
            paciente.Sexo = ddlSexo.SelectedItem.ToString();
            paciente.Correo = txtCorreo.Text;
            paciente.Nombre = txtNombre.Text;
            paciente.Apellido = txtApellido.Text;
            paciente.Nacionalidad = txtNacionalidad.Text;
            paciente.FechaNacimiento = txtFechaNacimiento.Text;
            paciente.Direccion = txtDireccion.Text;
            paciente.Localidad = Convert.ToInt32(ddlLocalidad.SelectedValue.ToString());
            paciente.Provincia = Convert.ToInt32(ddlProvincia.SelectedValue.ToString());
            paciente.Telefono = txtTelefono.Text;
            return paciente;
        }
        public void TablaFiltrada()
        {
            Paciente pac = new Paciente();
            pac.Dni = txtFiltroDNi.Text;
            pac.Nombre = txtFiltroNombre.Text;
            pac.Apellido = txtFiltroApellido.Text;
          
            grdPacientes.DataSource = negPac.obtenerTablaFiltrada(pac);
            grdPacientes.DataBind();
        }
        public void ResetearControles()
        {
            txtDni.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNacionalidad.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDireccion.Text = string.Empty;  
            ddlProvincia.SelectedValue = "0";
            ddlLocalidad.SelectedValue = "0";
            ddlSexo.SelectedIndex = 0;
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            TablaFiltrada();
        }
        protected void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            cargarGridView();
            txtFiltroApellido.Text = string.Empty;
            txtFiltroDNi.Text = string.Empty;
            txtFiltroNombre.Text = string.Empty;
        }
        protected void grdPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPacientes.EditIndex = e.NewEditIndex;
            TablaFiltrada();
        }
        protected void grdPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPacientes.EditIndex = -1;
            TablaFiltrada();
        }
        protected void grdPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Paciente paciente = new Paciente();
            paciente.Dni = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_Eit_Dni")).Text;
            paciente.Sexo = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_Eit_Sexo")).Text;
            paciente.Correo = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_Eit_Correo")).Text;
            paciente.Nombre = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_Eit_Nombre")).Text;
            paciente.Apellido = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_Eit_Apellido")).Text;
            paciente.Nacionalidad = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_Eit_Nacionalidad")).Text;
            paciente.FechaNacimiento = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_Eit_FechaDeNacimiento")).Text;
            paciente.Direccion = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_Eit_Direccion")).Text;
            paciente.Localidad = Convert.ToInt32(((DropDownList)grdPacientes.Rows[e.RowIndex].FindControl("ddl_eit_Localidad")).SelectedValue.ToString());
            paciente.Provincia = Convert.ToInt32(((DropDownList)grdPacientes.Rows[e.RowIndex].FindControl("ddl_eit_Provincia")).SelectedValue.ToString());
            paciente.Telefono = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_Eit_Telefono")).Text;

            negPac.ActualizarPaciente(paciente);
            grdPacientes.EditIndex = -1;
            TablaFiltrada();
        }
        protected void grdPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           if(e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
           {
             DropDownList ddlProvincia = (DropDownList)e.Row.FindControl("ddl_eit_Provincia");
             DropDownList ddlLocalidad = (DropDownList)e.Row.FindControl("ddl_eit_Localidad");
             string  dni = ((TextBox)e.Row.FindControl("txt_Eit_Dni")).Text;

            DataTable dt = new DataTable();
            NegocioProvincias negProv = new NegocioProvincias();
            NegocioLocalidades negLoc = new NegocioLocalidades();
            NegocioPacientes negPac = new NegocioPacientes();

            dt = negProv.obtenerProvincias();
            ddlProvincia.DataSource = dt;
            ddlProvincia.DataTextField = "NombreProvincia_Pr";
            ddlProvincia.DataValueField = "IdProvincia_Pr";
            ddlProvincia.DataBind();
            ddlProvincia.SelectedValue = negPac.obtenerIdProvincia(dni);
    
            dt = negLoc.obtenerLocalidadesDeProvincia(Convert.ToInt32(ddlProvincia.SelectedValue));
            ddlLocalidad.DataSource = dt;
            ddlLocalidad.DataTextField = "NombreLocalidad";
            ddlLocalidad.DataValueField = "IdLocalidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.SelectedValue = negPac.obtenerIdLocalidad(dni);
            }

        }
        protected void grdPacientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["dni"]  = ((Label)grdPacientes.Rows[e.RowIndex].FindControl("lbl_It_Dni")).Text;
            string nombre = ((Label)grdPacientes.Rows[e.RowIndex].FindControl("lbl_it_Nombre")).Text;
            string apellido = ((Label)grdPacientes.Rows[e.RowIndex].FindControl("lbl_it_Apellido")).Text;

            lblMensajeConfirmacion.Text = "SEGURO QUE QUIERE ELIMINAR AL PACIENTE " + nombre + " " + apellido+"?";
            lbSi.Visible = true;
            lbNo.Visible = true;
        }
        protected void lbSi_Click(object sender, EventArgs e)
        {
            string dni = Session["dni"].ToString();
            if (negPac.bajaPaciente(dni))
            {
                lblMensajeBorrar.ForeColor = Color.Green;
                lblMensajeBorrar.Text = "Eliminado Correctamente";
            }
            else
            {
                lblMensajeBorrar.ForeColor = Color.Red;
                lblMensajeBorrar.Text = " No se pudo Eliminar";
            }
            TablaFiltrada();
            lblMensajeConfirmacion.Text = string.Empty;
            lbSi.Visible = false;
            lbNo.Visible = false;
        }
        protected void lbNo_Click(object sender, EventArgs e)
        {
            lblMensajeConfirmacion.Text = string.Empty;
            lbSi.Visible = false;
            lbNo.Visible = false;
        }
        protected void grdPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPacientes.PageIndex = e.NewPageIndex;
            TablaFiltrada();
        }
        protected void ddl_eit_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincias = (DropDownList)sender;
            GridViewRow fila = (GridViewRow)ddlProvincias.NamingContainer;
            DropDownList ddlLocalidades = (DropDownList)fila.FindControl("ddl_eit_Localidad");

            NegocioLocalidades neg = new NegocioLocalidades();
            DataTable localidades = neg.obtenerLocalidadesDeProvincia(Convert.ToInt32(ddlProvincias.SelectedValue));
            ddlLocalidades.DataSource = localidades;
            ddlLocalidades.DataTextField = "NombreLocalidad";
            ddlLocalidades.DataValueField = "IdLocalidad";
            ddlLocalidades.DataBind();
        }
    }
}