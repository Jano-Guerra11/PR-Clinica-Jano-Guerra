using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
                cargarGridView();
                cargarDdlProvincias();

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
            DataTable Provincias = new DataTable();
            Provincias = negProv.obtenerProvincias();
            ListItem itemDefault = new ListItem("-- Seleccione Provincia --", "0");
            ddlProvincia.Items.Add(itemDefault);
            foreach(DataRow dr in Provincias.Rows)
            {
                ListItem item = new ListItem();
                item.Text = dr["NombreProvincia_Pr"].ToString();
                item.Value = dr["IdProvincia_Pr"].ToString();
                ddlProvincia.Items.Add(item);   
               
                
            }
        }
        protected void grdPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPacientes.EditIndex = e.NewEditIndex;
            cargarGridView();
        }

        protected void grdPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPacientes.EditIndex = -1;
            cargarGridView();

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
            cargarGridView();
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
            ListItem defaultItem = new ListItem("-- Seleccione Localidad --","0");
            ddlLocalidad.Items.Insert(0, defaultItem);
            foreach(DataRow dr in dt.Rows)
            {
                ListItem localidad = new ListItem();
                localidad.Text = dr["NombreLocalidad"].ToString();
                localidad.Value = dr["IdLocalidad"].ToString();
                ddlLocalidad.Items.Add(localidad);
                
            }
        }

        protected void grdPacientes_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            grdPacientes.EditIndex = -1;
            cargarGridView();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            NegocioPacientes neg = new NegocioPacientes();
            Paciente paciente = new Paciente();
            paciente.Dni = txtDni.Text;
            paciente.Sexo = ddlSexo.SelectedItem.ToString();
            paciente.Correo = txtCorreo.Text;
            paciente.Nombre = txtNombre.Text;
            paciente.Apellido = txtApellido.Text;
            paciente.Nacionalidad = txtNacionalidad.Text;
            paciente.FechaNacimiento = txtFechaNacimiento.Text;
            paciente.Direccion = txtDireccion.Text;
            paciente.Localidad =  Convert.ToInt32(ddlLocalidad.SelectedValue.ToString());
            paciente.Provincia = Convert.ToInt32(ddlProvincia.SelectedValue.ToString());
            paciente.Telefono = txtTelefono.Text;
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
            cargarGridView();
            ResetearControles();
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

        
        public void TablaFiltrada()
        {
            Paciente pac = new Paciente();
            pac.Dni = txtFiltroDNi.Text;
            pac.Nombre = txtFiltroNombre.Text;
            pac.Apellido = txtFiltroApellido.Text;
          

            grdPacientes.DataSource = negPac.obtenerTablaFiltrada(pac);
            grdPacientes.DataBind();
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

        protected void grdPacientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string dni = ((Label)grdPacientes.Rows[e.RowIndex].FindControl("lbl_It_Dni")).Text;
           if(negPac.bajaPaciente(dni))
            {
                lblMensajeBorrar.ForeColor = Color.Green;
                lblMensajeBorrar.Text = "Eliminado Correctamente";

            }
            else
            {
                lblMensajeBorrar.ForeColor = Color.Red;
                lblMensajeBorrar.Text = " No se pudo Eliminar";

            }
            cargarGridView();
        }
    }
}