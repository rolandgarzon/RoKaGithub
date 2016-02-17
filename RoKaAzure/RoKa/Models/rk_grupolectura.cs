using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_grupolectura
    {
        [Key]
        [Display(Name = "Grupo Lectura")]
        [MaxLength(3)]
        public string idgrupolectura { get; set; }

        [Display(Name = "Servicio")]
        [MaxLength(2)]
        [Required]
        public string idservicio { get; set; }

        [Display(Name = "Ciclo Facturacion")]
        [MaxLength(4)]
        [Required]
        public string idciclofacturacion { get; set; }

        [Display(Name = "Ruta Inicial")]
        [MaxLength(20)]
        [Required]
        public string rutainicial { get; set; }

        [Display(Name = "Ruta Final")]
        [MaxLength(20)]
        [Required]
        public string rutafinal { get; set; }

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

        public virtual rk_servicio rk_servicio { get; set; }
        public virtual rk_ciclofacturacion rk_ciclofacturacion { get; set; }
        public virtual rk_pais rk_pais { get; set; }
        public virtual rk_departamento rk_departamento { get; set; }
        public virtual rk_municipio rk_municipio { get; set; }
    }
}