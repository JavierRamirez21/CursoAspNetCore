using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CursoAspNetCore.Models
{
    public class Curso:ObjetoEscuelaBase
    {

        [Required(ErrorMessage ="Este campo es requerido")]
        [StringLength(20)]
        public override string Nombre {set;get;}  
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        [Display(Prompt ="Direccion correspondencia",Name ="Address")]
        [Required(ErrorMessage ="La direccion debe ser de longitud mayor a 10")]
        [MinLength(10,ErrorMessage="debe ser una longitud de 10 minmo")]
        public string Dirección { get; set; }

        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
        
        


       
    }
}