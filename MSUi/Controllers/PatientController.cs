using Microsoft.AspNetCore.Mvc;
using MSUi.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace MSUI.Controllers
{
    public class PatientController : Controller
    {
        private readonly HttpClient _httpClient;

        public PatientController(HttpClient httpClient)
        {

            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://Localhost:7001");

        }

        /// <summary>
        /// méthode en vue collationnée la liste des patients auprès de MSPatient et d'afficher une vue index
        /// </summary>
        /// <returns>vue index</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Patient"); // Utiliser un endpoint spécifique pour récupérer tous les patients
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                var patients = JsonConvert.DeserializeObject<List<Patient>>(responseData);
                return View(patients);
            }
            else
            {
                return StatusCode((int)response.StatusCode, $"Erreur HTTP: {response.StatusCode}");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient); // Retourne la vue avec les erreurs de validation
            }

            var json = JsonConvert.SerializeObject(patient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("/api/Patient", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, $"Erreur HTTP: {response.StatusCode}. Détails : {errorMessage}");
            }
        }
       

        // [HttpPost]
        public async Task<IActionResult> Update(int id, Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient); // Retourne la vue avec les erreurs de validation
            }

            var json = JsonConvert.SerializeObject(patient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync($"/api/Patient/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(); // Gérer le cas où le patient n'existe pas
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, $"Erreur HTTP: {response.StatusCode}. Détails : {errorMessage}");
            }
        }


        // [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/Patient/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(); // Gérer le cas où le patient n'existe pas
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, $"Erreur HTTP: {response.StatusCode}. Détails : {errorMessage}");
            }
        }
    }
}


    
    






