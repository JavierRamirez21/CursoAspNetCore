using System;
using System.Linq;
using System.Collections.Generic;
using CursoAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoAspNetCore.Controllers
{
    public class AsignaturaController:Controller
    {
        public IActionResult Index()
        {
            return View(_context.Asignaturas.FirstOrDefault());
        }
        public IActionResult MultiAsignatura()
        {
          
            
            ViewBag.CosaDinamica="La Monja";
            ViewBag.Fecha=DateTime.Now;
            return View("MultiAsignatura",_context.Asignaturas.ToList());
        }

        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context=context;
        }
    }
}