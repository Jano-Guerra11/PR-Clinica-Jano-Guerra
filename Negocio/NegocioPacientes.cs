using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entidades;
namespace Negocio
{
    public class NegocioPacientes
    {
        DaoPacientes dao = new DaoPacientes();
        public DataTable obtenerTablaPacientes()
        {
           return dao.obtenerPacientes();
        }
        public DataTable obtenerTablaFiltrada(Paciente paciente)
        {
            return dao.obtenerTablaFiltrada(paciente);
        }
        public bool ActualizarPaciente(Paciente pac)
        {
            if (dao.actualizarPaciente(pac) == 1)
            {
                return true;
            }
            else { return false; }
        }
        public bool AltaPaciente(Paciente pac)
        {
            
            if(dao.AltaPaciente(pac) == 1)
            {
                return true;
            }
            else { return false; }
        }
        public bool bajaPaciente(string dni)
        {
            Paciente paciente = new Paciente();
            paciente.Dni = dni;
            if(dao.bajaPaciente(paciente) == 1)
            {
                return true;
            }
            else { return false; }
        }
        public string obtenerIdProvincia(string dni)
        {
            DataTable dt = dao.obtenerProvYLocDePaciente(dni);
            if(dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["IdProvincia_P"].ToString();
            }
            return null;
        }
        public string obtenerIdLocalidad(string dni)
        {
            DataTable dt = dao.obtenerProvYLocDePaciente(dni);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["IdLocalidad_P"].ToString();
            }
            return null;
        }
    }
}
