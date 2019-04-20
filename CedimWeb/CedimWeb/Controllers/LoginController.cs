using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;

namespace CedimWeb.Controllers
{
    public class LoginController : Controller
    {
        Modelo.Usuario user = new Usuario();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Autenticar(string usuario, string password)
        {
            int uid = user.autenticar(usuario,password);
            if(uid > 0)
            {
                Utiles.SesionUtil.AddUserToSession(uid.ToString());
                return Redirect("~/Default/Index");
            }
            else//error
            {
                ViewBag.message = "Credendiciales Incorrectas";
                return View("~/Views/Login/Index.cshtml");
               
            }
        }
        public ActionResult LogOut()
        {
            Utiles.SesionUtil.DestroyUserSession();
            return View("~/Views/Login/Index.cshtml");
        }
    }
}