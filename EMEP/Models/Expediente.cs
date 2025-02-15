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

    public partial class Expediente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Expediente()
        {
            this.Alcohol = new HashSet<Alcohol>();
            this.Cirugia = new HashSet<Cirugia>();
            this.Enfermedad_Expediente = new HashSet<Enfermedad_Expediente>();
            this.Enfermedad_Familiar = new HashSet<Enfermedad_Familiar>();
            this.Expediente_Alergia = new HashSet<Expediente_Alergia>();
            this.Fumador = new HashSet<Fumador>();
            this.Lista_Actividad_Fisica = new HashSet<Lista_Actividad_Fisica>();
            this.Medicamento = new HashSet<Medicamento>();
            this.Otra_Actividad = new HashSet<Otra_Actividad>();
            this.Otra_Alergia = new HashSet<Otra_Alergia>();
            this.Otra_Enfermedad = new HashSet<Otra_Enfermedad>();
        }

        [Key]
        public int id { get; set; }
        [Display(Name = "Fecha")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "Debe ser tipo Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
          ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }

        public bool estad { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Seleccione el estado")]
        public string estado_String { get; set; }
        public int estado { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Seleccione el Paciente")]
        public string ID_PACIENTE { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alcohol> Alcohol { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cirugia> Cirugia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enfermedad_Expediente> Enfermedad_Expediente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enfermedad_Familiar> Enfermedad_Familiar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expediente_Alergia> Expediente_Alergia { get; set; }
        public virtual Paciente Paciente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fumador> Fumador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lista_Actividad_Fisica> Lista_Actividad_Fisica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medicamento> Medicamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otra_Actividad> Otra_Actividad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otra_Alergia> Otra_Alergia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otra_Enfermedad> Otra_Enfermedad { get; set; }
    }
}

