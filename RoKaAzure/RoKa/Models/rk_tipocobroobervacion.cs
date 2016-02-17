using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_tipocobroobervacion
    {
        [Key]
        [Display(Name = "Tipo Cobro")]
        [MaxLength(2)]
        public string idtipocobro { get; set; }

        [Display(Name = "Nombre Tipo Cobro")]
        [MaxLength(50)]
        [Required]
        public string descripcion { get; set; }

        [Display(Name = "Servicio")]
        [MaxLength(2)]
        [Required]
        public string idservicio { get; set; }

        public virtual rk_servicio rk_servicio { get; set; }

        public virtual ICollection<rk_observacioneslectura> rk_observacioneslectura { get; set; }

        public rk_tipocobroobervacion()
        {
            this.rk_observacioneslectura = new HashSet<rk_observacioneslectura>();
        }

    }
}