using HospitalAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<NCD> NCDs { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<PatientNCD> PatientNCDs { get; set; }
        public DbSet<PatientAllergy> PatientAllergies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PatientNCD>()
                .HasKey(pn => new { pn.PatientId, pn.NCDId });

            modelBuilder.Entity<PatientNCD>()
                .HasOne(pn => pn.Patient)
                .WithMany(p => p.PatientNCDs)
                .HasForeignKey(pn => pn.PatientId);

            modelBuilder.Entity<PatientNCD>()
                .HasOne(pn => pn.NCD)
                .WithMany(n => n.PatientNCDs)
                .HasForeignKey(pn => pn.NCDId);

            modelBuilder.Entity<PatientAllergy>()
                .HasKey(pa => new { pa.PatientId, pa.AllergyId });

            modelBuilder.Entity<PatientAllergy>()
                .HasOne(pa => pa.Patient)
                .WithMany(p => p.PatientAllergies)
                .HasForeignKey(pa => pa.PatientId);

            modelBuilder.Entity<PatientAllergy>()
                .HasOne(pa => pa.Allergy)
                .WithMany(a => a.PatientAllergies)
                .HasForeignKey(pa => pa.AllergyId);
        }
    }
}
