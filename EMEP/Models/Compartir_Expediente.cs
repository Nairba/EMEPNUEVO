//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMEP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Compartir_Expediente
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Expediente")]
        [Required(ErrorMessage = "Seleccione el Expediente")]
        public int ID_EXPEDIENTE { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Seleccione el Paciente")]
        public string ID_PACIENTE { get; set; }

        [Display(Name ="Estado")]
        public int estado { get; set; }
        

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Seleccione el estado")]
        public string estado_String { get; set; }

        public string ID_PACIENTE_COMPARTE { get; set; }

        [Display(Name = "Paciente")]
        public virtual Paciente Paciente { get; set; }
    }
}
