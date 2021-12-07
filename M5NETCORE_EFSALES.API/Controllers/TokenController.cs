using M5NETCORE_EFSALES.CORE.DTOs;
using M5NETCORE_EFSALES.CORE.Entities;
using M5NETCORE_EFSALES.CORE.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace M5NETCORE_EFSALES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserAuthService _userAuthService;
        private readonly IConfiguration _configuration;

        public TokenController(IUserAuthService userAuthService, IConfiguration configuration)
        {
            _userAuthService = userAuthService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UserAuthLoginDTO user)
        {
            var userAuth = await _userAuthService.ValidateUser(user.Username, user.Password);
            if (userAuth == null)
                return NotFound();
            var token = GenerateToken(userAuth);
            return Ok(token);
        }


        private string GenerateToken(UserAuth user)
        {
            var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sc);

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, "luis@qboinstitute.com"),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("CodigoSeguroSalud","SS99887711"),
                new Claim("Country","USA")
            };

            var payload = new JwtPayload(_configuration["Authentication:Issuer"], _configuration["Authentication:Audience"], claims, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(1));

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
