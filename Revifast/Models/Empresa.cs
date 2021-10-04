using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revifast.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ruc es requerido")]
        public string Ruc { get; set; }


        public string Direccion { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}