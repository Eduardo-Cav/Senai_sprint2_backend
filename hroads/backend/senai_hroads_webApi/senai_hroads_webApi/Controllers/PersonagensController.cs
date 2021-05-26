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

    public class PersonagensController : ControllerBase
    {
        /// <summary>
        /// objeto _personagemRepository recebe os métodos da interface
        /// </summary>
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            //_personagemRepository pega os métodos do repositório
            _personagemRepository = new PersonagemRepository();
        }

        /// <summary>
        /// Lista todos os Personagens
        /// </summary>
        /// <returns>uma lista de personagens e um status code 200 - ok</returns>
        
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            //retorna um ok e o método de listar
            return Ok(_personagemRepository.ListarPersonagens());
        }

        /// <summary>
        /// busca um personagem através do seu id
        /// </summary>
        /// <param name="id">id do personagem que será buscado</param>
        /// <returns>um personagem buscado e um status code 200 - ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_personagemRepository.BuscarPorId(id));
        }

        /// <summary>
        /// cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto com as informações do funcionário que vai ser cadastrado</param>
        /// <returns>um status code 201 - created</returns>
        
        [Authorize (Roles = "2")]
        [HttpPost]
        public IActionResult Post(Personagem novoPersonagem)
        {
            //faz a chamada para o método
            _personagemRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um personagem através do id pela url da requisição
        /// </summary>
        /// <param name="id">id do personagem que será buscado</param>
        /// <param name="pAtualizado">objeto com as novas informações desse personagem</param>
        /// <returns>um status code 204 - no content</returns>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagem pAtualizado)
        {
            //busca o personagem
            Personagem personagemBuscado = _personagemRepository.BuscarPorId(id);

            //se ela não for nula
            if (personagemBuscado != null)
            {
                //faz a atualização dos campos
                _personagemRepository.AtualizarUrl(id, pAtualizado);

                //retorna um status code
                return StatusCode(204);
            }

            //se for nula, retorna um notFound
            return NotFound("Não foi possivel encontrar o personagem que você solicitou");
        }

        /// <summary>
        /// deleta um personagem 
        /// </summary>
        /// <param name="id">id do personagem que será deletado</param>
        /// <returns>um status code 204 - no content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personagemRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}