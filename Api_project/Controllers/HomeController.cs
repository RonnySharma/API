using Api_project.Models;
using Api_project.Models.Viewmodel;
using Api_project.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Api_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly INationalPark _nationpark;
        private readonly ITrailRep _trail;

        public HomeController(ILogger<HomeController> logger,ITrailRep trail,INationalPark nationalPark)
        {
            _logger = logger;
            _trail = trail;
            _nationpark= nationalPark;
        }

        public  async Task<IActionResult>  Index()
        {
            IndexVM indexVM = new IndexVM()
            {
                NationalParklist = await _nationpark.GetAllAsync(SD.NationalParkAPIPath),
                Traillist = await _trail.GetAllAsync(SD.TrailPIPath),
            };
            return View(indexVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}