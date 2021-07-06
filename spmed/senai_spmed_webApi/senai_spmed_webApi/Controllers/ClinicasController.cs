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
    public class ClinicasController : ControllerBase
    {
        /// <summary>
        /// objeto _clinicaRepository herda os métodos da interface
        /// </summary>
        private IClinicaRepository _clinicaRepository { get; set; }

        /// <summary>
        /// _clinicaRepository recebe os métodos de seu repositório
        /// </summary>
        public ClinicasController()
        { 
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// retorna uma lista com todas as clínicas
        /// </summary>
        /// <returns>uma lista de clinicas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_clinicaRepository.ListarTodas());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca uma clínica pelo seu nome pela url da requisição
        /// </summary>
        /// <param name="nomeClinica">nome da clínica que será buscada</param>
        /// <returns> os dados de uma clínica</returns>
        [HttpGet("{nomeClinica}")]
        public IActionResult GetByName(string nomeClinica)
        {
            try
            {
                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_clinicaRepository.BuscarClinica(nomeClinica));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica">dados da clínica que será cadastrada</param>
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                // Faz a chamada para o método
                _clinicaRepository.CadastrarClinica(novaClinica);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica especialidadeAtualizada)
        {
            try
            {
                _clinicaRepository.AtualizarPorId(id, especialidadeAtualizada);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma clínica através do seu id
        /// </summary>
        /// <param name="id">id da clínica que será excluida</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _clinicaRepository.DeletarClinica(id);

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
