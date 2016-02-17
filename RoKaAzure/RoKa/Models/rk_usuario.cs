using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_usuario
    {
        [Key]
        [Display(Name = "Usuario")]
        [MaxLength(20)]
        public string idusuario { get; set; }

        [Display(Name = "Nombre Completo")]
        [MaxLength(100)]
        [Required]
        public string nombrecompleto { get; set; }

        [Display(Name = "Activo")]
        public string activo { get; set; }

        [Display(Name = "Correo Electronico")]
        [MaxLength(50)]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Display(Name = "Pais")]
        [MaxLength(2)]
        [Required]
        public string idpais { get; set; }

        [Display(Name = "Departamento")]
        [MaxLength(3)]
        [Required]
        public string iddepartamento { get; set; }

        [Display(Name = "Municipio")]
        [MaxLength(4)]
        [Required]
        public string idmunicipio { get; set; }

        public virtual rk_pais rk_pais { get; set; }
        public virtual rk_departamento rk_departamento { get; set; }
        public virtual rk_municipio rk_municipio { get; set; }


    }
}