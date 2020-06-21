using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    public class AlumnoBLL
    {
        //Bussinees Logic Layer
        //Capa Lógica del Negocio

        public static Alumno Get(int? id)
        {
            Entities db = new Entities();
            return db.Alumnoes.Find(id);
        }

        public static void Update(Alumno alumno)
        {
            /*Alumno a_original = db.Alumnoes.Find(aa.idalumno);
            a_original.apellidos = aa.apellidos;
            a_original.nombres = aa.nombres;
            a_original.sexo = aa.sexo;
            a_original.lugar_nacimiento = aa.lugar_nacimiento;
            a_original.fecha_nacimiento=aa.fecha_nacimiento;
            context.Entry(a_original).State = System.Data.Entity.EntityState.Modified;
            //db.Alumnoes.Attach(aa);*/

            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Alumnoes.Attach(alumno);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();//Rollback todo no es transaccional, se elimina
                        throw ex;
                    }
                }
            }

        }

        public static void Create(Alumno a)
        {
            using (Entities db = new Entities())
            {
                using(var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Alumnoes.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();//Rollback todo no es transaccional, se elimina
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Alumno alumno = db.Alumnoes.Find(id);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }

        }

        public static List<Alumno> List()
        {
            Entities db = new Entities(); //Instancia del contexto
            /*List<Alumno> alumnos = db.Alumnoes.ToList();
            List<Alumno> resultado = new List<Alumno>();
            foreach (Alumno a in alumnos)
            {
                if (a.sexo == "M")
                {
                    resultado.Add(a);
                }
            }
            return resultado;*/
            //SQL => SELECT * FROM dbo.Alumno WHERE sexo="M"
            //return db.Alumnoes.Where(x => x.sexo == "M").ToList();

            return db.Alumnoes.ToList();

            //return db.Alumnoes.Where(x=> x.sexo == "M").ToList();//SQL => SELECT * FROM dbo.Alumno WHERE sexo="M"
            //Los mértodos del EntityFramework se denominan Linq, 
            //y la evaluacion de condiciones es lambda
        }

        private static List<Alumno> GetAlumnos(string criterio)
        {
            //Ejemplo: criterio = 'Quin'
            //Psibles resultados => Quintana, Quinteros, Pulloquinga, Velasco, Velasquez...
            Entities db = new Entities();
            return db.Alumnoes.Where(x => x.apellidos.ToLower().Contains(criterio)).ToList();
        }

        private static Alumno GetAlumno(int? id)
        {
            Entities db = new Entities();
            return db.Alumnoes.FirstOrDefault(x => x.idalumno == id);//codigo landa que encuentre el primero por default
        }

        private static Alumno GetAlumno(string cedula)
        {
            Entities db = new Entities();
            return db.Alumnoes.FirstOrDefault(x => x.cedula == cedula);//codigo landa que encuentre el primero por default
        }

    }
}
