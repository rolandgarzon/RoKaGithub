using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_servicio
    {
        [Key]
        [Display(Name = "Servicio")]
        [MaxLength(2)]
        public string idservicio { get; set; }

        [Display(Name = "Nombre Servicio")]
        [MaxLength(50)]
        [Required]
        public string descripcion { get; set; }

        public virtual ICollection<rk_causalectura> rk_causalectura { get; set; }
        public virtual ICollection<rk_critica> rk_critica { get; set; }
        public virtual ICollection<rk_grupolectura> rk_grupolectura { get; set; }
        public virtual ICollection<rk_lectura> rk_lectura { get; set; }
        public virtual ICollection<rk_observacioneslectura> rk_observacioneslectura { get; set; }
        public virtual ICollection<rk_reglasdecritica> rk_reglasdecritica { get; set; }
        public virtual ICollection<rk_tipocobroobervacion> rk_tipocobroobervacion { get; set; }

        public rk_servicio()
        {
            this.rk_causalectura = new HashSet<rk_causalectura>();
            this.rk_critica = new HashSet<rk_critica>();
            this.rk_grupolectura = new HashSet<rk_grupolectura>();
            this.rk_lectura = new HashSet<rk_lectura>();
            this.rk_observacioneslectura = new HashSet<rk_observacioneslectura>();
            this.rk_reglasdecritica = new HashSet<rk_reglasdecritica>();
            this.rk_tipocobroobervacion = new HashSet<rk_tipocobroobervacion>();
        }
    }
}