using senai_inlock_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Faz uma lista de todos os jogos
        /// </summary>
        /// <returns>Uma lista de  jogos</returns>
        List<JogoDomain> ListarJogos();

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogoC">jogo que será cadastrado</param>
        void Cadastrar(JogoDomain jogoC);

    }
}
