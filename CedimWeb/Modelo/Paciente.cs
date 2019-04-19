using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
namespace Modelo
{
    public class Paciente : ConexionBD
    {
        public int ID_Paciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Email { get; set; }
        public string CI { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Estado { get; set; }
        public Paciente(int id,string nombre,string apellido,string sexo,string Fecha,string email,string ci,string direccion,string telefono,int estado)
        {
            ID_Paciente = id;
            Nombre = nombre;
            Apellido = apellido;
            Sexo = sexo;
            Fecha_Nacimiento = Fecha;
            Email = email;
            CI = ci;
            Direccion = direccion;
            Telefono = telefono;
            Estado = estado;
        }
        public Paciente()
        {

        }
        public List<Paciente> getAllPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();
            try
            {
                OleDbConnection con = Conectar();
                string sql = "SELECT ID_Paciente,Nombre,Apellido,Sexo,Fecha_Nacimiento,Email,CI,Direccion,Telefono,Estado FROM PACIENTES";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    int id = (dr.GetInt32(0));
                    string nombre = dr.GetString(1);
                    string apellido = dr.GetString(2);
                    string sexo = dr.GetString(3);
                    string fecha = dr.GetDateTime(4).ToShortDateString();
                    string email = dr.GetString(5);
                    string ci = dr.GetString(6);
                    string direccion = dr.GetString(7);
                    string telefono = dr.GetString(8);
                    int estado = dr.GetInt32(9);
                    pacientes.Add(new Paciente(id,nombre,apellido ,sexo,fecha,email,ci,direccion,telefono,estado));
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            return pacientes;
        }
        public DataTable CargarPacientes()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT ID_Paciente,Nombre,Apellido,Sexo,Fecha_Nacimiento,Email,CI,Direccion,Telefono,Estado FROM Pacientes";
                comm.CommandType = CommandType.Text;
                DataTable dtPacientes = new DataTable();
                OleDbDataAdapter adap = new OleDbDataAdapter(comm);
                adap.Fill(dtPacientes);
                conn.Close();
                return dtPacientes;
            }
            catch
            {
                return null;
            }
        }
    }
}
