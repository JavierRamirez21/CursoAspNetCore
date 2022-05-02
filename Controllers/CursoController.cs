using System;
using System.Linq;
using System.Collections.Generic;
using CursoAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoAspNetCore.Controllers
{
    public class CursoController : Controller
    {
        [Route("Curso/Index")]
        [Route("Curso/Index/{Id}")]
        public IActionResult Index(string Id)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                var curso = from cur in _context.Cursos
                            where cur.Id == Id
                            select cur;
                return View(curso.SingleOrDefault());
            }
            else
            {
                return View("MultiCurso", _context.Cursos.ToList());
            }
        }
        public IActionResult MultiCurso()
        {
            /* var listaCurso = new List<Curso> () {
                 new Curso {
                 Nombre = "Javier Ramirez",
                 Id = Guid.NewGuid ().ToString ()
                 },
                 new Curso {
                 Nombre = "Jose Garcia",
                 Id = Guid.NewGuid ().ToString ()
                 },
                 new Curso {
                 Nombre = "Pablo Castillo",
                 Id = Guid.NewGuid ().ToString ()
                 },
                 new Curso {
                 Nombre = "Ana Lopez",
                 Id = Guid.NewGuid ().ToString ()
                 },
                 new Curso {
                 Nombre = "Sandra Jiminez",
                 Id = Guid.NewGuid ().ToString ()
                 }
             };*/
            //var listaCurso =GenerarCursosAlAzar();

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiCurso", _context.Cursos.ToList());
        }

        private List<Curso> GenerarCursosAlAzar()
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaCursos = from n1 in nombre1
                              from n2 in nombre2
                              from a1 in apellido1
                              select new Curso { Nombre = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

            return listaCursos.OrderBy((al) => al.Id).ToList();
        }


        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }
        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            ViewBag.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();

                curso.Id = escuela.Id;
                _context.Cursos.Add(curso);

                _context.SaveChanges();
                ViewBag.MensajeExtra = "Curso Creado";
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
        }

        //ediat cursos
        [HttpGet]
        public IActionResult Update(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.MensajeExtra = "El curso que intenta actualizar no existe";
                return View("MultiCurso", _context.Cursos);
            }
            Curso curso = _context.Cursos.Find(id);
            if (curso == null)
            {
                ViewBag.MensajeExtra = "El curso que intenta actualizar no existe";
                return View("MultiCurso", _context.Cursos);
            }

            return View(curso);
        }

        [HttpPost]
        public IActionResult Update(Curso curso)
        {
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;

                _context.Update(curso);
                _context.SaveChanges();

                ViewBag.MensajeExtra = "Curso Actualizado";
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
        }

        //eliminar cursos
        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.MensajeExtra = "El curso que intenta eliminar no existe";
                return View("MultiCurso", _context.Cursos);
            }
            Curso curso = _context.Cursos.Find(id);
            if (curso == null)
            {
                ViewBag.MensajeExtra = "El curso que intenta eliminar no existe";
                return View("MultiCurso", _context.Cursos);
            }

            return View(curso);
        }

        [HttpPost]
        public IActionResult Delete(Curso curso)
        {
            if (ModelState.IsValid)
            {
                var cursoDelete = _context.Cursos.Find(curso.Id);
                _context.Cursos.Remove(cursoDelete);
                _context.SaveChanges();

                ViewBag.MensajeExtra = string.Format("Curso {0} Eliminado", curso.Nombre);
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
        }
        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}