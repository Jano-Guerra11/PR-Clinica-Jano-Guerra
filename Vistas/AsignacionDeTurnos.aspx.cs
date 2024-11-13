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
            NegocioJornadaLaboral negJ = new NegocioJornadaLaboral();
            DataTable dt = negJ.obtenerJornadaDeMedico(ddlMedicos.SelectedValue.ToString());
            foreach(DataRow dr in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = dr["DIA"].ToString();
                item.Value = dr["DIA"].ToString();
                ddlDias.Items.Add(item);
            }
        }

        protected void ddlDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            NegocioJornadaLaboral negJ = new NegocioJornadaLaboral();
            DataRow dr = negJ.diaLaboralMedico(ddlMedicos.SelectedValue.ToString(),ddlDias.SelectedItem.Text.ToString());
            // un fo que recorra dessde la hora de entrada hasta la hora de salida y cada una hora vaya agregando un horario
            TimeSpan horaEntrada = TimeSpan.Parse(dr["INGRESO"].ToString());
            TimeSpan horaSalida = TimeSpan.Parse(dr["EGRESO"].ToString());

            TimeSpan unaHora = new TimeSpan(1, 0, 0);
            for(TimeSpan i = horaEntrada; i <= horaSalida; i += unaHora)
            {
                ListItem item = new ListItem();
                 
                TimeSpan horaFinalizacion = i + unaHora;
                item.Text = i.ToString() +" - "+horaFinalizacion.ToString();
                ddlHorariosDelDia.Items.Add(item);
            }
            
            lblDias.Text = horaEntrada.ToString();

        }
    }
}