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

        
        public bool agregarMedico(string legajo,string dni,string nombre,string apellido, string sexo, string fechaNacimiento, string nacionalidad,
           int idLocalidad,int idProvincia, string telefono,string correo, string direccion, int idEspecialidad)
        {
            Medico medico = new Medico();
            medico.Legajo1 = legajo;
            medico.Dni = dni;
            medico.Nombre = nombre;
            medico.Apellido = apellido;
            medico.Sexo = sexo;
            medico.FechaNacimiento = fechaNacimiento;
            medico.Nacionalidad = nacionalidad;
            medico.idLocalidad1 = idLocalidad;
            medico.idProvincia1 = idProvincia;
            medico.Telefono = telefono;
            medico.Correo = correo;
            medico.Direccion = direccion;
            medico.idEspecialidad1 = idEspecialidad;
            

            if(!dao.existeMedico(medico))
            {
            if(dao.agregarMedico(medico) == 1)
            {
                return true; // se agrego correctamente
            }
            else { return false; } // no existe pero no se pudo agregar

            }
            else { return false;  } // ya existe  
        }
        public int BajaMedico(string legajo,string dni)
        {
            Medico medico = new Medico();
            medico.Legajo1 = legajo;
            medico.Dni = dni;
            if (dao.existeMedico(medico))
            {
                if (dao.BajaMedico(medico) == 1)
                {
                    // eliminado correctamente
                    return 1;
                }
                else {return 0; } // no se pudo eliminar
            }
            else
            {
                // no existe el medico
                return -1;
            }
        }
        public bool actalizarMedico(Medico medico)
        {
            if (dao.existeMedico(medico))
            {
                if (dao.actualizarMedico(medico) == 1)
                {
                    return true;
                }
                else{ return false;}
            }
            else { return false; }
        }
        public DataTable obtenerTablaMedicos()
        {
            DataTable dt = dao.obtenerTablaMedicos();
            if(dt != null)
            {
                return dt;

            }
            else { return null; }
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
            DataTable dt =  dao.obtenerProvinciaAsignada(legajo);
           return dt.Rows[0].ToString();
        }
    }
}
