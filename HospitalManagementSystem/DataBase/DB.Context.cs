﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HMSystemEntities : DbContext
    {
        public HMSystemEntities()
            : base("name=HMSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ALLOCATION> ALLOCATION { get; set; }
        public virtual DbSet<CONSULTATION> CONSULTATION { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEE { get; set; }
        public virtual DbSet<JOB> JOB { get; set; }
        public virtual DbSet<PATIENT> PATIENT { get; set; }
        public virtual DbSet<ROL> ROL { get; set; }
        public virtual DbSet<STATUS> STATUS { get; set; }
        public virtual DbSet<USER> USER { get; set; }
    
        public virtual int SP_ADD_EMPLOYEE(string name, string lastName, string motherLastName, string gender, Nullable<System.DateTime> birthDate, Nullable<int> age, string email, string phone, string address, Nullable<int> job)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var motherLastNameParameter = motherLastName != null ?
                new ObjectParameter("MotherLastName", motherLastName) :
                new ObjectParameter("MotherLastName", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("BirthDate", birthDate) :
                new ObjectParameter("BirthDate", typeof(System.DateTime));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var jobParameter = job.HasValue ?
                new ObjectParameter("Job", job) :
                new ObjectParameter("Job", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ADD_EMPLOYEE", nameParameter, lastNameParameter, motherLastNameParameter, genderParameter, birthDateParameter, ageParameter, emailParameter, phoneParameter, addressParameter, jobParameter);
        }
    
        public virtual int SP_DEAD_PATIENT(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_DEAD_PATIENT", idParameter);
        }
    
        public virtual int SP_EMPLOYEE_NOT_AVAILABLE(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_EMPLOYEE_NOT_AVAILABLE", idParameter);
        }
    
        public virtual ObjectResult<SP_LOCATE_PATIENT_Result> SP_LOCATE_PATIENT(Nullable<int> idPatient)
        {
            var idPatientParameter = idPatient.HasValue ?
                new ObjectParameter("IdPatient", idPatient) :
                new ObjectParameter("IdPatient", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_LOCATE_PATIENT_Result>("SP_LOCATE_PATIENT", idPatientParameter);
        }
    
        public virtual ObjectResult<SP_MEDICAL_HISTORY_Result> SP_MEDICAL_HISTORY(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_MEDICAL_HISTORY_Result>("SP_MEDICAL_HISTORY", idParameter);
        }
    
        public virtual int SP_NEW_MEDICAL_CONSULTATION(Nullable<int> allocation, Nullable<int> patient, Nullable<int> doctor, Nullable<System.DateTime> consultationDate, string symptoms, string diagnosis, string treatment)
        {
            var allocationParameter = allocation.HasValue ?
                new ObjectParameter("Allocation", allocation) :
                new ObjectParameter("Allocation", typeof(int));
    
            var patientParameter = patient.HasValue ?
                new ObjectParameter("Patient", patient) :
                new ObjectParameter("Patient", typeof(int));
    
            var doctorParameter = doctor.HasValue ?
                new ObjectParameter("Doctor", doctor) :
                new ObjectParameter("Doctor", typeof(int));
    
            var consultationDateParameter = consultationDate.HasValue ?
                new ObjectParameter("ConsultationDate", consultationDate) :
                new ObjectParameter("ConsultationDate", typeof(System.DateTime));
    
            var symptomsParameter = symptoms != null ?
                new ObjectParameter("Symptoms", symptoms) :
                new ObjectParameter("Symptoms", typeof(string));
    
            var diagnosisParameter = diagnosis != null ?
                new ObjectParameter("Diagnosis", diagnosis) :
                new ObjectParameter("Diagnosis", typeof(string));
    
            var treatmentParameter = treatment != null ?
                new ObjectParameter("Treatment", treatment) :
                new ObjectParameter("Treatment", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_NEW_MEDICAL_CONSULTATION", allocationParameter, patientParameter, doctorParameter, consultationDateParameter, symptomsParameter, diagnosisParameter, treatmentParameter);
        }
    
        public virtual int SP_PATIENT_ASSIGNMENT(Nullable<int> patient, Nullable<int> doctorInCharge, string assgnment, Nullable<System.DateTime> dateOfAssignment)
        {
            var patientParameter = patient.HasValue ?
                new ObjectParameter("Patient", patient) :
                new ObjectParameter("Patient", typeof(int));
    
            var doctorInChargeParameter = doctorInCharge.HasValue ?
                new ObjectParameter("DoctorInCharge", doctorInCharge) :
                new ObjectParameter("DoctorInCharge", typeof(int));
    
            var assgnmentParameter = assgnment != null ?
                new ObjectParameter("Assgnment", assgnment) :
                new ObjectParameter("Assgnment", typeof(string));
    
            var dateOfAssignmentParameter = dateOfAssignment.HasValue ?
                new ObjectParameter("DateOfAssignment", dateOfAssignment) :
                new ObjectParameter("DateOfAssignment", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_PATIENT_ASSIGNMENT", patientParameter, doctorInChargeParameter, assgnmentParameter, dateOfAssignmentParameter);
        }
    
        public virtual int SP_PATIENT_DISCHARGE(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_PATIENT_DISCHARGE", idParameter);
        }
    
        public virtual int SP_REGISTER_PATIENT(string cURP, string name, string lastName, string motherLastName, string gender, Nullable<System.DateTime> birthDate, Nullable<int> age, string phone, string address)
        {
            var cURPParameter = cURP != null ?
                new ObjectParameter("CURP", cURP) :
                new ObjectParameter("CURP", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var motherLastNameParameter = motherLastName != null ?
                new ObjectParameter("MotherLastName", motherLastName) :
                new ObjectParameter("MotherLastName", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("BirthDate", birthDate) :
                new ObjectParameter("BirthDate", typeof(System.DateTime));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_REGISTER_PATIENT", cURPParameter, nameParameter, lastNameParameter, motherLastNameParameter, genderParameter, birthDateParameter, ageParameter, phoneParameter, addressParameter);
        }
    
        public virtual ObjectResult<SP_SEARCH_PATIENT_Result> SP_SEARCH_PATIENT(string data)
        {
            var dataParameter = data != null ?
                new ObjectParameter("Data", data) :
                new ObjectParameter("Data", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SEARCH_PATIENT_Result>("SP_SEARCH_PATIENT", dataParameter);
        }
    
        public virtual int SP_UNEMPLOYED(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UNEMPLOYED", idParameter);
        }
    
        public virtual int SP_UPDATE_EMPLOYEES(Nullable<int> id, string name, string lastName, string motherLastName, string gender, Nullable<System.DateTime> birthDate, Nullable<int> age, string email, string phone, string address, Nullable<int> job, Nullable<int> status)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var motherLastNameParameter = motherLastName != null ?
                new ObjectParameter("MotherLastName", motherLastName) :
                new ObjectParameter("MotherLastName", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("BirthDate", birthDate) :
                new ObjectParameter("BirthDate", typeof(System.DateTime));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var jobParameter = job.HasValue ?
                new ObjectParameter("Job", job) :
                new ObjectParameter("Job", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UPDATE_EMPLOYEES", idParameter, nameParameter, lastNameParameter, motherLastNameParameter, genderParameter, birthDateParameter, ageParameter, emailParameter, phoneParameter, addressParameter, jobParameter, statusParameter);
        }
    
        public virtual int SP_UPDATE_PATIENT(Nullable<int> id, string cURP, string name, string lastName, string motherLastName, string gender, Nullable<System.DateTime> birthDate, Nullable<int> age, string phone, string address, Nullable<int> status)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var cURPParameter = cURP != null ?
                new ObjectParameter("CURP", cURP) :
                new ObjectParameter("CURP", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var motherLastNameParameter = motherLastName != null ?
                new ObjectParameter("MotherLastName", motherLastName) :
                new ObjectParameter("MotherLastName", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("BirthDate", birthDate) :
                new ObjectParameter("BirthDate", typeof(System.DateTime));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UPDATE_PATIENT", idParameter, cURPParameter, nameParameter, lastNameParameter, motherLastNameParameter, genderParameter, birthDateParameter, ageParameter, phoneParameter, addressParameter, statusParameter);
        }
    
        public virtual int SP_ADD_ROL(string rOL)
        {
            var rOLParameter = rOL != null ?
                new ObjectParameter("ROL", rOL) :
                new ObjectParameter("ROL", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ADD_ROL", rOLParameter);
        }
    
        public virtual ObjectResult<SP_LOGIN_Result> SP_LOGIN(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_LOGIN_Result>("SP_LOGIN", emailParameter, passwordParameter);
        }
    }
}