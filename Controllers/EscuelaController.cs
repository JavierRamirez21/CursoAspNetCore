using System;
using CursoAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoAspNetCore.Controllers
{
    public class EscuelaController:Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.AñoFundacion=2005;
            escuela.Nombre="Platzi School";
            escuela.EscuelaId=Guid.NewGuid().ToString();
            
            ViewBag.CosaDinamica="La Monja";
            return View(escuela);
        }
    }
}