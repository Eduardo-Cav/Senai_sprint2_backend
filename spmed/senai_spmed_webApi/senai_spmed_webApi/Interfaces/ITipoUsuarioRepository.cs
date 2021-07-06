using senai_spmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipo">objeto com as novas informações que serão cadastradas</param>
        void Cadastrar(TipoUsuario novoTipo);

        /// <summary>
        /// atualiza um tipo de usuário pelo seu id
        /// </summary>
        /// <param name="id">id do tipo de usuário que será atualizado</param>
        /// <param name="tipoAtualizado">objeto com as novas informações</param>
        void AtualizarId(int id, TipoUsuario tipoAtualizado);

        /// <summary>
        /// lista todos os tipos
        /// </summary>
        /// <returns>uma lista de tipos de usuario</returns>
        List<TipoUsuario> ListarTodos();

       /// <summary>
       /// deleta um tipo através do seu id
       /// </summary>
       /// <param name="id">id do tipo que será excluido</param>
        void Deletar(int id);
    }
}
