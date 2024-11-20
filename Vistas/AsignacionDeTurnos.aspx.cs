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
    // un ddl que aparezcan los dias en los que atiende el medico y al seleccionar uno muestra una tabla con los 
    public partial class AsignacionDeTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioTurnos negocioTurnos = new NegocioTurnos();
            if (!IsPostBack)
            {
            cargarEspecialidades();
            }
                grdTurnos.DataSource = negocioTurnos.obtenerTurnos();
                grdTurnos.DataBind();
        }
        public void cargarEspecialidades()
        {
            NegocioEspecialidades negEsp = new NegocioEspecialidades();
            DataTable dt = negEsp.obtenerEspecialidades();
            foreach(DataRow dr in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = dr["NombreEspecialidad_Esp"].ToString();
                item.Value = dr["IdEspecialidad_Esp"].ToString();
                ddlEspecialidad.Items.Add(item);
            } 
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

        protected void ddlDias_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = Calendar1.SelectedDate.Date;
            string fecha = fechaSeleccionada.ToString("yyyy-MM-dd");
            Debug.WriteLine(fecha);
            lbHorarios.Items.Clear();
           
            if(ddlMedicos.SelectedItem.Text != "-- Seleccione Medico --")
            {
            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Monday)
            {
                cargarHorariosDeDia("LUNES", fecha);
            }
            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Tuesday)
            {
                cargarHorariosDeDia("MARTES", fecha);
            }
            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Wednesday)
            {
                cargarHorariosDeDia("MIERCOLES", fecha);
            }
            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Thursday)
            {
                cargarHorariosDeDia("JUEVES", fecha);
            }
            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Friday)
            {
                cargarHorariosDeDia("VIERNES", fecha);
            }
            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Saturday)
            {
                cargarHorariosDeDia("SABADO", fecha);
            }

            }

            // ahora falta cargar un turno y verificar que solo aparezcan los horarios disponibles(funion bool)
            // tengo que obtener la fecha seleccionada y verificar 
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            
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
                Debug.WriteLine("------------------------------" + dr["Horario_T"].ToString());
                
                if (dr["Horario_T"].ToString() == horario)
                {
                    return false;
                }

            }
            return true;
        }

        protected void ddlHorariosDelDia_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            NegocioTurnos negocioTurnos = new NegocioTurnos();
            
          bool alta = negocioTurnos.altaTurno(txtDniPaciente.Text,ddlMedicos.SelectedValue.ToString(),Calendar1.SelectedDate.ToString("yyyy-MM-dd"),
              Convert.ToDateTime(lbHorarios.SelectedValue),"indefinido");
            if (alta)
            {
                lblMensaje.Text = "Turno cargado correctamente";
                ddlEspecialidad.SelectedIndex = 0;
                ddlMedicos.SelectedIndex = 0;
                txtDniPaciente.Text = string.Empty;
                lbHorarios.Items.Clear();
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
    }
}