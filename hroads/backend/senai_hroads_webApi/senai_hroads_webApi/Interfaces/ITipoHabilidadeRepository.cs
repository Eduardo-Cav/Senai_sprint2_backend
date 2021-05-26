using senai_hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
  
        /// <summary>
        /// Lista todos os tipos de habilidade
        /// </summary>
        /// <returns>uma lista de tipos habilidades</returns>
        List<TipoHabilidade> ListarTipos();

        /// <summary>
        /// Faz a busca de um tipo de habilidade através do id
        /// </summary>
        /// <param name="id">id do tipo que será buscado</param>
        /// <returns>um tipo de habilidade</returns>
        TipoHabilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTH">Objeto com as novas informações que serão cadastradas</param>
        void Cadastrar(TipoHabilidade novoTH);

        /// <summary>
        /// Atualiza um tipo de habilidade pela url na requisição
        /// </summary>
        /// <param name="id">id do tipo que será atualizado</param>
        /// <param name="thAtualizado">as novas informações que esse tipo irá conter</param>
        void AtualizarUrl(int id, TipoHabilidade thAtualizado);

        /// <summary>
        /// Deleta um tipo de habilidade
        /// </summary>
        /// <param name="id">id do tipo que será passado</param>
        void Deletar(int id);
    }
}
