using senai_spmed_webApi.Context;
using senai_spmed_webApi.Domains;
using senai_spmed_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        // <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        spmedContext ctx = new spmedContext();

        public void AtualizarPorId(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            //se outro email for passado em usuarioAtualizado
            if (usuarioAtualizado.Email != null)
            {
                //o valor atual de usuarioBuscado vai passar a ser o que eu definir em usuarioAtualizado
                usuarioBuscado.Email = usuarioAtualizado.Email;

            }

            //se outra senha for passada em usuarioAtualizado
            if (usuarioAtualizado.Senha != null)
            {
                //o valor atual de usuarioBuscado vai passar a ser o que eu definir em usuarioAtualizado
                usuarioBuscado.Senha = usuarioAtualizado.Senha;

            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarUsuario(int id)
        {
            return ctx.Usuarios
                .Select(e => new Usuario
                {
                    IdUsuario = e.IdUsuario,
                    IdTipoUsuario = e.IdTipoUsuario,
                    Email = e.Email,

                    IdTipoUsuarioNavigation = new TipoUsuario()
                    {
                        IdTipoUsuario = e.IdTipoUsuarioNavigation.IdTipoUsuario,
                        NomeTipoUsuario = e.IdTipoUsuarioNavigation.NomeTipoUsuario
                    }
                })
                .FirstOrDefault(e => e.IdUsuario == id);
        }


 
        public void Cadastar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }


     
        public void Deletar(int id)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

  
        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }
    }
}
