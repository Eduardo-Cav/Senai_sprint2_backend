using senai_hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// faz a validação do usuário
        /// </summary>
        /// <param name="email">email que o usuário irá passar</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns></returns>
        Usuario BuscarEmailSenha(string email, string senha);

        /// <summary>
        /// lista todos os usuários
        /// </summary>
        /// <returns>uma lista de usuários</returns>
        List<Usuario> ListarUsuarios();

        /// <summary>
        /// Faz a busca de um usuário através do id
        /// </summary>
        /// <param name="id">id do usuário que será buscado</param>
        /// <returns>um usuário</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto com as novas informações que serão cadastradas</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um usuário pela url na requisição
        /// </summary>
        /// <param name="id">id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">as novas informações que esse usuário irá conter</param>
        void AtualizarUrl(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">id do usuário que será passado</param>
        void Deletar(int id);
    }
}
