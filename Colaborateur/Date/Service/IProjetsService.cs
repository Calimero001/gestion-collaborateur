using Colaborateur.Base;
using Colaborateur.Date.Models;
using Colaborateur.Models;

namespace Colaborateur.Date.Service
{
    public interface IProjetsService : IEntityBaseRepository<Projet>
    {
        Task<Projet> GetProjetByIdAsync(int id);
        Task<NewProjetDropdownsVM> GetNewProjetDropdownsValues();

        Task AddNewProjetAsync(NewProjetVM data);
        Task UpdateProjetAsync(NewProjetVM data);
        Task DeleteProjetAsync(Projet projet);

        Task<List<Collaborateur>> GetAllCollaborateurs();
    }
}
