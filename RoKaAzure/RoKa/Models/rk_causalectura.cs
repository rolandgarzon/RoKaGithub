using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_causalectura
    {
        [Key]
        [Display(Name = "Causa Lectura")]
        [MaxLength(2)]
        public string idcausalectura { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50)]
        [Required]
        public string descripcion { get; set; }

        [Display(Name = "Servicio")]
        [MaxLength(2)]
        [Required]
        public string idservicio { get; set; }

        public virtual rk_servicio rk_servicio { get; set; }

        public virtual ICollection<rk_lectura> rk_lectura { get; set; }

        public rk_causalectura()
        {
            this.rk_lectura = new HashSet<rk_lectura>();
        }

    }
}