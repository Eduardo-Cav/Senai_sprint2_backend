using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_inlock_webApi_DBFirst.Domains;
using senai_inlock_webApi_DBFirst.Interfaces;
using senai_inlock_webApi_DBFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi_DBFirst.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class EstudiosController : ControllerBase
    {
        /// <summary>
        /// objeto _estudioRepository que recebe os métodos da interface
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }

        /// <summary>
        /// Pega o objeto _estudioRepository e implementa os métodos do repositório
        /// </summary>
        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Lista os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios e um status code 200 - OK</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a reposta da requisição (ok), com a lista de estúdios
            return Ok(_estudioRepository.ListarEstudios());
        }

        /// <summary>
        /// busca um estúdio através do seu id
        /// </summary>
        /// <param name="id">id do estúdio que será encontrado</param>
        /// <returns>um estúdio e um status code 200 - OK</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int idEstudio)
        {
            //retorna a resposta da requisição fazendo a chamada para o método definido
            return Ok(_estudioRepository.BuscarPorId(idEstudio));
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">o objeto novo estúdio com as informações que serão cadastradas</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Estudio novoEstudio)
        {
            //chama o método
            _estudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }

        /// <summary>
        /// atualiza um estúdio existente
        /// </summary>
        /// <param name="id">id do estúdio que vai ser atualizado</param>
        /// <param name="estudioAtualizado">objeto de estudio com as novas informações</param>
        /// <returns>um status code 204 - no content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Estudio estudioAtualizado)
        {
            //chama o método atualizar
            _estudioRepository.AtualizarUrl(id, estudioAtualizado);

            return StatusCode(204);        
        }

        /// <summary>
        /// deleta um estúdio pelo id
        /// </summary>
        /// <param name="id">id do estúdio deletado</param>
        /// <returns>um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o método de deletar
            _estudioRepository.Deletar(id);

            return StatusCode(204);
        }

        /// <summary>
        /// faz uma lista de estúdios com seus respectivos jogos
        /// </summary>
        /// <returns>uma lista de estúdios com os jogos e um status code 200 - Ok</returns>
        [HttpGet("Jogos")]
        public IActionResult GetGames()
        {
            //retorna a resposta fazendo a chamada para o método
            return Ok(_estudioRepository.ListarJogos());
        }
    }
}
