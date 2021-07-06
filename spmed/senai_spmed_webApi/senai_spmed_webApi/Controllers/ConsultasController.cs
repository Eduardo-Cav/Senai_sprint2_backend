using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmed_webApi.Domains;
using senai_spmed_webApi.Interfaces;
using senai_spmed_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class ConsultasController : ControllerBase
    {

        /// <summary>
        /// _consultaRepository recebe os métodos da interface
        /// </summary>
        private IConsultaRepository _consultaRepository { get; set; }

        /// <summary>
        /// _consultaRepository recebe os métodos de seu repositório
        /// </summary>
        public ConsultasController()
        { 
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Busca uma consulta pelo seu id
        /// </summary>
        /// <param name="id">id da consulta que será buscada</param>
        /// <returns>uma lista de consultas de um usuário</returns>
        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    try
        //    {
        //        // retorna a resposta da requisição fazendo a chamada para o método
        //        return Ok(_consultaRepository.ListarTodas(id));
        //    }
        //    catch (Exception erro)
        //    {
        //        return BadRequest(erro);
        //    }
        

        [HttpGet("{idPaciente}")]
        public IActionResult GetByIdPacient(int idPaciente)
        {
            try
            { 

                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_consultaRepository.ConsultasPaciente(idPaciente));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //[HttpGet("{id}")]
        //public IActionResult GetByIdDoctor(int id)
        //{
        //    try
        //    {
        //        // retorna a resposta da requisição fazendo a chamada para o método
        //        return Ok(_consultaRepository.ConsultasMedico(id));
        //    }
        //    catch (Exception erro)
        //    {
        //        return BadRequest(erro);
        //    }
        //}

        /// <summary>
        /// agenda uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">dados da nova consulta que será agendada</param>
        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            try
            {
                // Faz a chamada para o método
                _consultaRepository.AgendarConsulta(novaConsulta);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// cancela uma consulta
        /// </summary>
        /// <param name="id">id da consulta que será cancelada</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _consultaRepository.Deletar(id);

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
