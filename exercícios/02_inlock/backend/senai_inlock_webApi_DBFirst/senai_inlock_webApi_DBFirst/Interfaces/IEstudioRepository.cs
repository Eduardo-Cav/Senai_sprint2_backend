using senai_inlock_webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi_DBFirst.Interfaces
{
    /// <summary>
    /// Interface responsável pelo EstudioRepository
    /// </summary>
    interface IEstudioRepository
    {
        /// <summary>
        /// lista os estúdios
        /// </summary>
        /// <returns>uma lista de estúdios</returns>
        List<Estudio> ListarEstudios();

        /// <summary>
        /// Busca um estúdio por um id
        /// </summary>
        /// <param name="id">id do estúdio que será buscado</param>
        /// <returns>um estúdio</returns>
        Estudio BuscarPorId(int id);

        /// <summary>
        /// Faz o cadastro de um novo estúdio
        /// </summary>
        /// <param name="estudio">Informações do estúdio que será cadastrado</param>
        void Cadastrar(Estudio estudio);

        /// <summary>
        /// atualiza um estúdio existente
        /// </summary>
        /// <param name="id">id do estúdio que será atualizado</param>
        /// <param name="estudioAtualizado">informações do estúdio que vai ser atualizado</param>
        void AtualizarUrl(int id, Estudio estudioAtualizado);


        /// <summary>
        /// Deleta um determinado estúdio através do seu id
        /// </summary>
        /// <param name="id">id do estúdio que será excluido</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os estúdios e seus respectivos jogos
        /// </summary>
        /// <returns>uma lista de estúdio e seus jogos</returns>
        List<Estudio> ListarJogos();




    }
}
