using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_observacioneslectura
    {
        [Key]
        [Display(Name = "Obervacion")]
        [MaxLength(3)]
        public string idobservacionlectura { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(100)]
        [Required]
        public string descripcion { get; set; }

        [Display(Name = "Tipo Observacion")]
        [MaxLength(2)]
        [Required]
        public string idtipoobservacionlectura { get; set; }

        [Display(Name = "Tipo Cobro")]
        [MaxLength(2)]
        [Required]
        public string idtipocobro { get; set; }

        [Display(Name = "Sale Critica")]
        [MaxLength(1)]
        [Required]
        public string salecritica { get; set; }

        [Display(Name = "Sale Critica Anterior")]
        [MaxLength(1)]
        [Required]
        public string salecriticaanterior { get; set; }

        [Display(Name = "Anomalia")]
        [MaxLength(1)]
        [Required]
        public string anomalia { get; set; }

        [Display(Name = "Activa")]
        [MaxLength(1)]
        [Required]
        public string activa { get; set; }

        [Display(Name = "Servicio")]
        [MaxLength(2)]
        [Required]
        public string idservicio { get; set; }



        public virtual rk_tipocobroobervacion rk_tipocobroobervacion { get; set; }
        public virtual rk_tipoobervacionlectura rk_tipoobervacionlectura { get; set; }
        public virtual rk_servicio rk_servicio { get; set; }

        public virtual ICollection<rk_critica> rk_critica { get; set; }
        public virtual ICollection<rk_lectura> rk_lectura { get; set; }
        public virtual ICollection<rk_grupolectura> rk_grupolectura { get; set; }

        public rk_observacioneslectura()
        {
            this.rk_critica = new HashSet<rk_critica>();
            this.rk_lectura = new HashSet<rk_lectura>();
        }


    }
}