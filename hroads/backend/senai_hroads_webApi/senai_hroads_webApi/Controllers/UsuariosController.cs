using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_hroads_webApi.Domains;
using senai_hroads_webApi.Interfaces;
using senai_hroads_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //objeto _usuarioRepository herda os métodos da interface
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            //_usuarioRepository recebe os métodos de seu repositório
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Faz uma lista de usuários
        /// </summary>
        /// <returns>uma lista de usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //retorna um ok junto com o método de listar
            return Ok(_usuarioRepository.ListarUsuarios());
        }

        /// <summary>
        /// Busca um usuário através do seu id
        /// </summary>
        /// <param name="id">id do usuário que será buscado</param>
        /// <returns>um usuário</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //retorna um ok e o método para buscar 
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">informações do usuário que serão passadas</param>
        /// <returns>um novo usuário e um status code</returns>
        
        [Authorize (Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            //chamada para o método de cadastrar
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Faz a atualização de um usuário
        /// </summary>
        /// <param name="id">id do usuário que será atualizado</param>
        /// <param name="userAtualizado">as informações que esse usuário irá passar</param>
        /// <returns>um usuário atualizado e um status code 204 - no content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario userAtualizado)
        {
            //busca o usuário pelo id
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            //se o usuário buscado não for nulo
            if (usuarioBuscado.Email != null)
            {
                //faz a atualização do usuario
                _usuarioRepository.AtualizarUrl(id, userAtualizado);

                // e retorna um no content
                return StatusCode(204);
            }

            //se o tipo não for encontrado, retorn um not found
            return NotFound("O usuário buscado não foi encontrado");
        }

        /// <summary>
        /// apaga um usuário 
        /// </summary>
        /// <param name="id">id do usuário que será deletado</param>
        /// <returns> um status code 204 - no content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //chama o método de deletar
            _usuarioRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
