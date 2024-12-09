
namespace devoirc_.Models;
public class DetailCours
{
    public int Id { get; set; } // Identifiant unique pour cette association

    public int CoursId { get; set; } // Clé étrangère vers le cours
    public Cours Cours { get; set; }

    public int ClasseId { get; set; } // Clé étrangère vers la classe
    public Classe Classe { get; set; }

    // Champs supplémentaires si nécessaire
    // Exemple : Date d'ajout ou rôle spécifique
}
