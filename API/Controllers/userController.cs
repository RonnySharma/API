using API.Model;
using API.Model.viewModel;
using API.Repositry.IRepositry;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class userController : Controller
    {
        private readonly Iuser _userRepository;
        public userController(Iuser userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] user user)
        {
            if (ModelState.IsValid)
            {
                var isUniqueUser = _userRepository.IsUniqueUser(user.UserName);
                if (!isUniqueUser)
                    return BadRequest("User In Use!!");
                var userInfo = _userRepository.Register(user.UserName, user.Password);
                if (userInfo == null) return BadRequest();
            }
            return Ok();
        }
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] UserVM userVM)
        {
            var user = _userRepository.Authenticte(userVM.UserName, userVM.Password);
            if (user == null) return BadRequest("WrongUSer/PWd");
            return Ok(user);
        }
    }
    }