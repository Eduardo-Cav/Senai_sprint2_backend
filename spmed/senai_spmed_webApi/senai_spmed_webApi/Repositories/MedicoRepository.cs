using Microsoft.EntityFrameworkCore;
using senai_spmed_webApi.Context;
using senai_spmed_webApi.Domains;
using senai_spmed_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        spmedContext ctx = new spmedContext();

        public void AtualizarPorId(int id, Medico medicoAtualizado)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            if (medicoAtualizado.NomeMedico != null)
            {
                medicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;
            }

            if (medicoAtualizado.IdEspecialidade != null)
            {
                medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;

            }

            if (medicoAtualizado.IdClinica != null)
            {
                medicoBuscado.IdClinica = medicoAtualizado.IdClinica;

            }

            if (medicoAtualizado.Crm != null)
            {
                medicoBuscado.Crm = medicoAtualizado.Crm;

            }

            if (medicoAtualizado.Consultas != null)
            {
                medicoBuscado.Consultas = medicoAtualizado.Consultas;

            }

            ctx.Update(medicoBuscado);

            ctx.SaveChanges();
        }
        public Medico BuscarMedico(int id)
        {
            return ctx.Medicos
                .Select(e => new Medico {
                    IdMedico = e.IdMedico,
                    IdEspecialidade = e.IdEspecialidade,
                    IdClinica = e.IdClinica,
                    NomeMedico = e.NomeMedico,
                    Crm = e.Crm,

                    IdEspecialidadeNavigation = new Especialidade()
                    {
                        NomeEspecialidade = e.IdEspecialidadeNavigation.NomeEspecialidade
                    }

                })
                .FirstOrDefault(e => e.IdMedico == id);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos
                .Include( e => e.IdEspecialidadeNavigation)
                
                .ToList();
        }
    }
}
