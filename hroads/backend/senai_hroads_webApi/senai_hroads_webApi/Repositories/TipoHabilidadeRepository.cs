using senai_hroads_webApi.Contexts;
using senai_hroads_webApi.Domains;
using senai_hroads_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto onde serão chamados os métodos do ef core
        /// </summary>
        hroadsContext ctx = new hroadsContext();

        /// <summary>
        /// Atualiza um tipo de habilidade pela url na requisição
        /// </summary>
        /// <param name="id">id do tipo que será atualizado</param>
        /// <param name="thAtualizado">as novas informações que esse tipo irá conter</param>
        public void AtualizarUrl(int id, TipoHabilidade thAtualizado)
        {
            //busca o tipo
            TipoHabilidade tipoBuscado = ctx.TipoHabilidades.Find(id);

            //se o campo não for nulo, ele substitui o tipo buscado pelo atualizado
            if (tipoBuscado.Nome != null)
            {
                tipoBuscado.Nome = thAtualizado.Nome;
            }

            //atualiza o tipo e manda para o banco
            ctx.TipoHabilidades.Update(tipoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a busca de um tipo de habilidade através do id
        /// </summary>
        /// <param name="id">id do tipo que será buscado</param>
        /// <returns>um tipo de habilidade</returns>
        public TipoHabilidade BuscarPorId(int id)
        {
            //faz a chamada para o método 
            return ctx.TipoHabilidades.Find(id);
        }

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTH">Objeto com as novas informações que serão cadastradas</param>
        public void Cadastrar(TipoHabilidade novoTH)
        {
            //Cadastra o novo tipo
            ctx.TipoHabilidades.Add(novoTH);

            //salva o que foi feito no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de habilidade
        /// </summary>
        /// <param name="id">id do tipo que será passado</param>
        public void Deletar(int id)
        {
            //busca o id que será deletado
            TipoHabilidade thBuscado = ctx.TipoHabilidades.Find(id);

            //exclui o id
            ctx.TipoHabilidades.Remove(thBuscado);

            ctx.SaveChanges();
        }


        /// <summary>
        /// Lista todos os tipos de habilidade
        /// </summary>
        /// <returns>uma lista de tipos habilidades</returns>
        public List<TipoHabilidade> ListarTipos()
        {
            //chama o método de listar
            return ctx.TipoHabilidades.ToList();
        }
    }
}
