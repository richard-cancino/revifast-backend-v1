using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Revifast.Models
{
    public partial class Conductor
    {
        public Conductor()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }
        
        public int ConductorId { get; set; }

        public string Usuario { get; set; }

        [Required(ErrorMessage = "Nombres es requerido")]
        [DataType(DataType.Text)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Apellidos es requerido")]
        [DataType(DataType.Text)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "DNI es requerido")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "DNI requiere 8 caracteres")]
        public string Dni { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [Phone, Required(ErrorMessage = "Celular es requerido")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "El celular requiere 9 dígitos")]
        public string Celular { get; set; }

        public virtual ICollection<Vehiculo> Vehiculo { get; set; }

        public bool IsDniValid() => Dni.Length == 8;

        public bool IsPhoneValid()
        {
            var pattern = @"(?:^|\D)(\d{9})(?!\d)";
            var match = Regex.Match(Celular, pattern);
            return match.Success;
        }
    }
}
