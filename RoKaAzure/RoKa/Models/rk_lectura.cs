using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_lectura
    {
        [Key]
        [Display(Name = "Lectura")]
        [Range(0, 999999)]
        public int idlectura { get; set; }

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

        [Display(Name = "Nombre")]
        [MaxLength(150)]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Direccion")]
        [MaxLength(150)]
        [Required]
        public string direccion { get; set; }

        [Display(Name = "Ruta Lectura")]
        [MaxLength(20)]
        [Required]
        public string rutalectura { get; set; }

        [Display(Name = "Lectura Tomada")]
        [Range(0,999999)]
        public int lecturatomada { get; set; }

        [Display(Name = "Observacion Lectura")]
        [MaxLength(3)]
        [Required]
        public string idobservacionlectura { get; set; }

        [Display(Name = "Causa Lectura")]
        [MaxLength(2)]
        [Required]
        public string idcausalectura { get; set; }

        [Display(Name = "Fecha Toma Lectura")]
        [Required]
        public DateTime fechatomalectura { get; set; }

        [Display(Name = "Informacion adicional")]
        [Range(0, 999999)]
        public int informacionadicional { get; set; }

        [Display(Name = "Pasa a Critica")]
        public string pasacritica { get; set; }

        [Display(Name = "Lectura Facturada")]
        [Range(0, 999999)]
        public int lecturafacturada { get; set; }

        [Display(Name = "Observacion Facturada")]
        [MaxLength(3)]
        public string observacionfacturada { get; set; }

        [Display(Name = "Tecnico")]
        [MaxLength(15)]
        public string idtecnico { get; set; }

        [Display(Name = "Lectura Anterior")]
        [Range(0, 999999)]
        [Required]
        public int lecturaanterior { get; set; }

        [Display(Name = "Consumo Facturado")]
        [Range(0, 999999)]
        public int consumofacturado { get; set; }

        [Display(Name = "Consumo Promedio")]
        [Range(0, 999999)]
        [Required]
        public int consumopromedio { get; set; }

        [Display(Name = "Meses Desacomulados")]
        [Range(0, 999999)]
        public int mesesdesacumulados { get; set; }

        [Display(Name = "Usuario")]
        [MaxLength(20)]
        [Required]
        public string idusuario { get; set; }

        [Display(Name = "Obervacion Anterior")]
        [MaxLength(3)]
        [Required]
        public string idobservacionlectant { get; set; }

        [Display(Name = "Fecha Modificacion")]
        public DateTime fechamodificacion { get; set; }

        [Display(Name = "Vigencia")]
        [MaxLength(20)]
        [Required]
        public string idvigencia { get; set; }

        [Display(Name = "Terminal Portatil")]
        [MaxLength(3)]
        public string idterminalportatil { get; set; }

        [Display(Name = "Estado Lectura")]
        [MaxLength(2)]
        [Required]
        public string idestadolectura { get; set; }

        [Display(Name = "Fecha Lectura Tomada")]
        public DateTime fechalecturatomada { get; set; }

        [Display(Name = "Medidor")]
        [MaxLength(20)]
        [Required]
        public string idmedidor { get; set; }

        public virtual rk_pais rk_pais { get; set; }
        public virtual rk_departamento rk_departamento { get; set; }
        public virtual rk_municipio rk_municipio { get; set; }
        public virtual rk_servicio rk_servicio { get; set; }
        public virtual rk_ciclofacturacion rk_ciclofacturacion { get; set; }
        public virtual rk_causalectura rk_causalectura { get; set; }
        public virtual rk_observacioneslectura rk_observacioneslectura { get; set; }
        public virtual rk_tecnico rk_tecnico { get; set; }
        public virtual rk_usuario rk_usuario { get; set; }
        public virtual rk_terminalportatil rk_terminalportatil { get; set; }
        public virtual rk_estadolectura rk_estadolectura { get; set; }

    }
}