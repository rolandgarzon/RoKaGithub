using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
	public class rk_departamento
	{
        [Key]
        [Display(Name = "Departamento")]
        [MaxLength(3)]
        public string iddepartamento { get; set; }

        [Display(Name = "Nombre Departamento")]
        [MaxLength(50)]
        [Required]
        public string descripcion { get; set; }

        [Display(Name = "Pais")]
        [MaxLength(2)]
        [Required]
        public string idpais { get; set; }

        public virtual rk_pais rk_pais { get; set; }

        public virtual ICollection<rk_municipio> rk_municipio { get; set; }
        public virtual ICollection<rk_usuario> rk_usuario { get; set; }
        public rk_departamento()
        {
            this.rk_municipio = new HashSet<rk_municipio>();
            this.rk_usuario = new HashSet<rk_usuario>();
        }


    }



}