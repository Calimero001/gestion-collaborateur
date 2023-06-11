using Colaborateur.Models;
using System.ComponentModel.DataAnnotations;

namespace Colaborateur.Models
{
    public class NewProjetVM
    {
        public int Id { get; set; }
        public string NomProjet { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int N_Collaborateur { get; set; }

        public List<Collaborateur> AllCollaborateurs { get; set; }
        public List<int> SelectedCollaborateurIds { get; set; }

        public NewProjetVM()
        {
            AllCollaborateurs = new List<Collaborateur>();
        }

    }
}
