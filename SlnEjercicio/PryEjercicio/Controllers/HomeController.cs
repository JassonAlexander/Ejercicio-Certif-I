using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BEUEjercicio;

namespace PryEjercicio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Alumno a = new Alumno();
            //a.nombres = "Juan Perez";

            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Certificacion I - NRC 7614";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}