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
    public class EspecialidadesController : ControllerBase
    {

        // <summary>
        /// _especialidadeRepository recebe os métodos da interface
        /// </summary>
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        /// <summary>
        /// _especialidadeRepository recebe os métodos de seu repositório
        /// </summary>
        public EspecialidadesController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }


        /// <summary>
        /// lista toda as especialidades
        /// </summary>
        /// <returns>uma lista de especialidades</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_especialidadeRepository.ListarEspecialidades());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">objeto com as novas informaçõe que serão passadas</param>

        [HttpPost]
        public IActionResult Post(Especialidade novaEspecialidade)
        {
            try
            {
                // Faz a chamada para o método
                _especialidadeRepository.Cadastrar(novaEspecialidade);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// atualiza uma especialidade, passando o id dela pela url da requisição
        /// </summary>
        /// <param name="id">id da especialidade que será atualizada</param>
        /// <param name="especialidadeAtualizada">objeto com as novas informações</param>

        [HttpPut("{id}")]
        public IActionResult Put(int id, Especialidade especialidadeAtualizada)
        {
            try
            {
                _especialidadeRepository.AtualizarPorId(id, especialidadeAtualizada);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// deleta uma especialidade através do se id
        /// </summary>
        /// <param name="id">id da especialidade que será excluida</param>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _especialidadeRepository.Deletar(id);

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
