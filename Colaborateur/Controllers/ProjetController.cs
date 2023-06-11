using Colaborateur.Date.Models;
using Colaborateur.Date.Service;
using Colaborateur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colaborateur.Controllers
{
    public class ProjetController : Controller
    {
        private readonly IProjetsService _myService;

        public ProjetController(IProjetsService myService)
        {
            _myService = myService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _myService.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var projetDetail = await _myService.GetProjetByIdAsync(id);
            return View(projetDetail);
        }

        public async Task<IActionResult> Create()
        {
            var dropdownValues = await _myService.GetNewProjetDropdownsValues();
            var allCollaborateurs = await _myService.GetAllCollaborateurs();

            var model = new NewProjetVM
            {
                AllCollaborateurs = allCollaborateurs,
                // Set other properties as needed
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProjetVM projet)
        {
            if (!ModelState.IsValid)
            {
                var projetDropdownsData = await _myService.GetNewProjetDropdownsValues();
                ViewBag.Collaborateurs = new SelectList(projetDropdownsData.Collaborateurs, "Id", "FullName");
                return View(projet);
            }

            // Retrieve the selected collaborator IDs
            var selectedCollaborateurIds = Request.Form["SelectedCollaborateurIds"];

            projet.SelectedCollaborateurIds = selectedCollaborateurIds
                .Select(id => int.Parse(id))
                .ToList();

            await _myService.AddNewProjetAsync(projet);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var projet = await _myService.GetProjetByIdAsync(id);

            if (projet == null)
            {
                return NotFound();
            }

            var dropdownValues = await _myService.GetNewProjetDropdownsValues();
            var allCollaborateurs = await _myService.GetAllCollaborateurs();

            var model = new NewProjetVM
            {
                Id = projet.Id,
                NomProjet = projet.NomProjet,
                Description = projet.Description,
                DateDebut = projet.DateDebut,
                DateFin = projet.DateFin,
                N_Collaborateur = projet.N_Collaborateur,
                AllCollaborateurs = allCollaborateurs,
                SelectedCollaborateurIds = projet.ProjetCollaborateurs.Select(pc => pc.CollaborateurId).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewProjetVM projet)
        {
            if (!ModelState.IsValid)
            {
                var projetDropdownsData = await _myService.GetNewProjetDropdownsValues();
                ViewBag.Collaborateurs = new SelectList(projetDropdownsData.Collaborateurs, "Id", "FullName");
                return View(projet);
            }

            var selectedCollaborateurIds = Request.Form["SelectedCollaborateurIds"];

            projet.SelectedCollaborateurIds = selectedCollaborateurIds
                .Select(id => int.Parse(id))
                .ToList();

            await _myService.UpdateProjetAsync(projet);
            return RedirectToAction(nameof(Index));
        }
        //delete
        public async Task<IActionResult> Delete(int id)
        {
            var projetDetail = await _myService.GetProjetByIdAsync(id);

            if (projetDetail == null)
            {
                return NotFound();
            }

            return View(projetDetail);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projet = await _myService.GetProjetByIdAsync(id);

            if (projet == null)
            {
                return NotFound();
            }

            await _myService.DeleteProjetAsync(projet);
            return RedirectToAction(nameof(Index));
        }
    }
}
