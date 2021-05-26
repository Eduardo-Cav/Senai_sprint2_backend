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
    public class TipoHabilidadesController : ControllerBase
    {
        //objeto thRepository herda os métodos da interface
        private ITipoHabilidadeRepository _thRepository { get; set; }

        public TipoHabilidadesController()
        {
            //_thRepository recebe os métodos de seu repositório
            _thRepository = new TipoHabilidadeRepository();
        }

        /// <summary>
        /// faz uma lista de tipos de habilidade
        /// </summary>
        /// <returns>um status code 200 - Ok junto com a lista de tipos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            //retorna um ok junto com o método de listar
            return Ok(_thRepository.ListarTipos());
        }

        /// <summary>
        /// Busca um determiando tipo através do seu id
        /// </summary>
        /// <param name="id">id do tipo buscado</param>
        /// <returns>um status code 200 - OK e um tipo de habiliadade</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //retorna um ok e o método para buscar 
            return Ok(_thRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipo">as novas informações desse tipo</param>
        /// <returns>um status code 201 - created</returns>

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoHabilidade novoTipo)
        {
            //chamada para o método de cadastrar
            _thRepository.Cadastrar(novoTipo);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um tipo de habilidaed
        /// </summary>
        /// <param name="id">id do tipo que será atualizado</param>
        /// <param name="thAtualizado">as novas informações que pertencerão ao tipo</param>
        /// <returns>um status code 204 - no content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoHabilidade thAtualizado)
        {
            //busca se o tipo de habilidade
            TipoHabilidade thBuscado = _thRepository.BuscarPorId(id);

            //se o tipo buscado não for nulo
            if (thBuscado.Nome != null)
            {
                //faz a atualização do tipo
                _thRepository.AtualizarUrl(id, thAtualizado);

                // e retorna um no content
                return StatusCode(204);
            }

            //se o tipo não for encontrado, retorn um not found
            return NotFound("O tipo de habilidade não foi encontrado");
        }

        /// <summary>
        /// deleta um tipo de habilidade
        /// </summary>
        /// <param name="id">id do tipo que vai ser excluido</param>
        /// <returns>um status code 204 - no content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //chama o método de deletar
            _thRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
