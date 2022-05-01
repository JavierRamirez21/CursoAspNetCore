using System;
using System.Linq;
using System.Collections.Generic;
using CursoAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoAspNetCore.Controllers
{
    public class AlumnoController:Controller
    {
        public IActionResult Index()
        {
            return View(_context.Alumno.FirstOrDefault());
        }
        public IActionResult MultiAlumno()
        {
           /* var listaAlumno = new List<Alumno> () {
                new Alumno {
                Nombre = "Javier Ramirez",
                Id = Guid.NewGuid ().ToString ()
                },
                new Alumno {
                Nombre = "Jose Garcia",
                Id = Guid.NewGuid ().ToString ()
                },
                new Alumno {
                Nombre = "Pablo Castillo",
                Id = Guid.NewGuid ().ToString ()
                },
                new Alumno {
                Nombre = "Ana Lopez",
                Id = Guid.NewGuid ().ToString ()
                },
                new Alumno {
                Nombre = "Sandra Jiminez",
                Id = Guid.NewGuid ().ToString ()
                }
            };*/
            //var listaAlumno =GenerarAlumnosAlAzar();

            ViewBag.CosaDinamica="La Monja";
            ViewBag.Fecha=DateTime.Now;
            return View("MultiAlumno",_context.Alumno.ToList());
        }

        private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

            return listaAlumnos.OrderBy((al) => al.Id).ToList();
        }

        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context=context;
        }
    }
}