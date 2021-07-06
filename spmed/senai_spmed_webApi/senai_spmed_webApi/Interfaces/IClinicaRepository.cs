using senai_spmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica">dados da clínica que será cadastrada</param>
        void CadastrarClinica(Clinica novaClinica);

        /// <summary>
        /// Deleta uma clínica através do seu id
        /// </summary>
        /// <param name="id">id da clínica que será excluida</param>
        void DeletarClinica(int id);

        /// <summary>
        /// Busca uma clínica pelo seu nome pela url da requisição
        /// </summary>
        /// <param name="nomeClinica">nome da clínica que será buscada</param>
        /// <returns> os dados de uma clínica</returns>
        Clinica BuscarClinica(string nomeClinica);

        /// <summary>
        /// atualiza os dados da clinica, que será definida pelo id na url da requisção
        /// </summary>
        /// <param name="id"> id da clinica que será atualizada</param>
        /// <param name="clinicaAtualizada">novas informações para essa clínica</param>
        void AtualizarPorId(int id, Clinica clinicaAtualizada);

        /// <summary>
        /// retorna uma lista com todas as clínicas
        /// </summary>
        /// <returns>uma lista de clinicas</returns>
        List<Clinica> ListarTodas();

        

    }
}