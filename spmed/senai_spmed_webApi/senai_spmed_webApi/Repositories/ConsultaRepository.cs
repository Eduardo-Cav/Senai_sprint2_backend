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
    /// <summary>
    /// Repositório relacionado as consultas
    /// </summary>
    public class ConsultaRepository : IConsultaRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        spmedContext ctx = new spmedContext();

   

        public void AgendarConsulta(Consulta novaConsulta)
        {

            ctx.Consultas.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public List<Consulta> ConsultasMedico(int id)
        {
            return ctx.Consultas
                .Include(e => e.IdMedicoNavigation)
                .Include(e => e.IdPacienteNavigation)
                .Include(e => e.IdSituacaoNavigation)
                .Where(e => e.IdMedico == id)
                .Select(e => new Consulta()
                {
                    IdPacienteNavigation = new Paciente()
                    {
                        NomePaciente = e.IdPacienteNavigation.NomePaciente,
                        Cpf = e.IdPacienteNavigation.Cpf,
                        Telefone = e.IdPacienteNavigation.Telefone
                    },

                    IdSituacaoNavigation = new Situacao()
                    {
                        Descricao = e.IdSituacaoNavigation.Descricao
                    },

                    DataAgendamento = e.DataAgendamento,
                    Descricao = e.Descricao
                })
                .ToList();
        }

        public List<Consulta> ConsultasPaciente(int id)
        {
            return ctx.Consultas
                .Include(e => e.IdMedicoNavigation)
                .Include(e => e.IdPacienteNavigation)
                .Include(e => e.IdSituacaoNavigation)
                .Where(e => e.IdPaciente == id)
                .Select(e => new Consulta()
                {

                    IdMedicoNavigation = new Medico()
                    {
                        NomeMedico = e.IdMedicoNavigation.NomeMedico,
                        
                        IdEspecialidadeNavigation = new Especialidade()
                        {
                            NomeEspecialidade = e.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade
                        }
                    },

                   IdSituacaoNavigation = new Situacao()
                   {
                       Descricao = e.IdSituacaoNavigation.Descricao
                   },

                    DataAgendamento = e.DataAgendamento,
                    Descricao = e.Descricao
                })
                .ToList();

            
        }

        public void Deletar(int id)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            ctx.Consultas.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

       
        public List<Consulta> ListarTodas(int id)
        {
            return ctx.Consultas
                .Include(e => e.IdMedicoNavigation)
                .Include(e => e.IdPacienteNavigation)
                .Include(e => e.IdSituacaoNavigation)
                .ToList();
         
        }


    }
}
