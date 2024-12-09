namespace devoirc_.Models;
public class Classe
{
    public int Id { get; set; } // Identifiant unique pour la classe

    public string Libelle { get; set; } // Nom de la classe (exemple : "3ème A")

    public string Filiere { get; set; } // Filière de la classe (exemple : "Informatique")

    // Propriétés de navigation
    public List<DetailCours> DetailCours { get; set; } = new List<DetailCours>(); // Relation avec les cours

    public List<Etudiant> Etudiants { get; set; } = new List<Etudiant>(); 
}
