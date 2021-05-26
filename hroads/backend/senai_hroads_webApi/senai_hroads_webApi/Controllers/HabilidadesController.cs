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
    public class HabilidadesController : ControllerBase
    {
        /// <summary>
        /// _habilidadeRepository recebe os métodos da interface
        /// </summary>
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            // que por sua vez recebe os métodos do repositório
            _habilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>uma lista de habilidades e um status code 200 - ok</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            //faz a chamada para o método de listar
            return Ok(_habilidadeRepository.ListarHabilidades());
        }

        /// <summary>
        /// busca uma habilidade pelo seu id
        /// </summary>
        /// <param name="id">id da habilidade que será buscada</param>
        /// <returns>uma habilidade e um status code 200 - OK</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_habilidadeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade"> objeto com as informações que serão cadastradas</param>
        /// <returns>um status code 201 - created</returns>]

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            //faz a chamada para o método
            _habilidadeRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma habilidade através da url na requisição
        /// </summary>
        /// <param name="id">id da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">objeto que terá as novas informações para a habilidade</param>
        /// <returns>um status code 204 - no content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizada)
        {
            //busca a habilidade
            Habilidade habilidadeBuscada = _habilidadeRepository.BuscarPorId(id);

            //se ela não for nula
            if (habilidadeBuscada != null)
            {
                //faz a atualização dos campos
                _habilidadeRepository.AtualizarUrl(id, habilidadeAtualizada);

                //retorna um status code
                return StatusCode(204);
            }

            //se for nula, retorna um notFound
            return NotFound("A habilidade solicitada não foi encontrada");
        }

        /// <summary>
        /// Apaga uma habilidade do banco de dados
        /// </summary>
        /// <param name="id">id da habilidade que será apagada</param>
        /// <returns>um status code 204 - no content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _habilidadeRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
