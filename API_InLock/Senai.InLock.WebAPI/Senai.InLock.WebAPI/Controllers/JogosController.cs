using System;
using System.Collections.Generic;
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
    public class JogosController : ControllerBase
    {
        JogosRepository jogosRepository = new JogosRepository();
        /// <summary>
        /// Listar Jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(jogosRepository.Listar());
        }

        /// <summary>
        /// Cadastrar Jogos
        /// </summary>
        /// <param name="jogo"></param>
        /// <returns>Um Ok</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Jogos jogo)
        {
            try
            {
                jogosRepository.Cadastrar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro: " + ex.Message });
            }
        }

        /// <summary>
        /// Atualizar Jogos
        /// </summary>
        /// <param name="jogo"></param>
        /// <returns>Um Ok</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Jogos jogo)
        {
            try
            {
                Jogos JogoBuscado = jogosRepository.BuscarPorId(jogo.JogoId);

                if (JogoBuscado == null)
                    return NotFound();

                jogosRepository.Atualizar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletar Jogos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um Ok</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            jogosRepository.Deletar(id);
            return Ok();
        }

        /// <summary>
        /// Realiza uma busca por nome dentro da lista de jogos
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>um jogo</returns>
        [HttpGet("buscar/{nome}")]
        public IActionResult BuscarPorNome (string nome)
        {
            Jogos jogos = jogosRepository.BuscarPorNome(nome);
            if (jogos == null)
            {
                return NotFound();
            }
            return Ok(jogos);
        }

        [HttpGet("BucarMaisCaros")]
        public IActionResult ListarJogosMaisCaros ()
        {
            return Ok(jogosRepository.ListarJogosMaisCaros());
        }

        [HttpGet("BuscarMaisRecentes")]
        public IActionResult ListarJogosMaisRecentes()
        {
            return Ok(jogosRepository.ListarJogosMaisRecentes());
        }
    }
}