using API.DTO;
using API.Model;
using API.Repositry.IRepositry;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Controllers
{
    [Route("api/NationalPark")]
    [ApiController]
    //[Authorize]

    public class NationalPaskController : Controller
    {
        private readonly INationalparkRepositry _nationalpark;
        private readonly IMapper _Mapper;
        public NationalPaskController(INationalparkRepositry nationalpark, IMapper mapper)
        {
            _nationalpark = nationalpark;
            _Mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var nat = _nationalpark.GetNationalParks().ToList().Select(_Mapper.Map<NationalPark, NAtionalparkDTO>);
            return Ok(nat);
        }
        [HttpGet("{NationatparkId:int}", Name = "GetNationalPark")]
        public IActionResult GetNationalPark(int NationatparkId)
        {
            var nat = _nationalpark.GetNationalPark(NationatparkId);
            if (nat == null) return NotFound();
            var nato = _Mapper.Map<NAtionalparkDTO>(nat);
            return Ok(nato);
        }
        [HttpPost]
        public IActionResult CreateNationalPa([FromBody] NAtionalparkDTO Nationaldto)
        {
            if (Nationaldto == null) return BadRequest(ModelState);
            if (_nationalpark.NationalParkExists(Nationaldto.Name))
            {
                ModelState.AddModelError("", "National Park DB");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var mj = _Mapper.Map<NAtionalparkDTO, NationalPark>(Nationaldto);
            if (!_nationalpark.CreateNationalPark(mj))
            {
                ModelState.AddModelError("", $"samthing want to worng):{mj.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            //return CreatedAtRoute("Getnationlpark", new { nationalParkId = mj.Id }, mj);
            return Ok();
        }
        [HttpPut]
        public IActionResult updateNationalPark([FromBody] NAtionalparkDTO Nationatdto)
        {
            if (Nationatdto == null) return BadRequest(ModelState);
            if (!_nationalpark.NationalParkExists(Nationatdto.Id)) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var mj = _Mapper.Map<NAtionalparkDTO, NationalPark>(Nationatdto);
            if (!_nationalpark.updateNationalPark(mj))
            {
                ModelState.AddModelError("", $"samthing want to worng):{mj.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delate(int Nationatpark)
        {
            if (!_nationalpark.NationalParkExists(Nationatpark)) return NotFound();
            var bg = _nationalpark.GetNationalPark(Nationatpark);
            if (bg == null) return NotFound();
            if (!_nationalpark.DelateNationalPark(bg))
            {
                ModelState.AddModelError("", $"samthing want to worng):{bg.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }
    }
}
