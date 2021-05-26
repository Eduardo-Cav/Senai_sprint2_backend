using senai_inlock_webApi.Domains;
using senai_inlock_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "data source = DESKTOP-54L6JI1\\SQLEXPRESS; initial catalog = inlock_games_tarde; user id = sa; pwd = Xxplosive12";

        /// <summary>
        /// Válida um usuário através do seu email e senha
        /// </summary>
        /// <param name="email">email que será buscada</param>
        /// <param name="senha">senha que será buscada</param>
        /// <returns>Um objeto UsuarioDomain</returns>
        public UsuarioDomain BuscarEmailSenha(string email, string senha)
        {
            //define a conexão com o banco passandoa strind de conexão conex
            using (SqlConnection conex = new SqlConnection(stringConexao))
            {
                //query que será executada
                string queryLogin = "SELECT idUsuario, email, senha, idTipoUsuario FROM usuario WHERE email = @email AND senha = @senha";

                //comando passando a query e a conexão com o banco como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryLogin, conex))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    //abre a conexão com o banco
                    conex.Open();

                    //executa o comando, lê os dados da tabela do bd e armazena no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    //se o usuario for encontrado
                    if (rdr.Read())
                    {
                        // um objeto de UsuarioDomain será criado
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"])                          
                        };

                        //e será retornado
                        return usuarioBuscado;
                    }
                }

                return null;
            }
        }
    }
}
