using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class informes : System.Web.UI.Page
    {
        NegocioMedicos negMed = new NegocioMedicos();
        NegocioEspecialidades negEsp = new NegocioEspecialidades();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                verificarPermisos();
                grdTurnosMedicos.DataSource = negMed.cantTurnosDecadaMedico();
                grdTurnosMedicos.DataBind();
                grdEspecialidades.DataSource = negEsp.cantidadDeTurnosDeCadaEsp();
                grdEspecialidades.DataBind();
            }
            estadisticasTurnosDelMes();
            
                    
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
       public void estadisticasTurnosDelMes()
        {
            NegocioTurnos negTurn = new NegocioTurnos();
            DataTable turnos = negTurn.turnosDelMes();
            if(turnos.Rows.Count == 0)
            {
                lblTurnos.Text = "No hay Turnos Registrados este mes";
                lblTurnosPresentes.Text = "--";
                lblTurnosAusentes.Text = "--";
                lblTurnosIndefinidos.Text = "--";
            }
            else
            {
                float[] porc = negTurn.calcularProcentajes();
                lblTurnos.Text = turnos.Rows.Count.ToString();
                lblTurnosIndefinidos.Text = porc[0].ToString()+"%";
                lblTurnosPresentes.Text = porc[1].ToString() + "%";
                lblTurnosAusentes.Text = porc[2].ToString() + "%";
                int[] cant = negTurn.CantTurnos();
                lblCantidadIndefinidos.Text= cant[0].ToString();
                lblCantidadPresentes.Text = cant[1].ToString();
                lblCantidadAusentes.Text= cant[2].ToString();
            }
        }
    }
}