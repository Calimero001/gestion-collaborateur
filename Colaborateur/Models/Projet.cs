using Colaborateur.Base;

namespace Colaborateur.Models
{
    public class Projet : IEntityBase
    {
        public int Id { get; set; }
        public string NomProjet { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int N_Collaborateur{ get; set;}
        public ICollection<ProjetCollaborateur> ProjetCollaborateurs { get; set; }
    }
}
