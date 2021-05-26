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

    public class ClassesController : ControllerBase
    {
        //cria um objeto para receber os métodos da interface
        private IClasseRepository _classeRepository { get; set; }

        public ClassesController()
        {
            //atribui os métodos do repositório em _classeRepository
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>uma lista de classes e um status code</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            //retorna um ok e o método de listar
            return Ok(_classeRepository.ListarClasses());
        }

        /// <summary>
        /// busca um gênero pelo seu determinado id
        /// </summary>
        /// <param name="id">id do gênero que será buscado</param>
        /// <returns>um gênero e um status code</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_classeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// faz o cadastro de um usuário 
        /// </summary>
        /// <param name="novaClasse">novas informações que serão cadastradas</param>
        /// <returns>um usuário criado e um status code</returns>

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Classe novaClasse)
        {
            //faz a chamada para o método de cadastrar
            _classeRepository.Cadastrar(novaClasse);

            return StatusCode(201);
        }
        /// <summary>
        /// atualiza uma classe existente
        /// </summary>
        /// <param name="id">id da classe que será encontrada e atualizada</param>
        /// <param name="classeAtualizada">os novos dados dessa classe</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Classe classeAtualizada)
        {
            Classe classeBuscada = _classeRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (classeBuscada == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Gênero não encontrado!",
                            erro = true
                        }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarUrl()
                _classeRepository.AtualizarUrl(id, classeAtualizada);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception codErro)
            {
                // Retorna um status code 400 - BadRequest e o código do erro
                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Apaga uma classe
        /// </summary>
        /// <param name="id">id da classe que será excluida</param>
        /// <returns>um status code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //chama o método de deletar
            _classeRepository.Deletar(id);

            return StatusCode(204);
        }
    }

}
