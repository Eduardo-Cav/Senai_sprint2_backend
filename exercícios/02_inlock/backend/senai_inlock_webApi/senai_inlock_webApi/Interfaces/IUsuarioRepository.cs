using senai_inlock_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Busca um usuário que tenha um login através do email e da senha
        /// </summary>
        /// <param name="email">email que será buscado</param>
        /// <param name="senha">senha que será buscada</param>
        /// <returns></returns>
        UsuarioDomain BuscarEmailSenha(string email, string senha);
    }
}
