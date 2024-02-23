using Api_project.Models;
using Api_project.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Api_project.Controllers
{
    public class NationnalparkController : Controller
    {
        private readonly INationalPark _nationpark;

        public NationnalparkController(INationalPark nationpark)
        {
            _nationpark = nationpark;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region APIs
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             return Json(new { data = await _nationpark.GetAllAsync(SD.NationalParkAPIPath) });
           
        }
        #endregion
        public async Task<IActionResult> Upsert(int? id)
        {
            NationalPark nationalPark = new NationalPark();
            if (id == null) return View(nationalPark);
            nationalPark = await _nationpark.GetAsync(SD.NationalParkAPIPath, id.GetValueOrDefault());
            if (nationalPark == null) return NotFound();
            return View(nationalPark);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Upsert(NationalPark nationalPark)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    nationalPark.Picture = p1;
                }
                else
                {
                    var nationalParkInDb = await _nationpark.GetAsync(SD.NationalParkAPIPath, nationalPark.Id);

                    nationalPark.Picture = nationalParkInDb.Picture;
                }
                if (nationalPark.Id == 0)
                    await _nationpark.CreateAsync(SD.NationalParkAPIPath, nationalPark);
                else
                    await _nationpark.updateAsync(SD.NationalParkAPIPath, nationalPark);

                return RedirectToAction("Index");
            }
            else
                return View(nationalPark);
        }
    }
}
