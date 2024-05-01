using Microsoft.AspNetCore.Mvc;
using MSUi.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace MSUi.Controllers
{
    public class NoteController : Controller
    {
        private readonly HttpClient _httpClient;

        public NoteController(HttpClient httpClient)
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
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Notes"); // Utiliser un endpoint spécifique pour récupérer tous les patients
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                var notes = JsonConvert.DeserializeObject<List<Note>>(responseData);
                return View(notes);
            }
            else
            {
                return StatusCode((int)response.StatusCode, $"Erreur HTTP: {response.StatusCode}");
            }
           // return View();
        }
    }
}
