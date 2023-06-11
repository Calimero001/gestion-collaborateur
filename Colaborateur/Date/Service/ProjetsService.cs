using Colaborateur.Base;
using Colaborateur.Date.Models;
using Colaborateur.Models;
using Microsoft.EntityFrameworkCore;

namespace Colaborateur.Date.Service
{
    public class ProjetsService : EntityBaseRepository<Projet>, IProjetsService
    {
        private readonly AppDbContext _context;

        public ProjetsService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Collaborateur>> GetAllCollaborateurs()
        {
            return await _context.Collaborateurs.ToListAsync();
        }
        public async Task AddNewProjetAsync(NewProjetVM data)
        {
            var newProjet = new Projet()
            {
                NomProjet = data.NomProjet,
                Description = data.Description,
                DateDebut = data.DateDebut,
                DateFin = data.DateFin,
                N_Collaborateur = data.N_Collaborateur
            };

            _context.Projets.Add(newProjet);
            await _context.SaveChangesAsync();

            // Add Projet Collaborateurs
            var projetCollaborateurs = data.SelectedCollaborateurIds.Select(collaborateurId => new ProjetCollaborateur()
            {
                ProjetId = newProjet.Id,
                CollaborateurId = collaborateurId
            }).ToList();

            _context.ProjetsCollaborateurs.AddRange(projetCollaborateurs);
            await _context.SaveChangesAsync();
        }


        public async Task<Projet> GetProjetByIdAsync(int id)
        {
            var projetDetails = await _context.Projets
                .Include(p => p.ProjetCollaborateurs)
                .ThenInclude(pc => pc.Collaborateur)
                .FirstOrDefaultAsync(p => p.Id == id);

            return projetDetails;
        }

        public async Task<NewProjetDropdownsVM> GetNewProjetDropdownsValues()
        {
            var allCollaborateurs = await _context.Collaborateurs.ToListAsync();
            return new NewProjetDropdownsVM { Collaborateurs = allCollaborateurs };
        }



        public async Task UpdateProjetAsync(NewProjetVM data)
        {
            var dbProjet = await _context.Projets
                .Include(p => p.ProjetCollaborateurs)
                .FirstOrDefaultAsync(p => p.Id == data.Id);

            if (dbProjet != null)
            {
                dbProjet.NomProjet = data.NomProjet;
                dbProjet.DateDebut = data.DateDebut;
                dbProjet.DateFin = data.DateFin;
                dbProjet.N_Collaborateur = data.N_Collaborateur;
                dbProjet.Description = data.Description;

                // Update existing ProjetCollaborateur entries
                var existingCollaborateurIds = dbProjet.ProjetCollaborateurs.Select(pc => pc.CollaborateurId).ToList();
                var selectedCollaborateurIds = data.SelectedCollaborateurIds.ToList();

                // Remove ProjetCollaborateur entries not selected
                var removedCollaborateurIds = existingCollaborateurIds.Except(selectedCollaborateurIds).ToList();
                var removedCollaborateurs = dbProjet.ProjetCollaborateurs.Where(pc => removedCollaborateurIds.Contains(pc.CollaborateurId)).ToList();
                _context.ProjetsCollaborateurs.RemoveRange(removedCollaborateurs);

                // Add new ProjetCollaborateur entries
                var addedCollaborateurIds = selectedCollaborateurIds.Except(existingCollaborateurIds).ToList();
                var addedProjetCollaborateurs = addedCollaborateurIds.Select(collaborateurId => new ProjetCollaborateur()
                {
                    ProjetId = dbProjet.Id,
                    CollaborateurId = collaborateurId
                }).ToList();
                _context.ProjetsCollaborateurs.AddRange(addedProjetCollaborateurs);

                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteProjetAsync(Projet projet)
        {
            _context.Projets.Remove(projet);
            await _context.SaveChangesAsync();
        }

    }
}
