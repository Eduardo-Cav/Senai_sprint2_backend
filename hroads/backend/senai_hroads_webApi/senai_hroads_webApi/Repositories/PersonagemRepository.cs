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
    public class PersonagemRepository : IPersonagemRepository
    {
        hroadsContext ctx = new hroadsContext();

        /// <summary>
        /// Atualiza o Personagem pela url da requisição
        /// </summary>
        /// <param name="id">id do personagem que será buscado</param>
        /// <param name="pAtualizado">objeto com as novas informações do personagem</param>
        public void AtualizarUrl(int id, Personagem pAtualizado)
        {
            Personagem pBuscado = ctx.Personagens.Find(id);

            //se o campo não for nulo, ele substitui os dados do personagem buscado pelos dados atualizados
            if (pAtualizado.Nome != null)
            {
                pBuscado.Nome = pAtualizado.Nome;
            }

            if (pAtualizado.IdClasse != null)
            {
                pBuscado.IdClasse = pAtualizado.IdClasse;
            }

            if (pAtualizado.CapacidadeMaxVida != null)
            {
                pBuscado.CapacidadeMaxVida = pAtualizado.CapacidadeMaxVida;
            }

            if (pAtualizado.CapacidadeMaxMana != null)
            {
                pBuscado.CapacidadeMaxMana = pAtualizado.CapacidadeMaxMana;
            }

            if (pAtualizado.DataAtualizacao != null)
            {
                pBuscado.DataAtualizacao = pAtualizado.DataAtualizacao;
            }

            if (pAtualizado.DataCriacao != null)
            {
                pBuscado.DataCriacao = pAtualizado.DataCriacao;
            }

            //atualiza o personagem e manda para o banco
            ctx.Personagens.Update(pBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// busca um personagem através do seu id
        /// </summary>
        /// <param name="id">id do persongem que será buscado</param>
        /// <returns>um personagem buscado</returns>
        public Personagem BuscarPorId(int id)
        {
            //busca pelo id 
            return ctx.Personagens.Find(id);
        }

        /// <summary>
        /// Cadastra um novo Personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto com as informaçõesdo novo personagem</param>
        public void Cadastrar(Personagem novoPersonagem)
        {
            //cadastra um novo personagem
            ctx.Personagens.Add(novoPersonagem);

            ctx.SaveChanges();
        }

        /// <summary>
        /// apaga um personagem através do seu id
        /// </summary>
        /// <param name="id">id do personagem que será excluido</param>
        public void Deletar(int id)
        {
            //busca o personagem pelo id
            Personagem pDeletado = ctx.Personagens.Find(id);
            
            //remove
            ctx.Personagens.Remove(pDeletado);

            ctx.SaveChanges();
        }


        /// <summary>
        /// Lista os personagens existentes
        /// </summary>
        /// <returns>uma lista de personagens</returns>
        public List<Personagem> ListarPersonagens()
        {
            //chama o método de listar
            return ctx.Personagens.Include(p => p.IdClasseNavigation).ToList();
        }
    }
}
