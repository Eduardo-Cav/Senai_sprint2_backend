using senai_hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista os personagens existentes
        /// </summary>
        /// <returns>uma lista de personagens</returns>
        List<Personagem> ListarPersonagens();

        /// <summary>
        /// busca um personagem através do seu id
        /// </summary>
        /// <param name="id">id do persongem que será buscado</param>
        /// <returns>um personagem buscado</returns>
        Personagem BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto com as informaçõesdo novo personagem</param>
        void Cadastrar(Personagem novoPersonagem);

        /// <summary>
        /// Atualiza o Personagem pela url da requisição
        /// </summary>
        /// <param name="id">id do personagem que será buscado</param>
        /// <param name="pAtualizado">objeto com as novas informações do personagem</param>
        void AtualizarUrl(int id, Personagem pAtualizado);

        /// <summary>
        /// apaga um personagem através do seu id
        /// </summary>
        /// <param name="id">id do personagem que será excluido</param>
        void Deletar(int id);
    }
}
