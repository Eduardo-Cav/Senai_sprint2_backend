using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmed_webApi.Domains;
using senai_spmed_webApi.Interfaces;
using senai_spmed_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        /// <summary>
        /// objeto _tipoRepository herda os métodos da interface
        /// </summary>
        private ITipoUsuarioRepository _tipoRepository { get; set; }

        /// <summary>
        /// _tipoRepository recebe os métodos de seu repositório
        /// </summary>
        public TipoUsuariosController()
        {
            _tipoRepository = new TipoUsuarioRepository();

        }

        /// <summary>
        /// lista todos os tipos
        /// </summary>
        /// <returns>uma lista de tipos de usuario</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_tipoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipo">objeto com as novas informações que serão cadastradas</param>

        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipo)
        {
            try
            {
                // Faz a chamada para o método
                _tipoRepository.Cadastrar(novoTipo);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// atualiza um tipo de usuário pelo seu id
        /// </summary>
        /// <param name="id">id do tipo de usuário que será atualizado</param>
        /// <param name="tipoAtualizado">objeto com as novas informações</param>

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoAtualizado)
        {
            try
            {
                _tipoRepository.AtualizarId(id, tipoAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// deleta um tipo através do seu id
        /// </summary>
        /// <param name="id">id do tipo que será excluido</param>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _tipoRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
