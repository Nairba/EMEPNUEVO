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

    public partial class Otra_Alergia
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe de escribir el nombre")]
        public string descripcion { get; set; }
        public bool estad { get; set; }
        public int estado { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Seleccione el estado")]
        public string estado_String { get; set; }

        [Display(Name = "Reacci�n")]
        [Required(ErrorMessage = "Debe de escribir la reacci�n")]
        public string reaccion { get; set; }
        [Column(TypeName = "text")]
        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string observaciones { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        [Required(ErrorMessage = "Seleccione imegen")]
        public string img { get; set; }

        [Display(Name = "Expediente")]
        [Required(ErrorMessage = "Seleccione el expediente")]
        public int ID_EXPEDIENTE { get; set; }
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Seleccione la categoria")]
        public int ID_CATEGORIA { get; set; }
        [Display(Name = "Expediente")]
        public virtual Expediente Expediente { get; set; }
    }
}
