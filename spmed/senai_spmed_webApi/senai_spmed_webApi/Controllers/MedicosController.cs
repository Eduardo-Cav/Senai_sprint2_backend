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
    public class MedicosController : ControllerBase
    {
        /// <summary>
        /// _medicoRepository recebe os métodos da interface
        /// </summary>
        private IMedicoRepository _medicoRepository { get; set; }

        /// <summary>
        /// _medicoRepository recebe os métodos de seu repositório
        /// </summary>
        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// lista todos os médicos
        /// </summary>
        /// <returns>uma lista de médicos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_medicoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// busca um médico pelo nome
        /// </summary>
        /// <param name="id">nome do médio que será buscado</param>

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_medicoRepository.BuscarMedico(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// cadastra um novo médico
        /// </summary>
        /// <param name="novoMedico">informações do novo médico que será cadastrado</param>

        [HttpPost]
        public IActionResult Post(Medico novoMedico)
        {
            try
            {
                // Faz a chamada para o método
                _medicoRepository.Cadastrar(novoMedico);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// atualiza os dados de um médico, definido pelo id na url da requisição
        /// </summary>
        /// <param name="id">id do médico que será passado</param>
        /// <param name="medicoAtualizado">objeto médico atualizado com as informações trocadas</param>

        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico medicoAtualizado)
        {
            try
            {
                _medicoRepository.AtualizarPorId(id, medicoAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// atualiza apenas determinadas informações de um médico, definido pelo id na url da requisição
        /// </summary>
        /// <param name="id">id do médico que será passado</param>
        /// <param name="medicoAtualizado">objeto médico atualizado com as informações trocadas</param>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Medico medicoAtualizado)
        {
            try
            {
                _medicoRepository.AtualizarPorId(id, medicoAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// deleeta um médico pelo seu id
        /// </summary>
        /// <param name="id">id do médico que será excluido</param>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _medicoRepository.Deletar(id);

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
