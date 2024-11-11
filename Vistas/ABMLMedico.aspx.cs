using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ABMLMedico : System.Web.UI.Page
    {
        NegocioMedicos negMed = new NegocioMedicos();
        NegocioJornadaLaboral negJl = new NegocioJornadaLaboral();  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGridView();
                cargarDDLProvincias();
                cargarDDLEspecialidades();

            }
            
        }
        public void cargarDDLEspecialidades()
        {
            NegocioEspecialidades negEsp = new NegocioEspecialidades();
            DataTable esp = negEsp.obtenerEspecialidades();
            foreach(DataRow dr in esp.Rows)
            {
                ListItem item = new ListItem();
                item.Text = dr["NombreEspecialidad_Esp"].ToString();
                item.Value = dr["IdEspecialidad_Esp"].ToString();
                ddlEspecialidades.Items.Add(item);
                ddlFiltroEspecialidad.Items.Add(item);
            }
        }
        public void cargarGridView()
        {
            grdMedicos.DataSource = negMed.obtenerTablaMedicos();
            grdMedicos.DataBind();
            
            
        }
        public void cargarDDLProvincias()
        {
           // ddlProvincia.Items.Clear();
            NegocioProvincias negPr = new NegocioProvincias();
            DataTable tablaProvincias = negPr.obtenerProvincias(); 
            foreach(DataRow dr in tablaProvincias.Rows)
            {
                ListItem item = new ListItem();
                item.Text = dr["NombreProvincia_Pr"].ToString();
                item.Value = dr["idProvincia_Pr"].ToString();
                ddlProvincia.Items.Add(item);
            }
        }
        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
        
         bool agregadoMedico = negMed.agregarMedico(txtLegajo.Text.Trim(), txtDni.Text.Trim(),txtNombre.Text.Trim(),txtApellido.Text.Trim(),ddlSexo.SelectedItem.Text,
                txtFechaNacimiento.Text,txtNacionalidad.Text.Trim(),Convert.ToInt32(ddlLocalidad.SelectedValue), Convert.ToInt32(ddlProvincia.SelectedValue),
                txtTelefono.Text.Trim(),txtCorreo.Text.Trim(),txtDireccion.Text.Trim(),Convert.ToInt32(ddlEspecialidades.SelectedValue));

            agregarJornadaLaboral();

            if(agregadoMedico)
            {
                // se agrego correctamente
                lblMensaje.Text = "Agregado correctamente";
                // vaciar textos
            }
            else
            {
                // no se pudo agregar
                lblMensaje.Text = "No se pudo agregar";
            }
            cargarGridView();
            resetearControles();
        }
        public void resetearControles()
        {
            txtDni.Text = string.Empty; txtNombre.Text = string.Empty; txtApellido.Text = string.Empty;
            txtLegajo.Text = string.Empty; txtFechaNacimiento.Text = string.Empty; txtNacionalidad.Text = string.Empty;
            txtTelefono.Text = string.Empty; txtCorreo.Text = string.Empty;  txtDireccion.Text = string.Empty;
            ddlSexo.SelectedIndex = 0;  ddlProvincia.SelectedIndex = 0; ddlLocalidad.SelectedIndex = 0;
            ddlEspecialidades.SelectedIndex = 0; cbLunes.Checked = false; cbMartes.Checked = false;
            cbMiercoles.Checked = false;  cbJueves.Checked = false; cbViernes.Checked = false;
            cbSabado.Checked = false;  cbDomingo.Checked = false;
        }
       public void agregarJornadaLaboral()
        {
            string legajoMedico = txtLegajo.Text.Trim();
            if (cbLunes.Checked)
            {
                negJl.AltaJornadaLaboral(legajoMedico, lblLunes.Text, txtEntradaLunes.Text, txtSalidaLunes.Text);
            }
            if (cbMartes.Checked)
            {
                negJl.AltaJornadaLaboral(legajoMedico, lblMartes.Text, txtEntradaMartes.Text, txtSalidaMartes.Text);
            }
            if (cbMiercoles.Checked)
            {
                negJl.AltaJornadaLaboral(legajoMedico, lblMiercoles.Text, txtEntradaMiercoles.Text, txtSalidaMiercoles.Text);
            }
            if (cbJueves.Checked)
            {
                negJl.AltaJornadaLaboral(legajoMedico, lblJueves.Text, txtEntradaJueves.Text, txtSalidaJueves.Text);
            }
            if (cbViernes.Checked)
            {
                negJl.AltaJornadaLaboral(legajoMedico, lblViernes.Text, txtEntradaViernes.Text, txtSalidaViernes.Text);
            }
            if (cbSabado.Checked)
            {
                negJl.AltaJornadaLaboral(legajoMedico, lblSabado.Text, txtEntradaSabado.Text, txtSalidaSabado.Text);
            }
            if (cbDomingo.Checked)
            {
                negJl.AltaJornadaLaboral(legajoMedico, lblDomingo.Text, txtEntradaDomingo.Text, txtSalidaDomingo.Text);
            }
        }
        
        protected void cblDias_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLocalidad.Items.Clear();
            NegocioLocalidades negocioLocalidades = new NegocioLocalidades();
            DataTable localidades = new DataTable();
           localidades = negocioLocalidades.obtenerLocalidadesDeProvincia(Convert.ToInt32(ddlProvincia.SelectedValue.ToString()));
            ListItem itemDefault = new ListItem("-- Seleccione Localidad --", "x");
            ddlLocalidad.Items.Add(itemDefault);
            foreach (DataRow dr in localidades.Rows)
            {
                ListItem item = new ListItem();
                item.Text = dr["NombreLocalidad"].ToString();
                item.Value = dr["IdLocalidad"].ToString();
                ddlLocalidad.Items.Add(item);
            }
        }

        private void ActualizarVisibilidadEntradaSalida(CheckBox cb, TextBox txtEntrada, TextBox txtSalida)
        {
            if (cb.Checked)
            {
                txtEntrada.Visible = true;
                txtSalida.Visible = true;
            }
            else
            {
                txtEntrada.Visible = false;
                txtSalida.Visible = false;
            }
        }
        protected void cbLunes_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarVisibilidadEntradaSalida(cbLunes, txtEntradaLunes, txtSalidaLunes);
        }
        protected void cbMartes_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarVisibilidadEntradaSalida(cbMartes,txtEntradaMartes,txtSalidaMartes);
        }
        protected void cbMiercoles_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarVisibilidadEntradaSalida(cbMiercoles, txtEntradaMiercoles, txtSalidaMiercoles);
        }
        protected void cbJueves_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarVisibilidadEntradaSalida(cbJueves, txtEntradaJueves, txtSalidaJueves);
        }
        protected void cbSabado_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarVisibilidadEntradaSalida(cbSabado, txtEntradaSabado, txtSalidaSabado);
        }
        protected void cbViernes_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarVisibilidadEntradaSalida(cbViernes, txtEntradaViernes, txtSalidaViernes);
        }
        protected void cbDomingo_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarVisibilidadEntradaSalida(cbDomingo, txtEntradaDomingo, txtSalidaDomingo);
        }

        protected void btnVerJornada_Click(object sender, EventArgs e)
        {

            if (lblMedicoSeleccionado.Text != "" )
            {
            if(grdJornadaLaboral.Visible == false)
            {
                grdJornadaLaboral.Visible = true;
            }
            else { grdJornadaLaboral.Visible = false; }

          grdJornadaLaboral.DataSource = negJl.obtenerJornadaDeMedico(lblMedicoSeleccionado.Text);
            grdJornadaLaboral.DataBind();

            }
            else
            {
                lblMedicoSeleccionado.Text = "Seleccione un medico primero";
            }

        }

        protected void grdMedicos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           
        }

        protected void grdMedicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string legajo = ((Label)grdMedicos.Rows[e.RowIndex].FindControl("lbl_It_Legajo")).Text;
            string Dni = ((Label)grdMedicos.Rows[e.RowIndex].FindControl("lbl_It_Dni")).Text;
            int x = negMed.BajaMedico(legajo,Dni);
          if ( x == 1)
            {

            lblMensajeEliminar.Text = "Eliminado correctamente";
            }
            else if (x == 0) { lblMensajeEliminar.Text = "No se pudo eliminar";
            }else if(x == -1)
            {
                lblMensajeEliminar.Text = "No existe ese medico";
            }
        }

        protected void grdMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Medico medico = new Medico();
            medico.Dni = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txt_Eit_Dni")).Text;
            medico.Legajo1 = ((Label)grdMedicos.Rows[e.RowIndex].FindControl("lbl_Eit_Legajo")).Text;
            medico.Nombre = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txt_Eit_Nombre")).Text;
            medico.Apellido = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txt_Eit_Apellido")).Text;
            medico.Sexo = ((DropDownList)grdMedicos.Rows[e.RowIndex].FindControl("ddl_Eit_Sexo")).SelectedItem.Text;
            medico.Nacionalidad = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txt_Eit_Nacionalidad")).Text;
            medico.FechaNacimiento = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txt_Eit_FechaDeNacimiento")).Text;
            medico.Direccion = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txt_Eit_Direccion")).Text;
            medico.idLocalidad1 = Convert.ToInt32(((DropDownList)grdMedicos.Rows[e.RowIndex].FindControl("ddl_eit_Localidad")).SelectedValue);
            medico.idProvincia1 = Convert.ToInt32(((DropDownList)grdMedicos.Rows[e.RowIndex].FindControl("ddl_eit_Provincia")).SelectedValue);
            medico.Correo = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txt_Eit_Correo")).Text;
            medico.Telefono = ((TextBox)grdMedicos.Rows[e.RowIndex].FindControl("txt_Eit_Telefono")).Text;
            medico.idEspecialidad1 = Convert.ToInt32(((DropDownList)grdMedicos.Rows[e.RowIndex].FindControl("ddl_Eit_Especialidad")).SelectedValue);

            if (negMed.actalizarMedico(medico))
            {
                // agregado correctamente
                grdMedicos.EditIndex = -1;
                cargarGridView();
            }
        }
        
        protected void grdMedicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdMedicos.EditIndex = e.NewEditIndex;
            cargarGridView();
           
           
        }

        protected void grdMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdMedicos.EditIndex = -1;
            cargarGridView();
        }

        protected void grdMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdMedicos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "verDiasYhorarios")
            {
                int filaSeleccionada = Convert.ToInt32(e.CommandArgument);
                string legajo = ((Label)grdMedicos.Rows[filaSeleccionada].FindControl("lbl_It_Legajo")).Text;
                
                grdJornadaLaboral.DataSource = negJl.obtenerJornadaDeMedico(legajo);
                grdJornadaLaboral.DataBind();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DataTable tablaFiltrada = negMed.tablaFiltrada(txtFiltroLegajo.Text, txtFiltroDni.Text, txtFiltroApellido.Text, ddlFiltroEspecialidad.SelectedItem.ToString());
            grdMedicos.DataSource = tablaFiltrada;
            grdMedicos .DataBind();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            cargarGridView();
            txtFiltroLegajo.Text = string.Empty;
            txtFiltroDni.Text = string.Empty;   
            txtFiltroApellido.Text = string.Empty;
            ddlFiltroEspecialidad.SelectedIndex = 0;
        }
    }
}