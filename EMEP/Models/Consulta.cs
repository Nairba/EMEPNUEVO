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

    public partial class Consulta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Consulta()
        {
            this.RegistrarCita = new HashSet<RegistrarCita>();
        }

        [Key]
        public int id { get; set; }
        [Display(Name = "M�dico")]
        [Required(ErrorMessage = "Seleccione el M�dico")]
        public int ID_MEDICO { get; set; }
        [Display(Name = "Consultorio")]
        [Required(ErrorMessage = "Seleccione el Consultorio")]
        public int ID_CONSULTORIO { get; set; }
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:N2}",
            ApplyFormatInEditMode = true)]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Solo n�meros sin decimales")]
        public decimal precio { get; set; }
        [Display(Name = "Especialidad")]
        [Required(ErrorMessage = "Seleccione la especialidad")]
        public int ID_ESPECIALIDAD { get; set; }

        [Display(Name = "Consultorio")]
        public virtual Consultorio Consultorio { get; set; }
        [Display(Name = "Especialidad")]
        public virtual Especialidad Especialidad { get; set; }
        [Display(Name = "M�dico")]
        public virtual Medico Medico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrarCita> RegistrarCita { get; set; }
    }
}
