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
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Medicamento
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe de escribir el nombre")]
        public string nombre { get; set; }
        [Column(TypeName = "text")]
        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string descripcion { get; set; }

        [Display(Name = "Expediente")]
        [Required(ErrorMessage = "Seleccione el expediente")]
        public int ID_EXPEDIENTE { get; set; }

        [Display(Name = "Expediente")]
        public virtual Expediente Expediente { get; set; }
    }
}
