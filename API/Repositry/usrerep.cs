using API.ApplicationDbContext;
using API.Model;
using API.Repositry.IRepositry;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Repositry
{
    public class usrerep : Iuser
    {
        private readonly ApplicationDbcontext _context;
        private readonly Appsettinges _appSettings;
        public usrerep(ApplicationDbcontext context, IOptions<Appsettinges> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public user Authenticte(string UserName, string Password)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.UserName == UserName && u.Password == Password);
            if (userInDb == null) return null;
            //JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userInDb.Id.ToString()),
                    new Claim(ClaimTypes.Role, userInDb.Rols)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescritor);
            userInDb.Token = tokenHandler.WriteToken(token);

            userInDb.Password = "";
            return userInDb;

        }

        public bool IsUniqueUser(string UserName)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == UserName);
            if (user == null) return true;
            return false;
        }

        public user Register(string UserName, string Password)
        {
            user user = new  user()
            {
                UserName = UserName,
                Password = Password,
                Rols = "Admin"
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;

        }
    }
}
