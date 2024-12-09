using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAO
{
    public class DaoPacientes
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable obtenerPacientes()
        {  // esto es porque para pasarle un valor al ddl del edit item template solo se le pued eenlacar en selected value 
            string consulta = "SELECT Dni_p,nombre_p,apellido_p,sexo_p,nacionalidad_p,fechadenacimiento_p,dirección_P,correo_p,telefono_p," +
                "NombreProvincia_Pr,nombreLocalidad,IdLocalidad,IdProvincia_Pr FROM Pacientes inner join Provincias on pacientes.IdProvincia_p = Provincias.IdProvincia_Pr " +
                "inner join localidades on pacientes.IdLocalidad_p = Localidades.IdLocalidad WHERE baja_p = 0";
          return  ad.obtenerTabla(consulta,"Pacientes");
        }

        public DataTable obtenerTablaFiltrada(Paciente paciente)
        {
            string consulta = "SELECT Dni_p,nombre_p,apellido_p,sexo_p,nacionalidad_p,fechadenacimiento_p,dirección_P,correo_p,telefono_p," +
                "NombreProvincia_Pr,nombreLocalidad,IdLocalidad,IdProvincia_Pr FROM Pacientes inner join Provincias on pacientes.IdProvincia_p = Provincias.IdProvincia_Pr " +
                "inner join localidades on pacientes.IdLocalidad_p = Localidades.IdLocalidad WHERE Dni_p like '"+paciente.Dni+"%' AND nombre_p like '"+paciente.Nombre+"%' AND " +
                " Apellido_p LIKE '"+paciente.Apellido+"%' AND Baja_P = 0";
            return ad.obtenerTabla(consulta,"TablaFiltradPacientes");
        }

        public void CargarParametros(ref SqlCommand comando,Paciente p)
        {
            SqlParameter par = new SqlParameter();
            par = comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            par.Value = p.Dni;
            par = comando.Parameters.Add("@nombre", SqlDbType.VarChar, 30);
            par.Value = p.Nombre;
            par = comando.Parameters.Add("@apellido", SqlDbType.VarChar, 30);
            par.Value = p.Apellido;
            par = comando.Parameters.Add("@sexo", SqlDbType.VarChar, 20);
            par.Value = p.Sexo;
            par = comando.Parameters.Add("@nacionalidad", SqlDbType.VarChar, 30);
            par.Value = p.Nacionalidad;
            par = comando.Parameters.Add("@fechaNacimiento", SqlDbType.Date);
            par.Value = p.FechaNacimiento;
            par = comando.Parameters.Add("@direccion", SqlDbType.VarChar,30);
            par.Value = p.Direccion;
            par = comando.Parameters.Add("@correo", SqlDbType.VarChar, 50);
            par.Value = p.Correo;
            par = comando.Parameters.Add("@telefono", SqlDbType.VarChar, 50);
            par.Value = p.Telefono;
            par = comando.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            par.Value = p.Localidad;
            par = comando.Parameters.Add("@IdProvincia", SqlDbType.Int);
            par.Value = p.Provincia;

        }
        public void cargarParametrosEliminar(ref SqlCommand cmd, Paciente paciente)
        {
            SqlParameter parametro = new SqlParameter();
            parametro = cmd.Parameters.Add("@dni", SqlDbType.VarChar, 8);
            parametro.Value = paciente.Dni;
        }
        public int actualizarPaciente(Paciente paciente)
        {
            SqlCommand cmd = new SqlCommand();
            CargarParametros(ref cmd, paciente);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "SP_ActualizarPaciente");
        }
        public int AltaPaciente(Paciente paciente)
        {
            SqlCommand cmd = new SqlCommand();
            CargarParametros(ref cmd, paciente);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "SP_AgregarPaciente");
        }
        public int bajaPaciente(Paciente paciente)
        {
            SqlCommand cmd = new SqlCommand();
            cargarParametrosEliminar(ref cmd, paciente);
            return ad.ejecutarProcedimientoAlmacenado(cmd,"SP_BajaPaciente");
        }
        public DataTable obtenerDatosPaciente(string dni)
        {
            string consulta = "SELECT * FROM Pacientes WHERE dni_P = '" + dni + "'";
            return ad.obtenerTabla(consulta, "provYLocPaciente");
        }
        public bool existePaciente(string dni)
        {
            string consulta = "SELECT * FROM Pacientes WHERE dni_P = '" + dni + "'";
           return ad.existe(consulta);
        }
        public DataTable obtenerDniPaciente(string nombre,string apellido)
        {
            string consulta = "SELECT DNI_P FROM PACIENTES WHERE NOMBRE_P = '"+nombre +"' AND APELLIDO_P = '"+apellido+"'";
            return ad.obtenerTabla(consulta,"dni");
        }

    }
}
