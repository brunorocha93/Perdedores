using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
namespace Modelo
{
    public class ConexionBD
    {
        public OleDbConnection Conectar()
        {
            //string cadena = "Provider=SQLNCLI11;Data Source=SERVER;Persist Security Info=True;User ID=CedimAdmin;Initial Catalog="+Program.DB+";Pwd=Cedim2016;";
            string cadena = "Provider=SQLNCLI11;Data Source=DESKTOP-O6KUEE9\\CEDIM;Persist Security Info=True;User ID=sa;Initial Catalog=" + "DBCedim2019"+ ";Pwd=123;";
            //string cadena = "Provider=SQLNCLI11;Data Source=RODRIGO-PERSONA\\SERVER;Persist Security Info=True;User ID=sa;Initial Catalog=" + Program.DB + ";Pwd=123;";
            OleDbConnection cone = new OleDbConnection(cadena);
            try
            {
                cone.Open();
                return cone;
            }
            catch (Exception e1)
            {
                return cone;
            }
        }
    }
}
