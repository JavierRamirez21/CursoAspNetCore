using System;
using System.Linq;
using CursoAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoAspNetCore.Controllers
{
    public class EscuelaController:Controller
    {
        
        public IActionResult Index()
        {
            
            ViewBag.CosaDinamica="La Monja";
            var escuela = _context.Escuelas.FirstOrDefault();
            return View(escuela);
        }
        private EscuelaContext _context;
        public EscuelaController(EscuelaContext context)
        {
            _context=context;
        }
    }
}