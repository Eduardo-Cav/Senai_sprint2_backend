using senai_spmed_webApi.Context;
using senai_spmed_webApi.Domains;
using senai_spmed_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
      
        spmedContext ctx = new spmedContext();

        //public string Endereco { get; set; }
        //public TimeSpan HorarioAbertura { get; set; }
        //public TimeSpan HorarioFechamento { get; set; }
        //public string Cnpj { get; set; }
        //public string NomeFantasia { get; set; }
        //public string RazaoSocial { get; set; }
        public void AtualizarPorId(int id, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            if (clinicaAtualizada.Endereco != null)
            {
                clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
            }

            //se horario abertura convertido para string for diferente de null
            if (clinicaAtualizada.HorarioAbertura.ToString() != null)
            {
                //atualiza com os valores inseridos
                clinicaBuscada.HorarioAbertura = clinicaAtualizada.HorarioAbertura;
            }

            if (clinicaAtualizada.HorarioFechamento.ToString() != null)
            {
                clinicaBuscada.HorarioFechamento = clinicaAtualizada.HorarioFechamento;
            }

            if (clinicaAtualizada.Cnpj != null)
            {
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
            }

            if (clinicaAtualizada.NomeFantasia != null)
            {
                clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
            }

            if (clinicaAtualizada.RazaoSocial != null)
            {
                clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
            }

            ctx.Clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarClinica(string nomeClinica)
        {
            return ctx.Clinicas.FirstOrDefault(e => e.NomeFantasia == nomeClinica);
        }

      
        public void CadastrarClinica(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

    
        public void DeletarClinica(int id)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            ctx.Clinicas.Remove(clinicaBuscada);

            ctx.SaveChanges();
        }

    
        public List<Clinica> ListarTodas()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
