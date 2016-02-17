using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_pais
    {
        [Key]
        [Display(Name = "Pais")]
        [MaxLength(2)]
        public string idpais { get; set; }

        [Display(Name = "Nombre Pais")]
        [MaxLength(50)]
        [Required]
        public string descripcion { get; set; }

        public virtual ICollection<rk_departamento> rk_departamento { get; set; }
        public virtual ICollection<rk_usuario> rk_usuario { get; set; }

        public rk_pais()
        {
            this.rk_departamento = new HashSet<rk_departamento>();
            this.rk_usuario = new HashSet<rk_usuario>();
        }

    }
}