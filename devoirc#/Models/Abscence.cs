namespace devoirc_.Models;
public class Abscence
{
    public int Id { get; set; } 

    public DateTime DateAbsence { get; set; } // Date de l'absence

    public int EtudiantId { get; set; } // Clé étrangère vers l'étudiant
    public Etudiant Etudiant { get; set; }

    public int CoursId { get; set; } // Clé étrangère vers le cours
    public Cours Cours { get; set; }
}
