using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Utiles;
namespace Modelo
{
    public class Usuario : ConexionBD
    {
        Cifrado cif = new Cifrado();
        public int ID_Usuario { get; set; }
        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Area { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Modificar { get; set; }
        public int Bloqueado { get; set; }
        public int ContraseñaNoVence { get; set; }
        public Usuario()
        {

        }

        public int autenticar(string user, string password)
        {
            int uid = 0;
            if (user == null || password == null)
            {
                user = "";
                password = "";
            }
            try
            {
                password = cif.Encriptar(password);
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = Conectar();
                comm.CommandText = "SELECT ID_Usuario FROM Usuario WHERE Login = ? AND Password = ?";
                comm.Parameters.Add("@Log", OleDbType.VarChar).Value = user;
                comm.Parameters.Add("@Pasw", OleDbType.VarChar).Value = password;
                object reader = comm.ExecuteScalar();
                if (reader != null)
                    uid = (int)reader;
                comm.Connection.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            return uid;

        }
        public Usuario(int id, string log, string nombre,string apellido)
        {
            ID_Usuario = id;
            Login = log;
            Nombre = nombre;
            Apellido = apellido;

        }
        public Usuario getusuario(int id)
        {
            Usuario u = null;  
            OleDbConnection cone = Conectar();
            try
            {
               
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = cone;
                comm.CommandText = "SELECT Login,Nombre,Apellido FROM Usuario WHERE ID_Usuario = ?";
                comm.Parameters.Add("@ID_Usuario", OleDbType.Integer).Value = id;
               
                OleDbDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = reader.GetInt32(0);
                    string l = reader.GetString(1);
                    string n = reader.GetString(2);
                    string a = reader.GetString(3);
                    u = new Usuario(i, l, n, a);
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                cone.Close();
            }
            return u;
        }
    }
}
