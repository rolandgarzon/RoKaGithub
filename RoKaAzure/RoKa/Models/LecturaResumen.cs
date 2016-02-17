using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
	public class LecturaResumen
	{
        [Display(Name = "Terminal Portatil")]
        public string terminalportatil { get; set;}
        [Display(Name = "Ciclo de Facturacion")]
        public string ciclo { get; set; }
        [Display(Name = "Año")]
        public string ano { get; set; }
        [Display(Name = "Mes")]
        public string mes { get; set; }
        [Display(Name = "Asignadas")]
        public int asignadas { get; set; }
        [Display(Name = "Tomadas")]
        public int tomadas { get; set; }
        [Display(Name = "Faltantes")]
        public int faltantes { get; set; }
        [Display(Name = "Porcentaje")]
        public int porcentaje { get; set; }
    }
}