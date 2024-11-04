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

        private readonly MiDbContext _context;
        private readonly HttpClient _httpClient;

        public IActionResult Index()
        {
            return View();
        }
    }
}
