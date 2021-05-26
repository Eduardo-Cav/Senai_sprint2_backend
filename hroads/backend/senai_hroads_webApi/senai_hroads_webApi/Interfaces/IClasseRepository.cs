using senai_hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    interface IClasseRepository
    {
        /// <summary>
        /// Faz uma lista de todas as classes
        /// </summary>
        /// <returns>uma lista de classes</returns>
        List<Classe> ListarClasses();

        /// <summary>
        /// busca uma classe através do seu id
        /// </summary>
        /// <param name="id">id da classe que será buscada</param>
        /// <returns>uma classe buscada</returns>
        Classe BuscarPorId(int id);

        /// <summary>
        /// faz o cadastro de uma nova classe
        /// </summary>
        /// <param name="novaClasse">objeto classe com as novas informações que serão cadastradas</param>
        void Cadastrar(Classe novaClasse);

        /// <summary>
        /// Faz a atualização de uma classe através de um id pela url da requisição
        /// </summary>
        /// <param name="id">id da classse que será atualizada</param>
        /// <param name="classeAtualizada">objeto classeAtualizada com as novas informações</param>
        void AtualizarUrl(int id, Classe classeAtualizada);

        /// <summary>
        /// Deleta uma classe pelo seu id
        /// </summary>
        /// <param name="id">id da classe que será excluida</param>
        void Deletar(int id);


    }
}
