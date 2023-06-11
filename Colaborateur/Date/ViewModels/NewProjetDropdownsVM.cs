using Colaborateur.Models;

namespace Colaborateur.Date.Models
{
    public class NewProjetDropdownsVM
    {
        public NewProjetDropdownsVM()
        {

            Collaborateurs = new List<Collaborateur>();
        }


        public List<Collaborateur> Collaborateurs { get; set; }
    }
}
