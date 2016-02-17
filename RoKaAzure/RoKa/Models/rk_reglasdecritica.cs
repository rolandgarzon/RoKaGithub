using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_reglasdecritica
    {
        [Key]
        [Display(Name = "Reglas Critica")]
        [MaxLength(3)]
        public string idreglascritica { get; set; }

        [Display(Name = "Servicio")]
        [MaxLength(2)]
        [Required]
        public string idservicio { get; set; }

        [Display(Name = "Consumo Inicial")]
        [Range(0,999999)]
        [Required]
        public int consumoinicial { get; set; }

        [Display(Name = "Consumo Final")]
        [Range(0, 999999)]
        [Required]
        public int consumofinal { get; set; }

        [Display(Name = "Porcentaje Arriba")]
        [Range(0, 999999)]
        [Required]
        public int porcentajearriba { get; set; }

        [Display(Name = "Porcentaje Abajo")]
        [Range(0, 999999)]
        [Required]
        public int porcentajeabajo { get; set; }

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
        public virtual rk_servicio rk_servicio { get; set; }


    }
}