using senai_spmed_webApi.Context;
using senai_spmed_webApi.Domains;
using senai_spmed_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        spmedContext ctx = new spmedContext();

        public void AtualizarPorId(int id, Especialidade especialidadeAtualizada)
        {
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);

            if (especialidadeBuscada.NomeEspecialidade != null)
            {
                especialidadeBuscada.NomeEspecialidade = especialidadeAtualizada.NomeEspecialidade;
            }

            ctx.Especialidades.Update(especialidadeBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Especialidade novaEspecialidade)
        {
            ctx.Especialidades.Add(novaEspecialidade);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);

            ctx.Especialidades.Remove(especialidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Especialidade> ListarEspecialidades()
        {
            return ctx.Especialidades.ToList();
        }
    }
}
