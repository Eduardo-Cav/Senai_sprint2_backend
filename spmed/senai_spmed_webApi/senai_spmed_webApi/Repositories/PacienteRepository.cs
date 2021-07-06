using senai_spmed_webApi.Context;
using senai_spmed_webApi.Domains;
using senai_spmed_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        spmedContext ctx = new spmedContext();

        /// <summary>
        /// atualiza um usuario pelo id na url da requisição
        /// </summary>
        /// <param name="id"> id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">novas informações para esse usuário</param>

        public void AtualizarPorId(int id, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            if (pacienteAtualizado.DataNascimento != DateTime.Now)
            {
                pacienteBuscado.DataNascimento = pacienteAtualizado.DataNascimento;
            }

            if (pacienteAtualizado.NomePaciente != null)
            {
                pacienteBuscado.NomePaciente = pacienteAtualizado.NomePaciente;
            }

            if (pacienteAtualizado.Rg != null)
            {
                pacienteBuscado.Rg = pacienteAtualizado.Rg;
            }

            if (pacienteAtualizado.Cpf != null)
            {
                pacienteBuscado.Cpf = pacienteAtualizado.Cpf;
            }

            if (pacienteAtualizado.Telefone != null)
            {
                pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
            }

            if (pacienteAtualizado.Endereco != null)
            {
                pacienteBuscado.Endereco = pacienteAtualizado.Endereco;
            }

            ctx.Update(pacienteBuscado);

            ctx.SaveChanges();
        }


        public Paciente BuscarPaciente(int id)
        {
            return ctx.Pacientes.FirstOrDefault(e => e.IdPaciente == id);
        }


        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }



        public void Deletar(int id)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            ctx.Pacientes.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }

 
    }
}
