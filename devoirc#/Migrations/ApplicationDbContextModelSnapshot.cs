﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using devoirc_.Data;

#nullable disable

namespace devoirc_.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("devoirc_.Models.Abscence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CoursId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateAbsence")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EtudiantId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CoursId");

                    b.HasIndex("EtudiantId");

                    b.ToTable("Abscences");
                });

            modelBuilder.Entity("devoirc_.Models.Classe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Filiere")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("devoirc_.Models.Cours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("EtudiantId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("HeureDebut")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("HeureFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Module")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProfesseurId")
                        .HasColumnType("integer");

                    b.Property<int>("Semestre")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EtudiantId");

                    b.HasIndex("ProfesseurId");

                    b.ToTable("Cours");
                });

            modelBuilder.Entity("devoirc_.Models.DetailCours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClasseId")
                        .HasColumnType("integer");

                    b.Property<int>("CoursId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClasseId");

                    b.HasIndex("CoursId");

                    b.ToTable("DetailCours");
                });

            modelBuilder.Entity("devoirc_.Models.Etudiant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ClasseId")
                        .HasColumnType("integer");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomComplet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClasseId");

                    b.ToTable("Etudiants");
                });

            modelBuilder.Entity("devoirc_.Models.Professeur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Specialite")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Professeurs");
                });

            modelBuilder.Entity("devoirc_.Models.Abscence", b =>
                {
                    b.HasOne("devoirc_.Models.Cours", "Cours")
                        .WithMany()
                        .HasForeignKey("CoursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("devoirc_.Models.Etudiant", "Etudiant")
                        .WithMany("Absences")
                        .HasForeignKey("EtudiantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cours");

                    b.Navigation("Etudiant");
                });

            modelBuilder.Entity("devoirc_.Models.Cours", b =>
                {
                    b.HasOne("devoirc_.Models.Etudiant", null)
                        .WithMany("CoursSuivis")
                        .HasForeignKey("EtudiantId");

                    b.HasOne("devoirc_.Models.Professeur", "Professeur")
                        .WithMany("Cours")
                        .HasForeignKey("ProfesseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professeur");
                });

            modelBuilder.Entity("devoirc_.Models.DetailCours", b =>
                {
                    b.HasOne("devoirc_.Models.Classe", "Classe")
                        .WithMany("DetailCours")
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("devoirc_.Models.Cours", "Cours")
                        .WithMany("DetailCours")
                        .HasForeignKey("CoursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");

                    b.Navigation("Cours");
                });

            modelBuilder.Entity("devoirc_.Models.Etudiant", b =>
                {
                    b.HasOne("devoirc_.Models.Classe", "Classe")
                        .WithMany("Etudiants")
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");
                });

            modelBuilder.Entity("devoirc_.Models.Classe", b =>
                {
                    b.Navigation("DetailCours");

                    b.Navigation("Etudiants");
                });

            modelBuilder.Entity("devoirc_.Models.Cours", b =>
                {
                    b.Navigation("DetailCours");
                });

            modelBuilder.Entity("devoirc_.Models.Etudiant", b =>
                {
                    b.Navigation("Absences");

                    b.Navigation("CoursSuivis");
                });

            modelBuilder.Entity("devoirc_.Models.Professeur", b =>
                {
                    b.Navigation("Cours");
                });
#pragma warning restore 612, 618
        }
    }
}
