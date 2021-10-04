using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Revifast.Models
{
    public partial class Reserva
    {
        public int ReservaId { get; set; }

        [Display(Name = "Vehiculo")]
        public int VehiculoId { get; set; }

        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "Fecha y hora son datos requeridos")]
        [Display(Name = "Fecha y Hora")]
        //[RegularExpression("{0: MM/dd/yy H:mm tt}")]
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}