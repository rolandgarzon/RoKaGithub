using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_ciclofacturacion
    {
        [Key]
        [Display(Name = "Ciclo Facturacion")]
        [MaxLength(4)]
        public string idciclofacturacion { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50)]
        [Required]
        public string descripcion { get; set; }

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

        public virtual ICollection<rk_critica> rk_critica { get; set; }
        public virtual ICollection<rk_lectura> rk_lectura { get; set; }
        public virtual ICollection<rk_grupolectura> rk_grupolectura { get; set; }

        public rk_ciclofacturacion()
        {
            this.rk_critica = new HashSet<rk_critica>();
            this.rk_lectura = new HashSet<rk_lectura>();
            this.rk_grupolectura = new HashSet<rk_grupolectura>();
        }

    }
}