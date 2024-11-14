using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DaoMedico
    {
        AccesoDatos ad = new AccesoDatos();

        
        public void cargarParametrosAgregar(ref SqlCommand comando, Medico medico)
        {
            // ir chequeando que las propiedades de la clase coincidan con el tipo de datos de los campos 
            SqlParameter par = new SqlParameter();
            par = comando.Parameters.Add("@Legajo", SqlDbType.Char, 5);
            par.Value = medico.Legajo1;
            par = comando.Parameters.Add("@dni", SqlDbType.VarChar, 8);
            par.Value = medico.Dni;
            par = comando.Parameters.Add("@nombre", SqlDbType.VarChar, 30);
            par.Value = medico.Nombre;
            par = comando.Parameters.Add("@apellido", SqlDbType.VarChar, 30);
            par.Value = medico.Apellido;
            par = comando.Parameters.Add("@sexo", SqlDbType.VarChar, 30);
            par.Value = medico.Sexo;
            par = comando.Parameters.Add("@nacionalidad", SqlDbType.VarChar, 30);
            par.Value = medico.Nacionalidad;
            par = comando.Parameters.Add("@fechaNacimiento", SqlDbType.Date);
            par.Value = medico.FechaNacimiento;
            par = comando.Parameters.Add("@direccion", SqlDbType.VarChar, 30);
            par.Value = medico.Direccion;
            par = comando.Parameters.Add("@idLocalidad", SqlDbType.Int);
            par.Value = medico.idLocalidad1;
            par = comando.Parameters.Add("@idProvincia", SqlDbType.Int);
            par.Value = medico.idProvincia1;
            par = comando.Parameters.Add("@correo", SqlDbType.VarChar, 30);
            par.Value = medico.Correo;
            par = comando.Parameters.Add("@telefono", SqlDbType.VarChar, 50);
            par.Value = medico.Telefono;
            par = comando.Parameters.Add("@idEspecialidad", SqlDbType.Int);
            par.Value = medico.idEspecialidad1;

            // la contraseña se crea automaticamente es igual al dni y la baja se pone automaticamente en cero
        }
        public void cargarParametrosEliminar(ref SqlCommand cmd, Medico m)
        {
            SqlParameter par = new SqlParameter();
            par = cmd.Parameters.Add("@Legajo", SqlDbType.Char, 5);
            par.Value = m.Legajo1;
        }
        public int agregarMedico(Medico medico)
        {
            SqlCommand cmd = new SqlCommand();
            cargarParametrosAgregar(ref cmd, medico);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "SP_AgregarMedico");
        }

        public int BajaMedico(Medico medico)
        {
            SqlCommand cmd = new SqlCommand();
            cargarParametrosEliminar(ref cmd, medico);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "SP_BajaMedico");

        }
        public bool existeMedico(Medico medico)
        {
            string consulta = "select * from Medicos WHERE Legajo_Me = '"+medico.Legajo1+"' AND DNI_Me = '"+medico.Dni+"'";
           return ad.existe(consulta);
        }

        public DataTable obtenerTablaMedicos()
        {
            string consulta = "select * from medicos inner join Provincias on Medicos.idProvincia_Me = Provincias.IdProvincia_Pr " +
                "inner join Localidades on Medicos.IdLocalidad_Me = Localidades.IdLocalidad inner join Especialidades on Medicos.IdEspecialidad = Especialidades.IdEspecialidad_Esp" +
                " WHERE Baja_Me = 'False' ";
            return ad.obtenerTabla(consulta, "Medicos");
        }
        public DataTable obtenerTablaFiltrada(Medico medico,string especialidad)
        {
            string consulta = "select * from medicos inner join Provincias on Medicos.idProvincia_Me = Provincias.IdProvincia_Pr " +
                "inner join Localidades on Medicos.IdLocalidad_Me = Localidades.IdLocalidad inner join Especialidades on Medicos.IdEspecialidad = Especialidades.IdEspecialidad_Esp" +
                " WHERE Baja_Me = 'False' AND Legajo_Me LIKE '"+medico.Legajo1+"%' AND Dni_Me LIKE '"+medico.Dni+"%' " +
                "AND Apellido_Me LIKE '"+medico.Apellido+"%' AND NombreEspecialidad_Esp LIKE '"+especialidad+"%'";
            return ad.obtenerTabla(consulta, "TablaFiltradaMedicos");
        }
        public int actualizarMedico(Medico medico)
        {
            SqlCommand cmd = new SqlCommand();
            cargarParametrosAgregar(ref cmd, medico);
         return  ad.ejecutarProcedimientoAlmacenado(cmd,"SP_ActualizarMedico");
        }
        public DataTable obtenerMedicosDeEspecialidad(int idEspecialidad)
        {
            string consulta = "SELECT * FROM Medicos WHERE IdEspecialidad = " + idEspecialidad;
            return ad.obtenerTabla(consulta, "MedicosDeEspecialidad");
        }
        public DataTable obtenerProvinciaAsignada(string legajo)
        {
            string consulta = "SELECT IdProvincia_Me FROM Medicos WHERE Legajo_Me = '" + legajo + "'";
           return ad.obtenerTabla(consulta,"provinciaAsingada");
        }
    }
}
