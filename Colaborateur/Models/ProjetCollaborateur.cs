using Colaborateur.Base;

namespace Colaborateur.Models
{
    public class ProjetCollaborateur 
    {
        public int ProjetId { get; set; }
        public Projet Projet { get; set; }

        public int CollaborateurId { get; set; }
        public Collaborateur Collaborateur { get; set; }
    }
}
