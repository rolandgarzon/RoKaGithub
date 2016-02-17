using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_estadolectura
    {
        [Key]
        [Display(Name = "Estado Lectura")]
        [MaxLength(2)]
        public string idestadolectura { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50)]
        [Required]
        public string descripcion { get; set; }

        public virtual ICollection<rk_lectura> rk_lectura { get; set; }

        public rk_estadolectura()
        {
            this.rk_lectura = new HashSet<rk_lectura>();
        }

    }
}