using Microsoft.EntityFrameworkCore;
using devoirc_.Models;

namespace devoirc_.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Etudiant> Etudiants { get; set; } = default!;
        public DbSet<Professeur> Professeurs { get; set; } = default!;
        public DbSet<Classe> Classes { get; set; } = default!;
        public DbSet<Cours> Cours { get; set; } = default!;
        public DbSet<DetailCours> DetailCours { get; set; } = default!;
        public DbSet<Abscence> Abscences { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships
            modelBuilder.Entity<Etudiant>()
                .HasOne(et => et.Classe)
                .WithMany(cl => cl.Etudiants)
                .HasForeignKey(et => et.ClasseId); // Ensure ClasseId is defined in Etudiant model

            modelBuilder.Entity<Professeur>()
                .HasMany(prof => prof.Cours)
                .WithOne(c => c.Professeur)
                .HasForeignKey(c => c.ProfesseurId); // Ensure ProfesseurId is defined in Cours model

            modelBuilder.Entity<Cours>()
                .HasMany(c => c.DetailCours)
                .WithOne(dc => dc.Cours)
                .HasForeignKey(dc => dc.CoursId); // Ensure CoursId is defined in DetailCours model

            modelBuilder.Entity<DetailCours>()
                .HasOne(dc => dc.Classe)
                .WithMany(cl => cl.DetailCours)
                .HasForeignKey(dc => dc.ClasseId); // Ensure ClasseId is defined in DetailCours model

            modelBuilder.Entity<Abscence>()
                .HasOne(ab => ab.Etudiant)
                .WithMany(et => et.Absences)
                .HasForeignKey(ab => ab.EtudiantId); // Ensure EtudiantId is defined in Abscence model

            // modelBuilder.Entity<Abscence>()
            //     .HasOne(ab => ab.DetailCours)
            //     .WithMany(dc => dc.Abscences)
            //     .HasForeignKey(ab => ab.DetailCoursId); // Ensure DetailCoursId is defined in Abscence model
        }

    }
}
