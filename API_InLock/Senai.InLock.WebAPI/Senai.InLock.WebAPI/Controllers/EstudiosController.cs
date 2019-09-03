using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebAPI.Domains;
using Senai.InLock.WebAPI.Repositories;

namespace Senai.InLock.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("Application/json")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        EstudiosRepository estudiosRepository = new EstudiosRepository();
        /// <summary>
        /// Listar os estudios
        /// </summary>
        /// <returns>Uma Lista de estudios</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estudiosRepository.Listar());
        }

        /// <summary>
        /// Cadastrando um estudio
        /// </summary>
        /// <param name="estudio"></param>
        /// <returns>Um Ok</returns>
        [Authorize (Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                string IdRecuperado = User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
                int id = int.Parse(IdRecuperado);
                estudio.UsuarioId = id;
                estudiosRepository.Cadastrar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro: " + ex.Message });
            }
        }

        /// <summary>
        /// Atualizar um estudio
        /// </summary>
        /// <param name="estudio"></param>
        /// <returns>Um Ok</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar (Estudios estudio)
        {
            try
            {
                Estudios EstudioBuscado = estudiosRepository.BuscarPorId(estudio.EstudioId);

                if (EstudioBuscado == null)
                    return NotFound();

                estudiosRepository.Atualizar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletar um estudio
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um Ok</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            estudiosRepository.Deletar(id);
            return Ok();
        }

        [HttpGet("buscar/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            Estudios estudios = estudiosRepository.BuscarPorNome(nome);
            if (estudios == null)
            {
                return NotFound();
            }
            return Ok(estudios);
        }

        [HttpGet("buscarPais/{pais}")]
        public IActionResult BuscarPeloPais (string pais)
        {
            return Ok(estudiosRepository.BuscarPeloPais(pais));
        }
    }
}