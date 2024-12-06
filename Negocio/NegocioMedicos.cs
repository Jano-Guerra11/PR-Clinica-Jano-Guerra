using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
namespace Negocio
{
    public class NegocioMedicos
    {
        DaoMedico dao = new DaoMedico();

        
        public bool agregarMedico(Medico medico)
        {
            DaoUsuarios us = new DaoUsuarios();
            Usuarios usuario = new Usuarios();
            usuario.Legajo_U1 = medico.Legajo1;
    
            if(!dao.existeMedico(medico) && !us.existeLegajo(usuario))
            {
                return (dao.agregarMedico(medico) > 0) ? true : false; 
            }
            return false;
        }
        public bool BajaMedico(string legajo,string dni)
        {
            Medico medico = new Medico();
            medico.Legajo1 = legajo;
            medico.Dni = dni;
            if (dao.existeMedico(medico))
            {
                return (dao.BajaMedico(medico) == 1) ? true : false;
            }
            return false; 
        }
        public bool actalizarMedico(Medico medico)
        {
            if (dao.existeMedico(medico))
            {
                return (dao.actualizarMedico(medico) == 1) ? true : false;
            }
            return false;   
        }
        public DataTable obtenerTablaMedicos()
        {
            DataTable dt = dao.obtenerTablaMedicos();
            return (dt != null && dt.Rows.Count > 0) ? dt : null;
        }
        public bool existeMedico(string legajo)
        {
            Medico m = new Medico();
            m.Legajo1 = legajo;
           return dao.existeMedico(m);
        }
        public DataTable tablaFiltrada(string legajo, string dni,string apellido,string especialidad )
        {
            Medico medico = new Medico();
            medico.Legajo1 = legajo;
            medico.Dni = dni;
            medico.Apellido = apellido;
            return dao.obtenerTablaFiltrada(medico, especialidad);
        }
        public DataTable obtenerMedicosDeEspecialidad(int idEspecialidad)
        {
            return dao.obtenerMedicosDeEspecialidad(idEspecialidad);
        }
        public string obtenerProvinciaAsignada(string legajo)
        {
            
            DataTable dt =  dao.obtenerProvLocEsp(legajo);
            if(dt != null && dt.Rows.Count > 0)
            {
              return dt.Rows[0]["idProvincia_Me"].ToString();

            }
            return null;
        }
        public string obtenerLocalidadAsignada(string legajo)
        {
            DataTable dt = dao.obtenerProvLocEsp(legajo);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["idLocalidad_Me"].ToString();

            }
            return null;
        }
        public string obtenerEspecialidadAsignada(string legajo)
        {
            DataTable dt = dao.obtenerProvLocEsp(legajo);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["idEspecialidad"].ToString();

            }
            return null;
        }
    }
}
