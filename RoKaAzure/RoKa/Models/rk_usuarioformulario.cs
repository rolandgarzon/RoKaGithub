using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_usuarioformulario
    {
        [Key]
        [Display(Name = "Usuario")]
        [MaxLength(20)]
        [Column(Order =0)]
        public string idusuario { get; set; }

        [Key]
        [Display(Name = "Formulario")]
        [MaxLength(3)]
        [Column(Order = 1)]
        public string idformulario { get; set; }

        public virtual rk_usuario rk_usuario { get; set; }
        public virtual rk_formulario rk_formulario { get; set; }
    }
}