using senai_spmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// faz o cadastro de um usuário
        /// </summary>
        /// <param name="novoUsuario">informações do novo usuário que será cadastrado</param>
        void Cadastar(Usuario novoUsuario);

        /// <summary>
        /// busca um usuário através do seu id pela url da requisição
        /// </summary>
        /// <param name="id">nome do usuário que será passado</param>
        /// <returns>um usuário</returns>
        Usuario BuscarUsuario(int id);

        /// <summary>
        /// atualiza um usuário pelo id na url da requisição
        /// </summary>
        /// <param name="id"> id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">novas informações para esse usuário</param>
        void AtualizarPorId(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// faz a validação do usuário
        /// </summary>
        /// <param name="email">email do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>um usuário logado, caso exista</returns>
        Usuario Login(string email, string senha);

        /// <summary>
        /// deleta um usuário através do seu id
        /// </summary>
        /// <param name="id">id do usuário que será excluido</param>
        void Deletar(int id);
    }
}
