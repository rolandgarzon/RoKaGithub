using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_critica
    {
        [Key]
        [Display(Name = "Critica")]
        [MaxLength(20)]
        public string idcritica { get; set; }

        [Display(Name = "Servicio")]
        [MaxLength(2)]
        [Required]
        public string idservicio { get; set; }

        [Display(Name = "Ciclo Facturacion")]
        [MaxLength(4)]
        [Required]
        public string idciclofacturacion { get; set; }

        [Display(Name = "Año")]
        [MaxLength(4)]
        [Required]
        public string ano { get; set; }

        [Display(Name = "Mes")]
        [MaxLength(2)]
        [Required]
        public string mes { get; set; }

        [Display(Name = "Suscriptor")]
        [MaxLength(20)]
        [Required]
        public string idsuscriptor { get; set; }

        [Display(Name = "Direccion")]
        [MaxLength(150)]
        [Required]
        public string direccion { get; set; }

        [Display(Name = "Medidor")]
        [MaxLength(20)]
        [Required]
        public string idmedidor { get; set; }

        [Display(Name = "Ruta Lectura")]
        [MaxLength(20)]
        [Required]
        public string rutalectura { get; set; }

        [Display(Name = "Lectura Anterior")]
        [Range(0,999999)]
        [Required]
        public int lecturaanterior { get; set; }

        [Display(Name = "Lectura Actual")]
        [Range(0, 999999)]
        [Required]
        public int lecturaactual { get; set; }

        [Display(Name = "Consumo Anterior")]
        [Range(0, 999999)]
        [Required]
        public int consumoanterior { get; set; }

        [Display(Name = "Consumo Promedio")]
        [Range(0, 999999)]
        [Required]
        public int consumopromedio { get; set; }

        [Display(Name = "Consumo Actual")]
        [Range(0, 999999)]
        [Required]
        public int consumoactual { get; set; }

        [Display(Name = "Obervacion Anterior")]
        [MaxLength(3)]
        [Required]
        public string idobservacionanterior { get; set; }

        [Display(Name = "Obervacion Actual")]
        [MaxLength(3)]
        [Required]
        public string idobservacionactual { get; set; }

        [Display(Name = "Municipio")]
        [MaxLength(4)]
        [Required]
        public string idmunicipio { get; set; }

        [Display(Name = "Departamento")]
        [MaxLength(3)]
        [Required]
        public string iddepartamento { get; set; }

        [Display(Name = "Pais")]
        [MaxLength(2)]
        [Required]
        public string idpais { get; set; }

        [Display(Name = "Usuario")]
        [MaxLength(20)]
        [Required]
        public string idusuario { get; set; }

        [Display(Name = "Genera Orden")]
        [MaxLength(1)]
        [Required]
        public string generaorden { get; set; }

        public virtual rk_ciclofacturacion rk_ciclofacturacion { get; set; }
        public virtual rk_observacioneslectura rk_observacioneslectura { get; set; }
        public virtual rk_servicio rk_servicio { get; set; }
        public virtual rk_municipio rk_municipio { get; set; }
        public virtual rk_departamento rk_departamento { get; set; }
        public virtual rk_pais rk_pais { get; set; }
        public virtual rk_usuario rk_usuario { get; set; }

    }
}