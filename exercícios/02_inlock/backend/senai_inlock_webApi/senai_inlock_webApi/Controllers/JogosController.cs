using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_inlock_webApi.Domains;
using senai_inlock_webApi.Interfaces;
using senai_inlock_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Controllers
{
    //a resposta da api será em json
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/jogos
    [Route("api/[controller]")]

    [ApiController]
    public class JogosController : ControllerBase
    {
        /// <summary>
        /// Objeto _jogoRepository que vai herdar todos os métodos da interface
        /// </summary>
        private IJogoRepository _jogoRepository { get; set; }

        /// <summary>
        /// _jogoRepository irá receber os métodos do repositório
        /// </summary>
        public JogosController()
        {
             
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Cria uma lista de jogos
        /// </summary>
        /// <returns>uma lista de jogos um status code 200 OK</returns>
        ///o usuario precisa estar logado para listar os jogos
        
        [Authorize] //verifica se o usuario ta logado
        [HttpGet]
        public IActionResult Get()
        {
            //Lista para receber os dados
            List<JogoDomain> listajogos = _jogoRepository.ListarJogos();

            //retorna  um status code
            return Ok(listajogos);
        }

        /// <summary>
        /// Cadastra um novo jogo 
        /// </summary>
        /// <returns>Um status code 201 - Created</returns>
        ///somente o administrador vai poder cadastrar um usuario
        
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogoDomain novojogo)
        {
            // Faz a chamada para o método .Cadastrar()
            _jogoRepository.Cadastrar(novojogo);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }
    }
}
