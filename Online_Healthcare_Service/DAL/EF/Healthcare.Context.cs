﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HealthcareEntities1 : DbContext
    {
        public HealthcareEntities1()
            : base("name=HealthcareEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminReport> AdminReports { get; set; }
        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Blood_Bank> Blood_Bank { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Donar_Info> Donar_Info { get; set; }
        public DbSet<Donate_Money> Donate_Money { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientFeedback> PatientFeedbacks { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User_Table> User_Table { get; set; }
    }
}