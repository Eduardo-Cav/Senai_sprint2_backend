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
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {


        /// <summary>
        /// objeto _usuarioRepository herda os métodos da interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// _usuarioRepository recebe os métodos de seu repositório
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// busca um usuário através do seu id pela url da requisição
        /// </summary>
        /// <param name="id">nome do usuário que será passado</param>
        /// <returns>um usuário</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //retorna um ok junto com o método de listar
                return Ok(_usuarioRepository.BuscarUsuario(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
           
        }

        /// <summary>
        /// faz o cadastro de um usuário
        /// </summary>
        /// <param name="novoUsuario">informações do novo usuário que será cadastrado</param>
        
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                // Faz a chamada para o método
                _usuarioRepository.Cadastar(novoUsuario);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// atualiza um usuário pelo id na url da requisição
        /// </summary>
        /// <param name="id"> id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">novas informações para esse usuário</param>

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            try
            {
                _usuarioRepository.AtualizarPorId(id, usuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// deleta um usuário através do seu id
        /// </summary>
        /// <param name="id">id do usuário que será excluido</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _usuarioRepository.Deletar(id);

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
