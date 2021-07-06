using senai_spmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">objeto com as novas informaçõe que serão passadas</param>
        void Cadastrar(Especialidade novaEspecialidade);

        /// <summary>
        /// atualiza uma especialidade, passando o id dela pela url da requisição
        /// </summary>
        /// <param name="id">id da especialidade que será atualizada</param>
        /// <param name="especialidadeAtualizada">objeto com as novas informações</param>
        void AtualizarPorId(int id, Especialidade especialidadeAtualizada);

        /// <summary>
        /// lista toda as especialidades
        /// </summary>
        /// <returns>uma lista de especialidades</returns>
        List<Especialidade> ListarEspecialidades();

        /// <summary>
        /// deleta uma especialidade através do se id
        /// </summary>
        /// <param name="id">id da especialidade que será excluida</param>
        void Deletar(int id);
    }
}
