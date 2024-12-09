using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    
    public partial class AsignacionDeTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioTurnos negocioTurnos = new NegocioTurnos();
            if (!IsPostBack)
            {
                verificarPermisos();
               cargarEspecialidades();
            }
                grdTurnos.DataSource = negocioTurnos.obtenerTurnos();
                grdTurnos.DataBind();
        }
        public void verificarPermisos()
        {
            if (Request.Cookies["infoUsuario"] != null)
            {
                HttpCookie cookie = Request.Cookies["infoUsuario"];
                if (cookie["tipoUsuario"].ToLower() == "administrador")
                {
                    lblUsuario.Text = cookie["Nombre"];

                }
                else Response.Redirect("MenuMedicos.aspx");
            }
            else if (Session["tipoUsuario"] != null)
            {
                if (Session["tipoUsuario"].ToString().ToLower() == "administrador")
                {
                    lblUsuario.Text = Session["Nombre"].ToString();
                }
                else Response.Redirect("MenuMedicos.aspx");

            }
            else Response.Redirect("Login.aspx");
        }
        public void cargarEspecialidades()
        {
            NegocioEspecialidades negEsp = new NegocioEspecialidades();
            DataTable dt = negEsp.obtenerEspecialidades();
            ddlEspecialidad.DataSource = dt;
            ddlEspecialidad.DataTextField = "NombreEspecialidad_Esp";
            ddlEspecialidad.DataValueField = "IdEspecialidad_Esp";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione especialidad --", "0"));
             
        }
        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMedicos.Items.Clear();
            ListItem itemDefault = new ListItem("-- Seleccione Medico --", "0");
            ddlMedicos.Items.Add(itemDefault);
            NegocioMedicos NegM = new NegocioMedicos();
            DataTable dt = NegM.obtenerMedicosDeEspecialidad(Convert.ToInt32(ddlEspecialidad.SelectedValue.ToString()));
            foreach(DataRow dr in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = dr["nombre_Me"].ToString() +" "+dr["apellido_Me"].ToString();
                item.Value = dr["Legajo_Me"].ToString();
                ddlMedicos.Items.Add(item);
            }
        }
        protected void ddlMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbHorarios.Items.Clear();
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            CultureInfo español = new CultureInfo("es-ES");
            DateTime fechaSeleccionada = Calendar1.SelectedDate.Date;
            string diaSeleccionado = fechaSeleccionada.ToString("dddd", español);
            string fecha = fechaSeleccionada.ToString("yyyy-MM-dd");
            lbHorarios.Items.Clear();
           
            if(ddlMedicos.SelectedItem.Text != "-- Seleccione Medico --")
            {
                cargarHorariosDeDia(diaSeleccionado, fecha);
            } 
        }
        public void cargarHorariosDeDia( string dia,string fecha)
        {
            // verificar que en esa fecha no haya ningun turno asignado
            lbHorarios.Items.Clear();
            NegocioJornadaLaboral negJ = new NegocioJornadaLaboral();
            NegocioTurnos negT = new NegocioTurnos();
            DataRow dr = negJ.diaLaboralMedico(ddlMedicos.SelectedValue.ToString(), dia);

            if (dr != null)
            {
                TimeSpan horaEntrada = TimeSpan.Parse(dr["INGRESO"].ToString());
                TimeSpan horaSalida = TimeSpan.Parse(dr["EGRESO"].ToString());
                TimeSpan unaHora = new TimeSpan(1, 0, 0);

                for (TimeSpan i = horaEntrada; i <= horaSalida; i += unaHora)
                {
                    ListItem item = new ListItem();

                    TimeSpan horaFinalizacion = i + unaHora;
                    bool esta = verificarHorario(fecha, ddlMedicos.SelectedValue.ToString(), i.ToString());
                   if (esta) 
                   {
                      item.Text = i.ToString() + " - " + horaFinalizacion.ToString();
                      item.Value = i.ToString();

                   }
                    else
                    {
                        item.Text = "Horario Ocupado";
                    }
                  lbHorarios.Items.Add(item);
                }
            }
            else
            {
                lblNoDisponible.Text = "No trabaja los " + dia.ToLower();
                
            }
        }
        public bool verificarHorario(string fecha,string legajoMedico,string horario)
        {
            NegocioTurnos negT = new NegocioTurnos();
            DataTable dataTable = negT.obtenerHorariosDeDia(fecha.ToString(), ddlMedicos.SelectedValue.ToString());

            foreach (DataRow dr in dataTable.Rows)
            {
                if (dr["Horario_T"].ToString() == horario)
                {
                    return false;
                }
            }
            return true;
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            NegocioTurnos negocioTurnos = new NegocioTurnos();
            
          bool alta = negocioTurnos.altaTurno(txtDniPaciente.Text,ddlMedicos.SelectedValue.ToString(),Calendar1.SelectedDate.ToString("yyyy-MM-dd"),
              TimeSpan.Parse(lbHorarios.SelectedValue),"indefinido");
            if (alta)
            {
                lblMensaje.Text = "Turno cargado correctamente";
                ddlEspecialidad.SelectedIndex = 0;
                ddlMedicos.SelectedIndex = 0;
                txtDniPaciente.Text = string.Empty;
                lbHorarios.Items.Clear();
                grdTurnos.DataSource = negocioTurnos.obtenerTurnos();
                grdTurnos.DataBind();
            }
            else { lblMensaje.Text = "No se Pudo Cargar el turno"; }
        }

        protected void cvExistePaciente_ServerValidate(object source, ServerValidateEventArgs args)
        {
            NegocioPacientes negocioPacientes = new NegocioPacientes();
            if (negocioPacientes.existePaciente(txtDniPaciente.Text))
            {
                args.IsValid = true;
            }
            else {args.IsValid = false; }
        }

        protected void grdTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (Label)e.Row.FindControl("lbl_it_Fecha");
                DateTime lblFecha = Convert.ToDateTime(((Label)e.Row.FindControl("lbl_it_Fecha")).Text);
               
                lbl.Text = lblFecha.ToString("dd/MM/yyyy");

            }
        }

        protected void grdTurnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblMensajeConfirmacion.Text = "¿SEGURO QUE DESEA ELIMINAR ESTE TURNO?";
            lbSi.Visible = true;
            lbNo.Visible = true;
            Session["CodTurno"] = ((Label)grdTurnos.Rows[e.RowIndex].FindControl("lblCodigo")).Text;
        }
        protected void lbSi_Click(object sender, EventArgs e)
        {
            NegocioTurnos Turn = new NegocioTurnos();
            string codigo = Session["CodTurno"].ToString();
            if (Turn.bajaTurno(codigo))
            {
                lblMensajeConfirmacion.Text = "Turno "+codigo + " eliminado correctamente";
                grdTurnos.DataSource = Turn.obtenerTurnos();
                grdTurnos.DataBind();
            }
            else
            {
                lblMensajeConfirmacion.Text = "No se pudo eliminar el turno " + codigo;
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            NegocioPacientes negPac = new NegocioPacientes();
            lblDni.Text = negPac.obtenerDNI(txtNombre.Text,txtApellido.Text);
        }
    }
}