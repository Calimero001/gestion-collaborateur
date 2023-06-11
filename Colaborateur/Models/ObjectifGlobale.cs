using Colaborateur.Base;

namespace Colaborateur.Models
{
    public class ObjectifGlobale : IEntityBase
    {
        public int Id { get; set; }
        public double NoteGlobale { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
        public DateTime DateDubut { get; set; }
        public DateTime DateFin { get; set; }

        public ICollection<Objectif> Objectifs { get; set; }
        public int CollaborateurId { get; set; }
        public Collaborateur Collaborateur { get; set; }
    }
}
