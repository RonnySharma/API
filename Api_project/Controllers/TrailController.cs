using Api_project.Models;
using Api_project.Models.Viewmodel;
using Api_project.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Api_project.Controllers
{
    public class TrailController : Controller
    {
        private readonly INationalPark _nationalPark;
        private readonly ITrailRep _trail;
        public TrailController(INationalPark nationalPark, ITrailRep trailRep)

        {
            _nationalPark = nationalPark;
            _trail = trailRep;
                
        }
        #region APIs
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mku = await _trail.GetAllAsync(SD.TrailPIPath);
            return Json(new { Data = mku });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var sdt = await _trail.DeleteAsync(SD.TrailPIPath, id);
            if (sdt)

                return Json(new { succes = true, mussage = "data delete" });
            else
                return Json(new { succes = false, mussage = "error while delete dete" });
        }
        #endregion
        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<NationalPark> nationalParks = await _nationalPark.GetAllAsync(SD.NationalParkAPIPath);
            TrailVM trailvm = new TrailVM()
            {
                Trail = new Trail(),
                NationParkLIst = nationalParks.Select(np => new SelectListItem()
                {
                    Text = np.Name,
                    Value = np.Id.ToString()
                })
            };
            if (id == null) return View(trailvm); //Create
            trailvm.Trail = await _trail.GetAsync(SD.TrailPIPath, id.GetValueOrDefault());    //Edit
            if (trailvm.Trail == null) return NotFound();
            return View(trailvm);

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Upsert(TrailVM trailVM)
        {
            if (ModelState.IsValid)
            {
                if (trailVM.Trail.Id == 0)

                    await _trail.CreateAsync(SD.TrailPIPath, trailVM.Trail);

                else

                    await _trail.updateAsync(SD.TrailPIPath, trailVM.Trail);

                return RedirectToAction("Index");
            }
            else
            {
                IEnumerable<NationalPark> nationalParks = await _nationalPark.GetAllAsync(SD.NationalParkAPIPath);
                TrailVM TrailvM = new TrailVM()
                {
                    Trail = new Trail(),
                    NationParkLIst = nationalParks.Select(np => new SelectListItem()
                    {
                        Text = np.Name,
                        Value = np.Id.ToString()
                    })
                };
            }
            return View(trailVM);
        }


    }
}
