using Microsoft.EntityFrameworkCore;
using senai_inlock_webApi_DBFirst.Contexts;
using senai_inlock_webApi_DBFirst.Domains;
using senai_inlock_webApi_DBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi_DBFirst.Repositories
{
    /// <summary>
    /// responsável pelo repositório de estúdio
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Objeto contexto onde serão chamados os métodos do ef core
        /// </summary>
        inLockContext ctx = new inLockContext();

        /// <summary>
        /// atualiza um estúdio existente
        /// </summary>
        /// <param name="id">id do estúdio que será atualizado</param>
        /// <param name="estudioAtualizado">informações do estúdio que vai ser atualizado</param>
        public void AtualizarUrl(int id, Estudio estudioAtualizado)
        {
            //Faz a busca do estudio pelo id
            Estudio estudioBuscado = ctx.Estudios.Find(id);

            //se o estúdio não for null, ele substitui o nome buscado pelo atualizado
            if (estudioAtualizado.NomeEstudio != null)
            {
                estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
            }

            //faz a atualização do estudio e manda para o banco, como um UPDATE
            ctx.Estudios.Update(estudioBuscado);

            //salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um estúdio por um id
        /// </summary>
        /// <param name="id">id do estúdio que será buscado</param>
        /// <returns>um estúdio</returns>
        public Estudio BuscarPorId(int id)
        {
            //retorna o primeiro estúdio encotrado para o id informado
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        /// <summary>
        /// Faz o cadastro de um novo estúdio
        /// </summary>
        /// <param name="estudio">Informações do estúdio que será cadastrado</param>
        public void Cadastrar(Estudio estudio)
        {
            //adiciona o novo estúdio
            ctx.Estudios.Add(estudio);

            //salva as informações no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um determinado estúdio através do seu id
        /// </summary>
        /// <param name="id">id do estúdio que será excluido</param>
        public void Deletar(int id)
        {
            //faz a busca do estúdio pelo id
            Estudio estudioBuscado = ctx.Estudios.Find(id);

            //deleta o estúdio
            ctx.Estudios.Remove(estudioBuscado);

            //salva as alterações
            ctx.SaveChanges();
        }

        public List<Estudio> ListarEstudios()
        {
            //retorna uma lista com as informações de estúdio
            return ctx.Estudios.ToList();
        }

        /// <summary>
        /// Lista todos os estúdios e seus respectivos jogos
        /// </summary>
        /// <returns>uma lista de estúdio e seus jogos</returns>
        public List<Estudio> ListarJogos()
        {
            //retorna a lista de estúdios com os respectivos jogos de cada um
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
