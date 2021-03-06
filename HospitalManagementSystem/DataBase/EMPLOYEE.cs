//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalManagementSystem.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEE()
        {
            this.ALLOCATION = new HashSet<ALLOCATION>();
            this.CONSULTATION = new HashSet<CONSULTATION>();
            this.USER = new HashSet<USER>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public string Gender { get; set; }
        public System.DateTime BirthDate { get; set; }
        public Nullable<int> Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Job { get; set; }
        public int Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALLOCATION> ALLOCATION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONSULTATION> CONSULTATION { get; set; }
        public virtual STATUS STATUS1 { get; set; }
        public virtual JOB JOB1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER> USER { get; set; }
    }
}
