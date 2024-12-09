namespace devoirc_.Models;
public class Professeur
{
    public int Id { get; set; } // Identifiant unique pour le professeur

    public string Nom { get; set; } // Nom du professeur

    public string Prenom { get; set; } // Prénom du professeur

    public string Specialite { get; set; } // Spécialité du professeur

    public string Grade { get; set; } // Grade du professeur

    // Propriétés de navigation
     public List<Cours> Cours { get; set; } = new List<Cours>();
}
