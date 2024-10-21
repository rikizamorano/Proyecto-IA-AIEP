using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyAI_MVC.Models;


namespace ProyAI_MVC.Controllers
{
    public class ConsultaController: Controller
    {

        private readonly MiDbContext _context;
        private readonly HttpClient _httpClient;

        public ConsultaController(MiDbContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            var consultas = _context.Consultas.ToList();
            return View(consultas);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(string pregunta)
        {
            if (!string.IsNullOrEmpty(pregunta))
            {
                // Llamar a la API de ChatGPT
                var respuesta = await ObtenerRespuestaChatGPT(pregunta);

                // Guardar en la base de datos
                var nuevaConsulta = new Consulta { Pregunta = pregunta, Respuesta = respuesta };
                _context.Consultas.Add(nuevaConsulta);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<string> ObtenerRespuestaChatGPT(string pregunta)
        {
            var apiKey = "Aqui va la ApiKey"; // Reemplaza con tu clave de API de OpenAI
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                   new { role = "user", content = pregunta }
               }
            };

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic jsonResponse = JsonConvert.DeserializeObject(responseBody);
            return jsonResponse.choices[0].message.content.ToString();
        }




    }
}
