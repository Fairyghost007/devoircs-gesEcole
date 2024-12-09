using devoirc_.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace devoirc_.Data.Fixtures
{
    public class Fixtures
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Check if the database has already been seeded
            if (context.Etudiants.Any() || context.Professeurs.Any() || context.Classes.Any())
                return;

            // Seed Professeurs
            var professeurs = new List<Professeur>
            {
                new Professeur { Nom = "Doe", Prenom = "John", Specialite = "Mathematics", Grade = "Assistant" },
                new Professeur { Nom = "Smith", Prenom = "Jane", Specialite = "Computer Science", Grade = "Professor" }
            };
            context.Professeurs.AddRange(professeurs);
            context.SaveChanges();

            // Seed Classes
            var classes = new List<Classe>
            {
                new Classe { Libelle = "3E", Filiere = "Informatique" },
                new Classe { Libelle = "3B", Filiere = "Mathematics" }
            };
            context.Classes.AddRange(classes);
            context.SaveChanges();

            // Seed Cours
            var cours = new List<Cours>
            {
                new Cours { Module = "Math 101", Date = DateTime.UtcNow, HeureDebut = DateTime.UtcNow.AddHours(1), HeureFin = DateTime.UtcNow.AddHours(3), Semestre = 1, Professeur = professeurs[0] },
                new Cours { Module = "CS 101", Date = DateTime.UtcNow, HeureDebut = DateTime.UtcNow.AddHours(2), HeureFin = DateTime.UtcNow.AddHours(4), Semestre = 1, Professeur = professeurs[1] }
            };
            context.Cours.AddRange(cours);
            context.SaveChanges();

            // Seed Etudiants
            var etudiants = new List<Etudiant>
            {
                new Etudiant { Matricule = "12345", NomComplet = "Alice Johnson", Adresse = "123 Street, City" },
                new Etudiant { Matricule = "67890", NomComplet = "Bob Brown", Adresse = "456 Avenue, City" }
            };
            context.Etudiants.AddRange(etudiants);
            context.SaveChanges();

            // Assign Etudiants to Classes (This is crucial for the relationships to be established)
            var classeA = classes[0];
            var classeB = classes[1];
            etudiants[0].ClasseId = classeA.Id;  // Alice is in class 3A
            etudiants[1].ClasseId = classeB.Id;  // Bob is in class 3B
            context.SaveChanges();

            // Seed Absences and link them to Etudiants and Cours
            var absences = new List<Abscence>
            {
                new Abscence { DateAbsence = DateTime.UtcNow.AddDays(-1), EtudiantId = etudiants[0].Id, CoursId = cours[0].Id },
                new Abscence { DateAbsence = DateTime.UtcNow.AddDays(-2), EtudiantId = etudiants[1].Id, CoursId = cours[1].Id }
            };
            context.Abscences.AddRange(absences);
            context.SaveChanges();

            // Seed DetailCours (Course-Class relation)
            var detailCours = new List<DetailCours>
            {
                new DetailCours { CoursId = cours[0].Id, ClasseId = classeA.Id },
                new DetailCours { CoursId = cours[1].Id, ClasseId = classeB.Id }
            };
            context.DetailCours.AddRange(detailCours);
            context.SaveChanges();

            // Link Etudiants to Cours they are following
            etudiants[0].CoursSuivis.Add(cours[0]);  // Alice follows Math 101
            etudiants[1].CoursSuivis.Add(cours[1]);  // Bob follows CS 101
            context.SaveChanges();
        }
    }
}
