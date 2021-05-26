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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        hroadsContext ctx = new hroadsContext();

        public void AtualizarUrl(int id, Habilidade habilidadeAtualizada)
        {
           Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            //se o campo não for nulo, ele substitui a classe buscada pela atualizada
            if (habilidadeAtualizada.Nome != null)
            {
                habilidadeBuscada.Nome = habilidadeAtualizada.Nome;
            }

            //atualiza a habilidade e manda para o banco
            ctx.Habilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// buscar uma habilidade por id
        /// </summary>
        /// <param name="id">id da habilidade que será buscada</param>
        /// <returns></returns>
        public Habilidade BuscarPorId(int id)
        {
            return ctx.Habilidades.Find(id);
        }

        /// <summary>
        /// cadastra uma nova habiliadade
        /// </summary>
        /// <param name="novaHabilidade">informações da habilidade que será cadastrada</param>
        public void Cadastrar(Habilidade novaHabilidade)
        {
            //Cadastra uma nova habilidade
            ctx.Habilidades.Add(novaHabilidade);
             
            //salva as mudanças no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de habilidade
        /// </summary>
        /// <param name="id">id do tipo que será passado</param>
        public void Deletar(int id)
        {
            //busca a habilidade pelo id
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            //remove a habilidade
            ctx.Habilidades.Remove(habilidadeBuscada);

            //salva a alteração no banco
            ctx.SaveChanges();
        }


        /// <summary>
        /// cria uma lista de habilidades
        /// </summary>
        /// <returns>uma lista de habilidades</returns>
        public List<Habilidade> ListarHabilidades()
        {
            //faz a chamada para o método de listar
            return ctx.Habilidades.Include(p => p.IdThNavigation).ToList();
        }
    }
}
    
