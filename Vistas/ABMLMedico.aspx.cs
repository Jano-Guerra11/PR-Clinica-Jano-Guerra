using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
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
            visibilidadDeHorarios();
            
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
            cargarTablaFiltrada();
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
            string legajoDelMedico = txtLegajo.Text.Trim();
            List<JornadaLaboral> jornadaMedico = new List<JornadaLaboral>();
            string[] dias = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
            for(int i = 0;i < dias.Length; i++)
            {
                CheckBox cbDia = (CheckBox)FindControl($"cb{dias[i]}");
                TextBox txtHorarioEntrada = (TextBox)FindControl($"txtEntrada{dias[i]}");
                TextBox txtHorarioSalida = (TextBox)FindControl($"txtSalida{dias[i]}");

               if (cbDia.Checked)
               {
                  negJl.AltaJornadaLaboral(legajoDelMedico, dias[i], txtHorarioEntrada.Text, txtHorarioSalida.Text);
               }
            }
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

        public void visibilidadDeHorarios()
        {
            string[] diasSemanales = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
            for (int i = 0; i < diasSemanales.Length; i++)
            {
                CheckBox cb = (CheckBox)FindControl($"cb{diasSemanales[i]}");
                TextBox entrada = (TextBox)FindControl($"txtEntrada{diasSemanales[i]}");
                TextBox salida = (TextBox)FindControl($"txtSalida{diasSemanales[i]}");
                if (cb.Checked)
                {

                    entrada.Visible = true;
                    salida.Visible = true;
                }
                else
                {
                    entrada.Visible = false;
                    salida.Visible = false;
                }
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
 
        protected void grdMedicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string legajo = ((Label)grdMedicos.Rows[e.RowIndex].FindControl("lbl_It_Legajo")).Text;
            string Dni = ((Label)grdMedicos.Rows[e.RowIndex].FindControl("lbl_It_Dni")).Text;

            Session["legajo"] = legajo;
            Session["dni"] = Dni;

            lblMensajeConfirmacion.Visible = true;
            lblMensajeConfirmacion.Text = "Seguro que desea eliminar el medico de legajo " + legajo +" ?";
            lbSi.Visible = true;
            lbNo.Visible = true;
       

        }

        protected void lbSi_Click(object sender, EventArgs e)
        {
            string legajo = Session["legajo"].ToString();
            string dni = Session["dni"].ToString();
           BajaMedico(legajo,dni);
            lblMensajeConfirmacion.Visible = false;
            lblMensajeConfirmacion.Text = "";
            lbSi.Visible = false;
            lbNo.Visible = false;
        }
        protected void lbNo_Click(object sender, EventArgs e)
        {
            lblMensajeConfirmacion.Visible = false;
            lblMensajeConfirmacion.Text = "";
            lbSi.Visible = false;
            lbNo.Visible = false;
        }
        public void BajaMedico(string legajo,string Dni)
        {
            int x = negMed.BajaMedico(legajo, Dni);
            if (x == 1)
            {

                lblMensajeEliminar.Text = "Eliminado correctamente";
            }
            else if (x == 0)
            {
                lblMensajeEliminar.Text = "No se pudo eliminar";
            }
            else if (x == -1)
            {
                lblMensajeEliminar.Text = "No existe ese medico";
            }
            cargarTablaFiltrada();
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
                cargarTablaFiltrada();
            }
        }
        
        protected void grdMedicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdMedicos.EditIndex = e.NewEditIndex;
            cargarTablaFiltrada();
            

        }

        protected void grdMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdMedicos.EditIndex = -1;
            cargarTablaFiltrada(); 
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
            cargarTablaFiltrada();
        }

        public void cargarTablaFiltrada()
        {
            DataTable tablaFiltrada = negMed.tablaFiltrada(txtFiltroLegajo.Text, txtFiltroDni.Text, txtFiltroApellido.Text, ddlFiltroEspecialidad.SelectedItem.ToString());
            grdMedicos.DataSource = tablaFiltrada;
            grdMedicos.DataBind();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtFiltroLegajo.Text = string.Empty;
            txtFiltroDni.Text = string.Empty;   
            txtFiltroApellido.Text = string.Empty;
            ddlFiltroEspecialidad.SelectedIndex = 0;
            cargarTablaFiltrada();
        }

        protected void grdMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMedicos.PageIndex = e.NewPageIndex;
            cargarTablaFiltrada();

        }

        protected void grdMedicos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // si el tipo de la fila que se esta procesando es de tipo Datarow && si el estado de la fila esta en edit 
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
            {
                DropDownList ddlProvincia = (DropDownList)e.Row.FindControl("ddl_eit_Provincia");
                DropDownList ddlLocalidad = (DropDownList)e.Row.FindControl("ddl_eit_Localidad");
                DropDownList ddlEspecialidad = (DropDownList)e.Row.FindControl("ddl_Eit_Especialidad");
                string legajo = ((Label)e.Row.FindControl("lbl_Eit_Legajo")).Text;
                NegocioProvincias negProv = new NegocioProvincias();
                NegocioLocalidades negLoc = new NegocioLocalidades();
                NegocioEspecialidades negEsp = new NegocioEspecialidades();
                DataTable dt = new DataTable();

                dt = negProv.obtenerProvincias();
                ddlProvincia.DataSource = dt;
                ddlProvincia.DataTextField = "NombreProvincia_Pr";
                ddlProvincia.DataValueField = "IdProvincia_Pr";
               
                ddlProvincia.DataBind();
                ddlProvincia.SelectedValue = negMed.obtenerProvinciaAsignada(legajo);

                
                dt = negLoc.obtenerLocalidadesDeProvincia(Convert.ToInt32(ddlProvincia.SelectedValue));
                ddlLocalidad.DataSource = dt;
                ddlLocalidad.DataTextField = "NombreLocalidad";
                ddlLocalidad.DataValueField = "IdLocalidad";
                ddlLocalidad.DataBind();
                ddlLocalidad.SelectedValue = negMed.obtenerLocalidadAsignada(legajo);
               

                dt = negEsp.obtenerEspecialidades();
                ddlEspecialidad.DataSource = dt;
                ddlEspecialidad.DataTextField = "NombreEspecialidad_Esp";
                ddlEspecialidad.DataValueField = "IdEspecialidad_Esp";
                ddlEspecialidad.DataBind();
                
            }
        }

        protected void ddl_eit_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincia = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlProvincia.NamingContainer;
            DropDownList ddlLocalidades = (DropDownList)row.FindControl("ddl_eit_Localidad");

            NegocioLocalidades negLoc = new NegocioLocalidades();
            DataTable dt = new DataTable();
            dt = negLoc.obtenerLocalidadesDeProvincia(Convert.ToInt32(ddlProvincia.SelectedValue));
            ddlLocalidad.DataSource = dt;
            ddlLocalidad.DataTextField = "NombreLocalidad";
            ddlLocalidad.DataValueField = "IdLocalidad";
            ddlLocalidad.Items.Insert(0, new ListItem("- Seleccione Localidad -", "0"));
            ddlLocalidad.DataBind();


        }
    }
}