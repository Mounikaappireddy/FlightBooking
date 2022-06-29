using LoginService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly FlightBookingDbContext _context;
        private readonly ILoginserviceReposioty _loginserviceReposioty;
        private readonly IConfiguration _config;
        public LoginController(FlightBookingDbContext context,ILoginserviceReposioty loginserviceReposioty,IConfiguration config)
        {
            this._context = context;
            _loginserviceReposioty = loginserviceReposioty;
            _config = config;
        }
        private IOptions<Audience> _settings;
        string UserId = string.Empty;
        string Password = string.Empty;
        [HttpPost("UserRegister")]
        public ActionResult Register( Users users)
        {
            try
            {
                var userdetails = _loginserviceReposioty.GetuserId(users.UserId);
                if (userdetails == null)
                {
                    var result = _loginserviceReposioty.RegisterUser(users);
                    return Ok(users);
                }
                 else
                {
                    return Ok("userid already exists");
                }
            }
            catch(Exception ex)
            {
                return Ok("failed to Register");
            }
        }
        [HttpGet("Login")]
        public async Task<ActionResult> Login(string userId,string password)
        {
            try
            {
                var userdetails = _loginserviceReposioty.GetuserId(userId);
                if (userdetails != null)
                {
                    if (userdetails.Password == password)
                    {
                        var token = Createtoken(userdetails);
                        //var refreshToken = GenerateRefreshToken();
                        //SetRefreshToken(refreshToken);
                        return Ok(new { Token = token, IsAdmin = userdetails.IsAdmin });
                    }
                    else
                        return Ok("Invalid credentials");
                }
                else
                    return Ok("Userdata not found");
            }
            catch(Exception ex)
            {
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
                }
            }
        }
        private string Createtoken(Users user)
        {
            List<Claim> claims = new List<Claim>(){
              new Claim(ClaimTypes.Name,user.UserId) };
            if (user.IsAdmin)
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            else
                claims.Add(new Claim(ClaimTypes.Role, "user"));
             
            
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }
        //private RefreshToken GenerateRefreshToken()
        //{
        //    var refreshToken = new RefreshToken
        //    {
        //        Token = Convert.ToBase64String(BitConverter.GetBytes(64)),
        //        Expires = DateTime.Now.AddDays(7),
        //        Created = DateTime.Now
        //    };
        //    return refreshToken;
        //}
        //[HttpPost("refresh-token")]
        //public async Task<ActionResult<string>> RefreshToken()
        //{
        //    var refreshToken = Request.Cookies["refreshToken"];
        //    if (!user.RefreshToken.Equals(refreshToken))
        //    {
        //        return Unauthorized("Invalid Refresh Token");
        //    }
        //    else if (user.TokenExpires < DateTime.Now)
        //    {
        //        return Unauthorized("Token expired");
        //    }
        //    string token = Createtoken(user);
        //    var newRefreshToken = GenerateRefreshToken();
        //    SetRefreshToken(newRefreshToken);
        //    return Ok(token);
        //}
        //private void SetRefreshToken(RefreshToken newRefreshToken)
        //{
        //    var cookieOptions = new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Expires = newRefreshToken.Expires
        //    };
        //    Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);
        //    user.RefreshToken = newRefreshToken.Token;
        //    user.TokenExpires = newRefreshToken.Expires;
        //    user.TokenCreated = newRefreshToken.Created;
        //}
        //[HttpPost("Login")]

        //public async Task<IActionResult> UserLogin([FromBody] Users users)
        //        {
        //            int IsAdminAccess = 0;
        //            if (users.UserId == "")
        //            {
        //                return Json("Username is required");
        //            }
        //            if (users.Passwords == "")
        //            {
        //                return Json("Password is required");
        //            }
        //            var checkuser = _context.Users.Where(a => a.UserId == users.UserId && a.Passwords == users.Passwords);
        //            foreach (var login in checkuser)
        //            {
        //                UserId = login.UserId;
        //                Password = login.Passwords;
        //                IsAdminAccess = Convert.ToInt32(login.IsAdminAccess);
        //            }
        //            if (users.UserId == UserId && users.Passwords == Password)
        //            {
        //                var now = DateTime.UtcNow;
        //                var claims = new Claim[]
        //                    {
        //                          new Claim(JwtRegisteredClaimNames.Sub,users.UserId),
        //                          new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        //                          new Claim(JwtRegisteredClaimNames.Iat,now.ToUniversalTime().ToString(),ClaimValueTypes.Integer64)

        //                    };


        //            }
        //            else
        //            {
        //                return Json("Invalid UserName and password");
        //            }
        //        }
    }

    public class Audience
    {
        public string Secret { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }
    }


}


