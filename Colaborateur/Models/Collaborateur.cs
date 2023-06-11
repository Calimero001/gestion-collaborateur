
using Colaborateur.Base;
using System.ComponentModel.DataAnnotations;

namespace Colaborateur.Models
{
    public class Collaborateur : IEntityBase
    {
        public int Id { get; set; }
        public string Maricule { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        public string N_Tel { get; set; }
        public string CIN { get; set; }

        [Display(Name = "DateEntree-SQLI")]
        [Required(ErrorMessage = "DateEntree is required")]
        public DateTime DateEntree_SQLI { get; set; }
        public bool? IsSelected { get; set; }

        public ICollection<ProjetCollaborateur>? ProjetCollaborateurs { get; set; }
        public ICollection<ObjectifGlobale>? ObjectifGlobale { get; set; }
    }
}
