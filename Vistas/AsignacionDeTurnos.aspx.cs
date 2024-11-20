using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
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
            cargarEspecialidades();
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
           
        }

        protected void ddlDias_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = Calendar1.SelectedDate;
            lbHorarios.Items.Clear();
            if(ddlMedicos.SelectedItem.Text != "-- Seleccione Medico --")
            {
            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Monday)
            {
                cargarHorariosDeDia("LUNES",fechaSeleccionada);
            }
            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Tuesday)
            {
                cargarHorariosDeDia("MARTES", fechaSeleccionada);
            }
            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Wednesday)
            {
                cargarHorariosDeDia("MIERCOLES", fechaSeleccionada);
            }
            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Thursday)
            {
                cargarHorariosDeDia("JUEVES", fechaSeleccionada);
            }
            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Friday)
            {
                cargarHorariosDeDia("VIERNES", fechaSeleccionada);
            }
            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Saturday)
            {
                cargarHorariosDeDia("SABADO", fechaSeleccionada);
            }

            }

            // ahora falta cargar un turno y verificar que solo aparezcan los horarios disponibles(funion bool)
            // tengo que obtener la fecha seleccionada y verificar 
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            
        }

        public void cargarHorariosDeDia( string dia,DateTime fecha)
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

                if(verificarHorario(fecha.ToString(), ddlMedicos.SelectedValue.ToString(), item.Text)) 
                {
                item.Text = i.ToString() + " - " + horaFinalizacion.ToString();

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
                lbHorarios.Items.Add(new ListItem("No trabaja los "+dia.ToLower(), "0"));
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

        protected void ddlHorariosDelDia_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
    }
}