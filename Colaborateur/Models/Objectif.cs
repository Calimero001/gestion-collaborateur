using Colaborateur.Base;

namespace Colaborateur.Models
{
    public class Objectif : IEntityBase
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public double Note { get; set; }
        public int Poit_NoteGlobale { get; set; }
        public string Description { get; set; }
        public DateTime Delai { get; set; }
        public int ObjectifGlobaleId { get; set; }
        public ObjectifGlobale ObjectifGlobale { get; set; }
    }
}
