using BEUEjercicio;
using BEUEjercicio.Transactions;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace PryEjercicio.Controllers
{
    public class AlumnosController : Controller
    {
        //private Entities db = new Entities();
        readonly AlumnoBLL alumnoTBLL = new AlumnoBLL();
        // GET: Alumnos
        public ActionResult Index()
        {
            //List<Alumno> alumnos = AlumnoQBLL.GetAlumnos();
            //return View(db.Alumnoes.ToList());
            return View(AlumnoBLL.List());
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = AlumnoBLL.Get(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idalumno,nombres,apellidos,cedula,fecha_nacimiento,lugar_nacimiento,sexo")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                AlumnoBLL.Create(alumno);
                /*db.Alumnoes.Add(alumno);
                db.SaveChanges();*/
                return RedirectToAction("Index");
            }

            return View(alumno);
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = AlumnoBLL.Get(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idalumno,nombres,apellidos,cedula,fecha_nacimiento,lugar_nacimiento,sexo")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                AlumnoBLL.Update (alumno);
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = AlumnoBLL.Get(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlumnoBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
