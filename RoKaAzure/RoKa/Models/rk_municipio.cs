using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_municipio
    {

        [Key]
        [Display(Name = "Municipio")]
        [MaxLength(4)]
        public string idmunicipio { get; set; }

        [Display(Name = "Nombre Municipio")]
        [MaxLength(50)]
        [Required]
        public string descripcion { get; set; }

        [Display(Name = "Departamento")]
        [MaxLength(3)]
        [Required]
        public string iddepartamento { get; set; }

        public virtual rk_departamento rk_departamento { get; set; }

        public virtual ICollection<rk_usuario> rk_usuario { get; set; }
        public rk_municipio()
        {
            this.rk_usuario = new HashSet<rk_usuario>();
        }
    }
}