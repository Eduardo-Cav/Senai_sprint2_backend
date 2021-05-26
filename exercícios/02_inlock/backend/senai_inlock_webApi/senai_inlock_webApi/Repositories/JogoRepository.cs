using senai_inlock_webApi.Domains;
using senai_inlock_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "data source = DESKTOP-54L6JI1\\SQLEXPRESS; initial catalog = inlock_games_tarde; user id = sa; pwd = Xxplosive12";
        
        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogoC">contém as informações para o cadastro do novo jogo</param>
        public void Cadastrar(JogoDomain jogoC)
        {
            using (SqlConnection conex = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO jogo(nomeJogo, descricao, dataLancamento, valor, idEstudio) VALUES (@nome, @descricao, @dataLancamento, @valor, @idEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, conex))
                {
                    //atribui os valores para os pârametros
                    cmd.Parameters.AddWithValue("@nome", jogoC.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", jogoC.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", jogoC.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", jogoC.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", jogoC.idEstudio);

                    conex.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Mostra uma lista de jogos
        /// </summary>
        /// <returns>lista de jogos</returns>
        public List<JogoDomain> ListarJogos()
        {
            //Lista de generos onde os dados serão armazenados
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection conex = new SqlConnection(stringConexao))
            {
                //query que será executada
                string queryList = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM jogo";

                conex.Open();

                //declara  o rdr para percorrer as linhas
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryList, conex))
                {
                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //enquanto houver linhas para serem lidas
                    while (rdr.Read())
                    {
                        //crio um objeto de jogo domain 
                        JogoDomain jogos = new JogoDomain()
                        {
                            //atribui a propriedade idJogo a colona "idJogo" no banco de dados, e assim respectivamente
                            idJogo = Convert.ToInt32(rdr["idJogo"]),
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descricao"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),
                            valor = Convert.ToDecimal(rdr["valor"]),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"])
                        };

                        //adiciona o jogo na lista
                        listaJogos.Add(jogos);
                    }

                }
            }
                        return listaJogos;
        }
    }
}
