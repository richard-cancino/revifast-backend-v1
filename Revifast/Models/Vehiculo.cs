using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revifast.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int VehiculoId { get; set; }

        public int? ConductorId { get; set; }
        [Required(ErrorMessage = "Placa es requerido")]

        [StringLength(6, MinimumLength = 6,ErrorMessage = "Placa requiere 6 caracteres")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "Modelo es requerido")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Modelo requiere entre 3 y 30 caracteres")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Categoria es requerida")]
        [StringLength(2, MinimumLength = 2,ErrorMessage = "Categoria requiere 2 caracteres")]
        public string Categoria { get; set; }


        public virtual Conductor Conductor { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}