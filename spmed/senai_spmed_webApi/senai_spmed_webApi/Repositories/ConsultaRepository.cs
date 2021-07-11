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


        public List<Consulta> ConsultasUsuarios(int idUsuario)
        {
            return ctx.Consultas
                .Include(e => e.IdMedicoNavigation)
                .Include(e => e.IdPacienteNavigation)
                .Include(e => e.IdSituacaoNavigation)
                .Where(e => e.IdPacienteNavigation.IdUsuario == idUsuario || e.IdMedicoNavigation.IdUsuario == idUsuario)
                .Select(e => new Consulta()
                {
                    IdConsulta = e.IdConsulta,

                    IdMedicoNavigation = new Medico()
                    {
                        IdMedico = e.IdMedicoNavigation.IdMedico,
                        IdUsuario = e.IdMedicoNavigation.IdUsuario,
                        NomeMedico = e.IdMedicoNavigation.NomeMedico,
                        
                        IdEspecialidadeNavigation = new Especialidade()
                        {
                            IdEspecialidade = e.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                            NomeEspecialidade = e.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade
                        }
                    },

                    IdPacienteNavigation = new Paciente()
                    {
                        IdPaciente = e.IdPacienteNavigation.IdPaciente,
                        IdUsuario = e.IdPacienteNavigation.IdUsuario,
                        NomePaciente = e.IdPacienteNavigation.NomePaciente
                        
                    },

                   IdSituacaoNavigation = new Situacao()
                   {
                       IdSituacao = e.IdSituacaoNavigation.IdSituacao,
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
