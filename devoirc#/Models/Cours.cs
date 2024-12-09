namespace devoirc_.Models;
public class Cours
{
    public int Id { get; set; } // Identifiant unique pour le cours

    public string Module { get; set; } // Nom du module enseigné

    public DateTime Date { get; set; } // Date du cours

    public DateTime HeureDebut { get; set; } // Heure de début du cours

    public DateTime HeureFin { get; set; } // Heure de fin du cours

    public int Semestre { get; set; } // Semestre du cours

    // Propriétés de navigation
    // public int ProfesseurId { get; set; } // Clé étrangère vers le professeur
    public int ProfesseurId { get; set; } // Add this line
     public Professeur Professeur { get; set; } // Le professeur qui enseigne ce cours

    public List<DetailCours> DetailCours { get; set; } = new List<DetailCours>(); // Relation avec les classesticipant au cours
}
