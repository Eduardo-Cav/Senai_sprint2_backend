using senai_spmed_webApi.Context;
using senai_spmed_webApi.Domains;
using senai_spmed_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        spmedContext ctx = new spmedContext();

        public void AtualizarId(int id, TipoUsuario tipoAtualizado)
        {
            TipoUsuario tipoBuscado = ctx.TipoUsuarios.Find(id);

            if (tipoAtualizado.NomeTipoUsuario != null)
            {
                tipoBuscado.NomeTipoUsuario = tipoAtualizado.NomeTipoUsuario;
            }

            ctx.TipoUsuarios.Update(tipoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(TipoUsuario novoTipo)
        {
            ctx.TipoUsuarios.Add(novoTipo);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoBuscado = ctx.TipoUsuarios.Find(id);

            ctx.TipoUsuarios.Remove(tipoBuscado);

            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
