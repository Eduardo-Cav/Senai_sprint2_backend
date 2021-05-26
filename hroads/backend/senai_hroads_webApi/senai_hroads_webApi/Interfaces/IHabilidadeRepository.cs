using senai_hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        /// cria uma lista de habilidades
        /// </summary>
        /// <returns>uma lista de habilidades</returns>
        List<Habilidade> ListarHabilidades();

        /// <summary>
        /// buscar uma habilidade por id
        /// </summary>
        /// <param name="id">id da habilidade que será buscada</param>
        /// <returns></returns>
        Habilidade BuscarPorId(int id);

        /// <summary>
        /// cadastra uma nova habiliadade
        /// </summary>
        /// <param name="novaHabilidade">informações da habilidade que será cadastrada</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// atualiza uma habilidade pela url da requisição
        /// </summary>
        /// <param name="id">id da habilidade que será atualizada</param>
        /// <param name="hAtualizada">novas informações da habilidade</param>
        void AtualizarUrl(int id, Habilidade habilidadeAtualizada);

        /// <summary>
        /// deleta uma habilidade através do id
        /// </summary>
        /// <param name="id">id da habilidade que será excluida</param>
        void Deletar(int id);
    }
}
