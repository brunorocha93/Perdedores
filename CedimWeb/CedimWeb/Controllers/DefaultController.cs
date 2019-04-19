using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using System.Data;

namespace CedimWeb.Controllers
{
    public class DefaultController : Controller
    {
        private Paciente miPac = new Paciente();
        // GET: Default
        public ActionResult Index()
        {
            List<Paciente> pacientes = miPac.getAllPacientes();
            return View(pacientes);
        }
        public JsonResult GetClientes()
        {
            DataTable dt = miPac.CargarPacientes();
            List<Paciente> listaPaciente = new List<Paciente>();
            foreach (DataRow dr in dt.Rows)
            {
                listaPaciente.Add(new Paciente
                { ID_Paciente = Convert.ToInt32(dr["ID_Paciente"].ToString()),
                    Nombre = (dr["Nombre"]).ToString(),
                    Apellido = dr["Apellido"].ToString(),
                    Sexo = dr["Sexo"].ToString(),
                    Fecha_Nacimiento =dr["Fecha_Nacimiento"].ToString(),
                    Email = dr["Email"].ToString(),
                    CI = dr["CI"].ToString(),
                    Direccion = dr["Fecha_Nacimiento"].ToString(),
                    Telefono = dr["Telefono"].ToString(),
                    Estado = Convert.ToInt32(dr["Estado"].ToString())
                });
            }
            var json = Json(listaPaciente, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
         
        }
    }
}