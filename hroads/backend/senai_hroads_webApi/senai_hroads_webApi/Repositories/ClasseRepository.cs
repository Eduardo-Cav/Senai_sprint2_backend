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
    public class ClasseRepository : IClasseRepository
    {
        hroadsContext ctx = new hroadsContext();

        /// <summary>
        /// Faz a atualização de uma classe através de um id pela url da requisição
        /// </summary>
        /// <param name="id">id da classse que será atualizada</param>
        /// <param name="classeAtualizada">objeto classeAtualizada com as novas informações</param>
        public void AtualizarUrl(int id, Classe classeAtualizada)
        {
            //busca a classe
            Classe classeBuscada = ctx.Classes.Find(id);

            //se o campo não for nulo, ele substitui a classe buscada pela atualizada
            if (classeAtualizada.Nome != null)
            {
                classeBuscada.Nome = classeAtualizada.Nome;
            }

            //atualiza a classe e manda para o banco
            ctx.Classes.Update(classeBuscada);

            ctx.SaveChanges();
        }


        /// <summary>
        /// busca uma classe através do seu id
        /// </summary>
        /// <param name="id">id da classe que será buscada</param>
        /// <returns>uma classe buscada</returns>
        public Classe BuscarPorId(int id)
        {
            //encontra o id que será passado
            return ctx.Classes.Find(id);
        }

        /// <summary>
        /// faz o cadastro de uma nova classe
        /// </summary>
        /// <param name="novaClasse">objeto classe com as novas informações que serão cadastradas</param>
        public void Cadastrar(Classe novaClasse)
        {
            //faz o cadastro da nova claasse
            ctx.Classes.Add(novaClasse);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma classe pelo seu id
        /// </summary>
        /// <param name="id">id da classe que será excluida</param>
        public void Deletar(int id)
        {
            //procura a classe pelo id
            Classe classeBuscada = ctx.Classes.Find(id);

            //remove a classe definida
            ctx.Classes.Remove(classeBuscada);

            ctx.SaveChanges();


        }

        /// <summary>
        /// Faz uma lista de todas as classes
        /// </summary>
        /// <returns>uma lista de classes</returns>
        public List<Classe> ListarClasses()
        {
            return ctx.Classes.Include(c => c.Personagens).ToList();
        }


    }
}
