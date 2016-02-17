using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_tecnico
    {
        [Key]
        [Display(Name = "Tecnico")]
        [MaxLength(15)]
        public string idtecnico { get; set; }

        [Display(Name = "Identificacion")]
        [MaxLength(20)]
        [Required]
        public string identificacion { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(100)]
        [Required]
        public string descripcion { get; set; }

        [Display(Name = "Telefono")]
        [MaxLength(20)]
        [Required]
        [Phone]
        public string telefono { get; set; }

        [Display(Name = "Activo")]
        [MaxLength(1)]
        [Required]
        public string activo { get; set; }

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

        public virtual ICollection<rk_lectura> rk_lectura { get; set; }

        public rk_tecnico()
        {
            this.rk_lectura = new HashSet<rk_lectura>();
        }

    }
}