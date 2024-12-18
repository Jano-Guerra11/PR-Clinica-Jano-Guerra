﻿using System;
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
            bool actualizar = false;
            if (dao.actualizarPaciente(pac) > 0)
            {
                actualizar = true;
            }
            return actualizar;
        }
        public bool AltaPaciente(Paciente pac)
        {
            bool alta = false;
            if (!dao.existePaciente(pac.Dni))
            {
              if(dao.AltaPaciente(pac) == 1)
              {
                alta = true;
              }
            }
            return alta;
        }
        public bool bajaPaciente(string dni)
        {
            var paciente = new Paciente { Dni = dni };
            return dao.bajaPaciente(paciente) == 1;
            
        }
        public string obtenerIdProvincia(string dni)
        {
            DataTable dt = dao.obtenerDatosPaciente(dni);
            if(dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["IdProvincia_P"].ToString();
            }
            return null;
        }
        public string obtenerIdLocalidad(string dni)
        {
            DataTable dt = dao.obtenerDatosPaciente(dni);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["IdLocalidad_P"].ToString();
            }
            return null;
        }
        public string obtenerDNI(string nombre,string apellido)
        {
            DataTable dt = dao.obtenerDniPaciente(nombre,apellido);
             if(dt.Rows.Count > 0)
             {
                return dt.Rows[0]["DNI_P"].ToString();
             }
            return null;
        }
        public bool existePaciente(string dni)
        {
           return dao.existePaciente(dni);
        }
        public string pacienteMasFrecuente()
        {
           DataTable dt = dao.pacienteConMasAsistencia();
            return dt.Rows[0]["nombre_p"].ToString() + " " + dt.Rows[0]["apellido_P"].ToString();
        }
        public DataTable obtenerInfoPaciente(string dni)
        {
            return dao.obtenerDatosPaciente(dni);
        }
        
    }
}
