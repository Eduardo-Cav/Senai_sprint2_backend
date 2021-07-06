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
    public class PacientesController : ControllerBase
    {
        /// <summary>
        /// _pacienteRepository recebe os métodos da interface
        /// </summary>
        private IPacienteRepository _pacienteRepository { get; set; }

        /// <summary>
        /// _pacienteRepository recebe os métodos de seu repositório
        /// </summary>
        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// lista todos os paciente
        /// </summary>
        /// <returns>uma lista de pacientes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_pacienteRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// busca um paciente pelo id
        /// </summary>
        /// <param name="id">id do paciente buscado</param>
        /// <returns>um objeto do tipo paciente</returns>
        [HttpGet("{id}")]
        public IActionResult GetByName(int id)
        {
            try
            {
                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_pacienteRepository.BuscarPaciente(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">informações do novo paciente que será cadastrado</param>
        [HttpPost]
        public IActionResult Post(Paciente novoPaciente)
        {
            try
            {
                // Faz a chamada para o método
                _pacienteRepository.Cadastrar(novoPaciente);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// atualiza um paciente pelo id na url da requisição
        /// </summary>
        /// <param name="id"> id do paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">novas informações para esse paciente</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Paciente pacienteAtualizado)
        {
            try
            {
                _pacienteRepository.AtualizarPorId(id, pacienteAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex); 
            }
        }

        /// <summary>
        /// atualiza um determinado dado do paciente, que será definido pelo id na url da requisição
        /// </summary>
        /// <param name="id"> id do paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">novas informações para esse paciente</param>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Paciente pacienteAtualizado)
        {
            try
            {
                _pacienteRepository.AtualizarPorId(id, pacienteAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// deleta um paciente através do seu id
        /// </summary>
        /// <param name="id">id do paciente que será excluido</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _pacienteRepository.Deletar(id);

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
