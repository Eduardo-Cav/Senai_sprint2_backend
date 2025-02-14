﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmed_webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consultas = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }
        public int? IdUsuario { get; set; }
        public string NomePaciente { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
