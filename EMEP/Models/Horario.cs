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

    public partial class Horario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Horario()
        {
            this.AgendaCita = new HashSet<AgendaCita>();
            this.RegistrarCita = new HashSet<RegistrarCita>();
        }

        [Key]
        public int id { get; set; }

        [Display(Name = "Hora")]
        [Required]
        [DataType(DataType.Time, ErrorMessage = "Debe ser tipo Hora")]
        [DisplayFormat(DataFormatString = "{0:t}",
           ApplyFormatInEditMode = true)]
        [StringLength(12)]
        public string hora { get; set; }
        [Display(Name = "Am/Pm")]
        [DataType(DataType.Time, ErrorMessage = "Seleccione e� formato")]
        public string am_pm { get; set; }

        [Display(Name = "D�a")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "Debe ser tipo d�a")]
        [DisplayFormat(DataFormatString = "{0:ddd}",
           ApplyFormatInEditMode = true)]
        public DateTime dia { get; set; }
        [Display(Name = "Fecha")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "Debe ser tipo Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
           ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Seleccione el estado")]
        public string estado_String { get; set; }
        public int estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgendaCita> AgendaCita { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrarCita> RegistrarCita { get; set; }
    }
}
