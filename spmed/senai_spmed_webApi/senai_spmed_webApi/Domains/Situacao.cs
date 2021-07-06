using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmed_webApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consultas = new HashSet<Consulta>();
        }

        public int IdSituacao { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
