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
    
    public partial class SP_MEDICAL_HISTORY_Result
    {
        public int Id { get; set; }
        public int Allocation { get; set; }
        public int Patient { get; set; }
        public int Doctor { get; set; }
        public System.DateTime ConsultationDate { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
    }
}
