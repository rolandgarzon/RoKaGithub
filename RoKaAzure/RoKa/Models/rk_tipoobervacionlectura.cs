using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_tipoobervacionlectura
    {
        [Key]
        [Display(Name = "Tipo Observacion")]
        [MaxLength(2)]
        public string idtipoobservacionlectura { get; set; }

        [Display(Name = "Nombre Tipo Observacion")]
        [MaxLength(50)]
        [Required]
        public string descripcion { get; set; }

        public virtual ICollection<rk_observacioneslectura> rk_observacioneslectura { get; set; }

        public rk_tipoobervacionlectura()
        {
            this.rk_observacioneslectura = new HashSet<rk_observacioneslectura>();
        }

    }
}