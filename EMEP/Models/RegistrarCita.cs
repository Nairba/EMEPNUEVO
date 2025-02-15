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

    public partial class RegistrarCita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegistrarCita()
        {
            this.ListaCita = new HashSet<ListaCita>();
        }

        [Key]
        public int id { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Seleccione el paciente")]
        public string ID_PACIENTE { get; set; }
        [Display(Name = "Consulta")]
        [Required(ErrorMessage = "Seleccione la consulta")]
        public int ID_CONSULTA { get; set; }
        [Display(Name = "Horario")]
        [Required(ErrorMessage = "Seleccione el horario")]
        public int ID_HORARIO { get; set; }

        public string disponible1 { get; set; }
        [Display(Name = "Disponobilidad")]
        [Required(ErrorMessage = "Seleccione el disponibilidad")]
        public int disponible { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe dar una descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Consulta")]
        public virtual Consulta Consulta { get; set; }
        [Display(Name = "Horario")]
        public virtual Horario Horario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaCita> ListaCita { get; set; }
    }
}
