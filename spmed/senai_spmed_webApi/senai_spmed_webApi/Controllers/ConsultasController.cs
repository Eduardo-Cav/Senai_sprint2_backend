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

       
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           try
           {
               // retorna a resposta da requisição fazendo a chamada para o método
               return Ok(_consultaRepository.ListarTodas(id));
           }
           catch (Exception erro)
           {
               return BadRequest(erro);
           }
        }


        /// <summary>
        /// busca uma consulta de um determinado paciente
        /// </summary>
        /// <returns>uma consulta retornada</returns>
        
        [Authorize(Roles = "2, 3")]
        [HttpGet("minhas")]
        public IActionResult GetByIdUser()
        {
            try
            { 
                int idUsuario = Convert.ToInt32( HttpContext.User.Claims.First( c => c.Type == JwtRegisteredClaimNames.Jti ).Value );
                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_consultaRepository.ConsultasUsuarios(idUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


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
