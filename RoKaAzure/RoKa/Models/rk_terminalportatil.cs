using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class rk_terminalportatil
    {
        [Key]
        [Display(Name = "Terminal Portatil")]
        [MaxLength(3)]
        public string idterminalportatil { get; set; }

        [Display(Name = "Serie")]
        [MaxLength(100)]
        [Required]
        public string serie { get; set; }

        [Display(Name = "Marca")]
        [MaxLength(50)]
        [Required]
        public string marca { get; set; }

        [Display(Name = "Modelo")]
        [MaxLength(50)]
        [Required]
        public string modelo { get; set; }

        [Display(Name = "Activa")]
        [MaxLength(1)]
        [Required]
        public string activa { get; set; }

        [Display(Name = "Numero Celular")]
        [MaxLength(20)]
        [Phone]
        [Required]
        public string numerocelular { get; set; }

        [Display(Name = "Imei")]
        [MaxLength(50)]
        [Required]
        public string imei { get; set; }

        public virtual ICollection<rk_lectura> rk_lectura { get; set; }

        public rk_terminalportatil()
        {
            this.rk_lectura = new HashSet<rk_lectura>();
            
        }
    }
}