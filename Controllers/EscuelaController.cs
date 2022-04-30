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
            escuela.AñoDeCreación=2005;
            escuela.Nombre="Platzi School";
            escuela.UniqueId=Guid.NewGuid().ToString();
            escuela.Ciudad="San Salvador";
            escuela.Pais="El Salvador";
            escuela.TipoEscuela=TiposEscuela.Secundaria;
            escuela.Dirección="Av. Siempre Peligrosa";

            ViewBag.CosaDinamica="La Monja";
            return View(escuela);
        }
    }
}