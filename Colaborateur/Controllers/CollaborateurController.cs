using Colaborateur.Date.Service;
using Colaborateur.Models;
using Microsoft.AspNetCore.Mvc;

namespace Colaborateur.Controllers
{
    public class CollaborateurController : Controller
    {
        private readonly ICollaborateursService _myService;
        public CollaborateurController(ICollaborateursService myService)
        {
            _myService = myService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _myService.GetAllAsync();
            return View(data);

        }
        //Get: Collaborateur/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Maricule,FullName,Email,DateEntree_SQLI,N_Tel,CIN")] Collaborateur collaborateur)
        {
            if (!ModelState.IsValid)
            {
                return View(collaborateur);
            }
            await _myService.AddAsync(collaborateur);
            return RedirectToAction(nameof(Index));
        }
        //Get: Collaborateur/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _myService.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        //Get: Collaborateur/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var collaborateurDetails = await _myService.GetByIdAsync(id);
            if (collaborateurDetails == null) return View("NotFound");
            return View(collaborateurDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Maricule,FullName,Email,DateEntree_SQLI,N_Tel,CIN")] Collaborateur collaborateur)
        {
            if (!ModelState.IsValid)
            {
                return View(collaborateur);
            }
            await _myService.UpdateAsync(id, collaborateur);
            return RedirectToAction(nameof(Index));
        }
        //Get: Collaborateurs/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var collaborateurDetails = await _myService.GetByIdAsync(id);
            if (collaborateurDetails == null) return View("NotFound");
            return View(collaborateurDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collaborateurDetails = await _myService.GetByIdAsync(id);
            if (collaborateurDetails == null) return View("NotFound");

            await _myService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
