using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MSUi.Models;
using Newtonsoft.Json;

namespace MSUI.Controllers
{
    public class PatientController : Controller
    {

        private readonly HttpClient _httpClient;



        public PatientController(HttpClient httpClient, IHttpClientFactory clientFactory)
        {

            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://Localhost:6001");

        }

        //    public async Task<List<Patient>> GetPatients()

        //    {
        //        using HttpResponseMessage response = await _httpClient.GetAsync("/api/Patient");
        //        response.EnsureSuccessStatusCode();
        //        using var responseStream = await response.Content.ReadAsStreamAsync();
        //        return await JsonSerializer.DeserializeAsync<List<Patient>>(responseStream);

        //    }

        //    public async Task<IActionResult> Index()
        //    {
        //        var patients = await GetPatients();
        //        return View(patients);
        //    }
        //}
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/patient"); // Utiliser un endpoint spécifique pour récupérer tous les patients
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
    }
}

