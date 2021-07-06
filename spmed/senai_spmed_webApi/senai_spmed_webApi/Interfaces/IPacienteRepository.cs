using senai_spmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">informações do novo paciente que será cadastrado</param>
        void Cadastrar(Paciente novoPaciente);

        /// <summary>
        /// lista todos os paciente
        /// </summary>
        /// <returns>uma lista de pacientes</returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// busca um paciente pelo id
        /// </summary>
        /// <param name="id">id do paciente buscado</param>
        /// <returns>um objeto do tipo paciente</returns>
        Paciente BuscarPaciente(int id);

        /// <summary>
        /// atualiza um paciente pelo id na url da requisição
        /// </summary>
        /// <param name="id"> id do paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">novas informações para esse paciente</param>
        void AtualizarPorId(int id, Paciente pacienteAtualizado);

        /// <summary>
        /// deleta um paciente através do seu id
        /// </summary>
        /// <param name="id">id do paciente que será excluido</param>
        void Deletar(int id);
    }
}
