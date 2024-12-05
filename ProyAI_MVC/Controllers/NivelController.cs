using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyAI_MVC.Models;

namespace ProyAI_MVC.Controllers
{
    public class NivelController : Controller
    {

        private readonly MiDbContextN _contextn;
        private readonly HttpClient _httpClient;

        public IActionResult Index()
        {
            var niveles = _contextn.Nivel.ToList();
            // Pasar los niveles a la vista
            return View(niveles);
        }
    }
}
