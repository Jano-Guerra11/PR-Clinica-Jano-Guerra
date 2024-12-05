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
using System.Security.Cryptography;
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
                verificarPermisos();
                cargarGridView();
                cargarDDLProvincias();
                cargarDDLEspecialidades();

            }
            visibilidadDeHorarios();
            lblMensajeActualizado.Text = "";


        }
        public void verificarPermisos()
        {
            if (Request.Cookies["infoUsuario"] != null)
            {
                HttpCookie cookie = Request.Cookies["infoUsuario"];
                if (cookie["tipoUsuario"].ToLower() == "administrador")
                {
                    lblUsuario.Text = cookie["Nombre"];

                } else Response.Redirect("MenuMedicos.aspx");
            }
            else if (Session["tipoUsuario"] != null)
            {
                if (Session["tipoUsuario"].ToString().ToLower() == "administrador")
                {
                    lblUsuario.Text = Session["Nombre"].ToString();
                } else Response.Redirect("MenuMedicos.aspx");

            } else Response.Redirect("Login.aspx");
        }
        public void cargarGridView()
        {
            grdMedicos.DataSource = negMed.obtenerTablaMedicos();
            grdMedicos.DataBind();
        }
        public void cargarDDLProvincias()
        {
            NegocioProvincias negPr = new NegocioProvincias();
            DataTable tablaProvincias = negPr.obtenerProvincias(); 
            
            ddlProvincia.DataSource = tablaProvincias;
            ddlProvincia.DataTextField = "NombreProvincia_Pr";
            ddlProvincia.DataValueField = "idProvincia_Pr";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccione provincia --", "0"));             
        }
        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLocalidad.Items.Clear();
            NegocioLocalidades negocioLocalidades = new NegocioLocalidades();
            DataTable localidades = new DataTable();
           localidades = negocioLocalidades.obtenerLocalidadesDeProvincia(Convert.ToInt32(ddlProvincia.SelectedValue.ToString()));
            ddlLocalidad.DataSource = localidades;
            ddlLocalidad.DataTextField = "NombreLocalidad";
            ddlLocalidad.DataValueField = "IdLocalidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0,new ListItem("-- Seleccione Localidad --", "0"));
        }
        public void cargarDDLEspecialidades()
        {
            NegocioEspecialidades negEsp = new NegocioEspecialidades();
            DataTable esp = negEsp.obtenerEspecialidades();
            ddlEspecialidades.DataSource = esp;
            ddlEspecialidades.DataTextField = "NombreEspecialidad_Esp";
            ddlEspecialidades.DataValueField = "IdEspecialidad_Esp";
            ddlEspecialidades.DataBind();
            ddlEspecialidades.Items.Insert(0, new ListItem("-- Seleccione Especialidad --", "0"));
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            NegocioUsuarios negUs = new NegocioUsuarios();
            Medico medico = llenarEntidadMedico();
            Usuarios usuario = llenarEntidadUsuario();

            bool  agregadoMedico = negMed.agregarMedico(medico);
            bool agregadoUsuario = negUs.altaUsuario(usuario);

            agregarJornadaLaboral();

            if(agregadoMedico && agregadoUsuario)
            {
                lblMensaje.Text = "Agregado correctamente";
            } else lblMensaje.Text = "No se pudo agregar";

            cargarTablaFiltrada();
            resetearControles();
        }
        public Medico llenarEntidadMedico()
        {
            Medico medico = new Medico();
            medico.Legajo1 = txtLegajo.Text.Trim();
            medico.Dni = txtDni.Text.Trim();
            medico.Nombre = txtNombre.Text.Trim();
            medico.Apellido = txtApellido.Text.Trim();
            medico.Sexo = ddlSexo.SelectedItem.Text;
            medico.FechaNacimiento = txtFechaNacimiento.Text;
            medico.Nacionalidad = txtNacionalidad.Text.Trim();
            medico.idLocalidad1 = Convert.ToInt32(ddlLocalidad.SelectedValue);
            medico.idProvincia1 = Convert.ToInt32(ddlProvincia.SelectedValue);
            medico.Telefono = txtTelefono.Text.Trim();
            medico.Correo = txtCorreo.Text.Trim();
            medico.Direccion = txtDireccion.Text.Trim();
            medico.idEspecialidad1 = Convert.ToInt32(ddlEspecialidades.SelectedValue);
            return medico;
        }
        public Usuarios llenarEntidadUsuario()
        {
            Usuarios usuario = new Usuarios();
            usuario.Legajo_U1 = txtLegajo.Text.Trim();
            usuario.NombreUsuario_U = txtNombreUsuario.Text.Trim();
            usuario.Contrasena_U1 = txtDni.Text.Trim();
            usuario.Tipo_U1 = "Medico";
            return usuario;
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
            if (negMed.BajaMedico(legajo, Dni))
            {
                lblMensajeEliminar.Text = "Eliminado correctamente";
            }else lblMensajeEliminar.Text = "No se pudo eliminar";
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
               lblLegajoSeleccionado.Text = legajo;
                cargarHorarios(legajo);
                lblMensajeActualizado.Text = "";
            }
        }
        public void cargarHorarios(string legajo)
        {
            grdJornadaLaboral.DataSource = negJl.obtenerJornadaDeMedico(legajo);
            grdJornadaLaboral.DataBind();
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

                dt = negLoc.obtenerTodasLasLocalidades();
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
                ddlEspecialidad.SelectedValue = negMed.obtenerEspecialidadAsignada(legajo);
                
            }
        }
        protected void ddl_eit_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // obtengo el control que dispara el evento
            DropDownList ddlProvincia = (DropDownList)sender;
            // obtengo la fila en la que se encuentra
            GridViewRow row = (GridViewRow)ddlProvincia.NamingContainer;
            DropDownList ddlLocalidad = (DropDownList)row.FindControl("ddl_eit_Localidad");

            NegocioLocalidades negLoc = new NegocioLocalidades();
            DataTable dt = new DataTable();
            dt = negLoc.obtenerLocalidadesDeProvincia(Convert.ToInt32(ddlProvincia.SelectedValue));
            ddlLocalidad.DataSource = dt;
            ddlLocalidad.DataTextField = "NombreLocalidad";
            ddlLocalidad.DataValueField = "IdLocalidad";
            ddlLocalidad.Items.Insert(0, new ListItem("- Seleccione Localidad -", "0"));
            ddlLocalidad.DataBind();
        }
        protected void grdJornadaLaboral_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdJornadaLaboral.EditIndex = e.NewEditIndex;
            string legajo = lblLegajoSeleccionado.Text;
            cargarHorarios(legajo);
        }
        protected void grdJornadaLaboral_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdJornadaLaboral.EditIndex = -1;
            string legajo = lblLegajoSeleccionado.Text;
            cargarHorarios(legajo);
        }
        protected void grdJornadaLaboral_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            JornadaLaboral jl = new JornadaLaboral();
            NegocioJornadaLaboral negJl = new NegocioJornadaLaboral();

            jl.LegajoMedico1 = lblLegajoSeleccionado.Text;
            jl.DiaAtencion1 = ((DropDownList)grdJornadaLaboral.Rows[e.RowIndex].FindControl("ddl_eit_Dias")).SelectedValue.ToString();
            jl.Ingreso1 = ((TextBox)grdJornadaLaboral.Rows[e.RowIndex].FindControl("txt_eit_Ingreso")).Text;
            jl.Egreso = ((TextBox)grdJornadaLaboral.Rows[e.RowIndex].FindControl("txt_eit_Egreso")).Text;

            if (!negJl.ExisteJornada(jl.LegajoMedico1, jl.DiaAtencion1))
            {
               if (negJl.actualizarJornada(jl))
               {
                  lblMensajeActualizado.Text = "Actualizado";
               }
               else { lblMensajeActualizado.Text = " No se pudo actualizar"; }
            }
            else{ lblMensajeActualizado.Text = " Ya existe un registro para ese dia"; }
            grdJornadaLaboral.EditIndex = -1;
            cargarHorarios(jl.LegajoMedico1);
            
        }
        protected void grdJornadaLaboral_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["dia"] = ((Label)grdJornadaLaboral.Rows[e.RowIndex].FindControl("lbl_it_Dia")).Text;
            lblConfirmacionEliminar.Visible = true;
            lblConfirmacionEliminar.Text = "Seguro que desea eliminar el dia " + Session["dia"].ToString() + " ?";
            lbSi2.Visible = true;
            lbNo2.Visible = true;
        }
        protected void lbNo2_Click(object sender, EventArgs e)
        {
            lblConfirmacionEliminar.Visible = false;
            lblConfirmacionEliminar.Text = "";
            lbSi2.Visible = false;
            lbNo2.Visible = false;
        }
        protected void lbSi2_Click(object sender, EventArgs e)
        {
            string legajo = lblLegajoSeleccionado.Text;
            string dia = Session["dia"].ToString();
            if (negJl.bajaJornadaLaboral(legajo, dia))
            {
                lblMensajeActualizado.Text = "Eliminado correctamente";
            }
            lblConfirmacionEliminar.Visible = false;
            lblConfirmacionEliminar.Text = "";
            lbSi2.Visible = false;
            lbNo2.Visible = false;
            cargarHorarios(legajo);
        }
        protected void btnAgregarDia_Click(object sender, EventArgs e)
        {
            string legajo = lblLegajoSeleccionado.Text;
            string dia = ddlAgregarDia.SelectedItem.Text;
            string ingreso = txtAgregarIngreso.Text;
            string egreso = txtAgregarEgreso.Text;

            if (!negJl.ExisteJornada(legajo, dia))
            {
                if (negJl.AltaJornadaLaboral(legajo, dia, ingreso, egreso))
                {
                    lblMensajeActualizado.Text = "Dia agregado correctamente";
                }
                 else lblMensajeActualizado.Text = "No se pudo agregar el dia";
            }
             else lblMensajeActualizado.Text = "Ya existe un registro para ese dia";

            cargarHorarios(legajo);
            ddlAgregarDia.SelectedIndex = 0;
            txtAgregarIngreso.Text = string.Empty;
            txtAgregarEgreso.Text = string.Empty;
        }

        protected void cvLegajo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!negMed.existeMedico(args.Value.ToString()) && args.Value.Length <= 5)
            {
                args.IsValid = true;
                cvLegajo.IsValid = true;
                cvLegajo.Text = "";
            }
            else
            {
                args.IsValid = false;
                cvLegajo.IsValid = false;
                cvLegajo.Text = "Legajo existente";
            }
        }
    }
}