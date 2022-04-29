using Microsoft.AspNetCore.Mvc;

namespace CursoAspNetCore.Models
{
    public class Escuela
    {
       
        public string EscuelaId { get; set; }
        public string Nombre { get; set; }
        public int AñoFundacion { get; set; }
        
    }
}