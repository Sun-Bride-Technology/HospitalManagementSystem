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
    
    public partial class ALLOCATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALLOCATION()
        {
            this.CONSULTATION = new HashSet<CONSULTATION>();
        }
    
        public int Id { get; set; }
        public int Patient { get; set; }
        public int DoctorInCharge { get; set; }
        public string Assgnment { get; set; }
        public System.DateTime DateOfAssignment { get; set; }
        public Nullable<System.DateTime> DischargeDate { get; set; }
    
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual PATIENT PATIENT1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONSULTATION> CONSULTATION { get; set; }
    }
}
