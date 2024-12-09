namespace devoirc_.Models;
public class Etudiant
{
    public int Id { get; set; } // Identifiant unique pour l'étudiant

    public string Matricule { get; set; } // Matricule de l'étudiant

    public string NomComplet { get; set; } // Nom complet de l'étudiant

    public string Adresse { get; set; } // Adresse de l'étudiant

    // Propriétés de navigation
    public int ClasseId { get; set; }
    public Classe Classe { get; set; }
    public List<Abscence> Absences { get; set; } = new List<Abscence>(); // Liste des absences

    public List<Cours> CoursSuivis { get; set; } = new List<Cours>(); // 
}
