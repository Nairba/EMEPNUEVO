//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMEP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paciente_Asociado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente_Asociado()
        {
            this.Paciente_Dueño_Asociado = new HashSet<Paciente_Dueño_Asociado>();
        }
    
        public string correo { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string p_Apellido { get; set; }
        public string s_Apellido { get; set; }
        public string contrasenna { get; set; }
        public string sexo { get; set; }
        public int estado { get; set; }
        public System.DateTime fecha_nacimiento { get; set; }
        public string tipo_sangre { get; set; }
        public string recidencia { get; set; }
        public int telefono { get; set; }
        public int contacto_emergencia { get; set; }
        public string parentesco { get; set; }
        public int ID_TIPO_USUARIO { get; set; }
    
        public virtual Tipo_Usuario Tipo_Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paciente_Dueño_Asociado> Paciente_Dueño_Asociado { get; set; }
    }
}