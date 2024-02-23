using API.DTO;
using API.Model;
using API.Repositry.IRepositry;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Trail")]
    [ApiController]
    public class TrailController : Controller
    {
      
        private readonly IMapper _mapper;
        private readonly ITrail _trail;
        public TrailController(IMapper mapper,ITrail trail)

        {
            _mapper = mapper;
            _trail = trail;

        }

        [HttpGet]
        public IActionResult GetTrails()
        {
            var nat = _trail.GetTrails().ToList().Select(_mapper.Map<Trail, TrailDTO>);
            return Ok(nat);
        }
        [HttpGet("{trailId:int}", Name = "trail")]
        public IActionResult trail(int trailId)
        {
            var nat = _trail.GetTrail(trailId);
            if (nat == null) return NotFound();
            var nato = _mapper.Map<TrailDTO>(nat);
            return Ok(nato);
        }
        [HttpPost]
        public IActionResult CreateTrail([FromBody] TrailDTO Trailsdto)
        {
            if (Trailsdto == null) return BadRequest(ModelState);
            if (_trail.TraileExists(Trailsdto.Name))
            {
                ModelState.AddModelError("", "National Park DB");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var mj = _mapper.Map<TrailDTO, Trail>(Trailsdto);
            if (!_trail.creatTraile(mj))
            {
                ModelState.AddModelError("", $"samthing want to worng):{mj.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            //return CreatedAtRoute("Getnationlpark", new { nationalParkId = mj.Id }, mj);
            return Ok();
        }
        [HttpPut]
        public IActionResult updateTrail([FromBody] TrailDTO Trailsdto)
        {
            if (Trailsdto == null) return BadRequest(ModelState);
            if (!_trail.TraileExists(Trailsdto.Id)) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var mj = _mapper.Map<TrailDTO, Trail>(Trailsdto);
            if (!_trail.creatTraile(mj))
            {
                ModelState.AddModelError("", $"samthing want to worng):{mj.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


            return NoContent();
        }
        [HttpDelete("{Trail:int}")]
        public IActionResult Delate(int Trail)
        {
            if (!_trail.TraileExists(Trail)) return NotFound();
            var bg = _trail.GetTrail(Trail);
            if (bg == null) return NotFound();
            if (!_trail.DeleteTraile(bg))
            {
                ModelState.AddModelError("", $"samthing want to worng):{bg.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }
    }
}
