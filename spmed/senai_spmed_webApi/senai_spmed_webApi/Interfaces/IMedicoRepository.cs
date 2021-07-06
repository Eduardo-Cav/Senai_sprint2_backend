using senai_spmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// cadastra um novo médico
        /// </summary>
        /// <param name="novoMedico">informações do novo médico que será cadastrado</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// lista todos os médicos
        /// </summary>
        /// <returns>uma lista de médicos</returns>
        List<Medico> ListarTodos();
      
        /// <summary>
        /// busca um médico pelo nome
        /// </summary>
        /// <param name="id">nome do médio que será buscado</param>
        /// <returns></returns>
        Medico BuscarMedico(int id);

        /// <summary>
        /// atualiza dos dados de um médico, definido pelo id na url da requisição
        /// </summary>
        /// <param name="id">id do médico que será passado</param>
        /// <param name="medicoAtualizado">objeto médico atualizado com as informações trocadas</param>
        void AtualizarPorId(int id, Medico medicoAtualizado);

        /// <summary>
        /// deleeta um médico pelo seu id
        /// </summary>
        /// <param name="id">id do médico que será excluido</param>
        void Deletar(int id);
    }
}
