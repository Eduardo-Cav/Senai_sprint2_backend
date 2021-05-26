using Microsoft.EntityFrameworkCore;
using senai_hroads_webApi.Contexts;
using senai_hroads_webApi.Domains;
using senai_hroads_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        hroadsContext ctx = new hroadsContext();

        /// <summary>
        /// Atualiza um usuário pela url na requisição
        /// </summary>
        /// <param name="id">id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">as novas informações que esse usuário irá conter</param>
        public void AtualizarUrl(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            //se o campo não for nulo, ele substitui o usuario buscado pelo atualizado
            if (usuarioBuscado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            if (usuarioBuscado.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            if (usuarioBuscado.IdTipoUsuario != null)
            {
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            }

            //atualiza usuario e manda para o banco
            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// faz a validação do usuário
        /// </summary>
        /// <param name="email">email que o usuário irá passar</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns></returns>
        public Usuario BuscarEmailSenha(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(a => a.Email == email && a.Senha == senha);     
        }

        /// <summary>
        /// Faz a busca de um usuário através do id
        /// </summary>
        /// <param name="id">id do usuário que será buscado</param>
        /// <returns>um usuário</returns>
        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Find(id);
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto com as novas informações que serão cadastradas</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            //Cadastra o novo usuário
            ctx.Usuarios.Add(novoUsuario);

            //salva o que foi feito no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">id do usuário que será passado</param>
        public void Deletar(int id)
        {
            //busca o id do usuário que será deletado
           Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            //exclui o usuário 
            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// lista todos os usuários
        /// </summary>
        /// <returns>uma lista de usuários</returns>
        public List<Usuario> ListarUsuarios()
        {
            
            //faz a chamada para o método de listar
            return ctx.Usuarios.Include(p => p.IdTipoUsuarioNavigation).ToList();
            
        }
    }
}
    
