using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebAPI.Domains;
using Senai.InLock.WebAPI.Repositories;
using Senai.InLock.WebAPI.ViewModels;

namespace Senai.InLock.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("Application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuarioRepository usuariosRepository = new UsuarioRepository();
        /// <summary>
        /// logar um Usuario
        /// </summary>
        /// <param name="login"></param>
        /// <returns>um Token</returns>
        [HttpPost]
        public IActionResult Login (LoginViewModel login)
        {
            try
            {
                Usuarios Usuario = usuariosRepository.BuscarPorEmailSenha(login);
                if (Usuario == null)
                {
                    return NotFound(new { mensagem = "Email ou senha inválidos." });
                }

                var claims = new[]
                {
                    // email
                    new Claim(JwtRegisteredClaimNames.Email, Usuario.Email),
                    new Claim("chave", "valor"),
                    // id
                    new Claim(JwtRegisteredClaimNames.Jti, Usuario.UsuarioId.ToString()),
                    // é a permissão do usuário
                    new Claim(ClaimTypes.Role, Usuario.Permissao),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("InLock-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "InLock.WebApi",
                    audience: "InLock.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                // gerar a chave pra vocês
                // return Ok(new { mensagem = "Sucesso, bro." });
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro." + ex.Message });
            }
        }
    }
}