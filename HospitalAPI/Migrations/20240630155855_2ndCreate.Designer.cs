﻿// <auto-generated />
using HospitalAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240630155855_2ndCreate")]
    partial class _2ndCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HospitalAPI.Entities.Allergy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("HospitalAPI.Entities.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("HospitalAPI.Entities.NCD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("NCDs");
                });

            modelBuilder.Entity("HospitalAPI.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DiseaseId")
                        .HasColumnType("integer");

                    b.Property<int>("Epilepsy")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalAPI.Entities.PatientAllergy", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<int>("AllergyId")
                        .HasColumnType("integer");

                    b.HasKey("PatientId", "AllergyId");

                    b.HasIndex("AllergyId");

                    b.ToTable("PatientAllergies");
                });

            modelBuilder.Entity("HospitalAPI.Entities.PatientNCD", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<int>("NCDId")
                        .HasColumnType("integer");

                    b.HasKey("PatientId", "NCDId");

                    b.HasIndex("NCDId");

                    b.ToTable("PatientNCDs");
                });

            modelBuilder.Entity("HospitalAPI.Entities.Patient", b =>
                {
                    b.HasOne("HospitalAPI.Entities.Disease", "Disease")
                        .WithMany("Patients")
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disease");
                });

            modelBuilder.Entity("HospitalAPI.Entities.PatientAllergy", b =>
                {
                    b.HasOne("HospitalAPI.Entities.Allergy", "Allergy")
                        .WithMany("PatientAllergies")
                        .HasForeignKey("AllergyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalAPI.Entities.Patient", "Patient")
                        .WithMany("PatientAllergies")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergy");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalAPI.Entities.PatientNCD", b =>
                {
                    b.HasOne("HospitalAPI.Entities.NCD", "NCD")
                        .WithMany("PatientNCDs")
                        .HasForeignKey("NCDId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalAPI.Entities.Patient", "Patient")
                        .WithMany("PatientNCDs")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NCD");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalAPI.Entities.Allergy", b =>
                {
                    b.Navigation("PatientAllergies");
                });

            modelBuilder.Entity("HospitalAPI.Entities.Disease", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("HospitalAPI.Entities.NCD", b =>
                {
                    b.Navigation("PatientNCDs");
                });

            modelBuilder.Entity("HospitalAPI.Entities.Patient", b =>
                {
                    b.Navigation("PatientAllergies");

                    b.Navigation("PatientNCDs");
                });
#pragma warning restore 612, 618
        }
    }
}
