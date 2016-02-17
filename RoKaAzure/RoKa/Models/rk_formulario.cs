using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
	public class rk_formulario
	{
        [Key]
        [Display(Name = "Formulario")]
        [MaxLength(3)]
        public string idformulario { get; set; }

        [Display(Name = "Nombre Formulario")]
        [MaxLength(50)]
        [Required]
        public string descripcion { get; set; }

    }
}