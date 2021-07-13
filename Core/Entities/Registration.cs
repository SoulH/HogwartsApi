using Core.Entities;
using Core.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Core
{

    public enum HouseEnum
    {
        Gryffindor = 1,
        Hufflepuff,
        Ravenclaw, 
        Slytherin
    }

    public enum RegistrationStatus
    {
        Pending = 1,
        Approved,
        Rejected,
        Incomplete
    }

    public class Registration : Entity
    {
        [Required(ErrorMessage = "Requerido")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [RegularExpression(@"^([A-Za-z]|ñ|Ñ|á|Á|ú|Ú|é|É)+$", ErrorMessage = "Debe contener sólo letras")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Requerido")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [RegularExpression(@"^([A-Za-z]|ñ|Ñ|á|Á|é|É|í|Í|ó|Ó|ú|Ú)+$", ErrorMessage = "Debe contener sólo letras")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [Range(1, 9999999999, ErrorMessage = "Valor mínimo 1, máximo 10 dígitos")]
        public long Identification { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [Range(8, 99, ErrorMessage = "Edad mínima 8, máximo 2 dígitos")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [RegularExpression(@"^(Gryffindor|Hufflepuff|Ravenclaw|Slytherin)$", ErrorMessage = "Sólo son válidos: Gryffindor, Hufflepuff, Ravenclaw, Slytherin")]
        public string House { get; set; }

        [RegularExpression(@"^(Pending|Approved|Incomplete|Rejected)$", ErrorMessage = "Sólo son válidos: Pending, Approved, Incomplete, Rejected")]
        public string Status { get; set; } = "Pending";

        public DateTime? Processed { get; set; }

        public DateTime? NextRevision { get; set; }
    }
}
