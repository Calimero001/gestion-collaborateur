using Colaborateur.Base;
using Colaborateur.Models;

namespace Colaborateur.Date.Service
{
    public class CollaborateursService : EntityBaseRepository<Collaborateur>, ICollaborateursService
    {
        public CollaborateursService(AppDbContext context) : base(context) { }

    }
}
