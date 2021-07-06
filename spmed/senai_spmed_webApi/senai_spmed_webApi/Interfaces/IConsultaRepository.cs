using senai_spmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// agenda uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">dados da nova consulta que será agendada</param>
        void AgendarConsulta(Consulta novaConsulta);

        /// <summary>
        /// deleta uma consulta
        /// </summary>
        /// <param name="id">id da consulta que será deleta</param>
        void Deletar(int id);

        /// <summary>
        /// Lista as consultas de um paciente pelo seu id
        /// </summary>
        /// <param name="id">id da consulta que será visualizada</param>
        /// <returns>uma lista de consultas</returns>
     
        List<Consulta> ListarTodas(int id);

        /// <summary>
        /// lista as consultas de um determinado paciente
        /// </summary>
        /// <returns>uma lista de consultas</returns>
        List<Consulta> ConsultasUsuarios(int id);

    }
}
