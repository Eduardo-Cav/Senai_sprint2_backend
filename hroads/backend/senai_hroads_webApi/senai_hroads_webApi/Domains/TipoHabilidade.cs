using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroads_webApi.Domains
{
    /// <summary>
    /// Tipo de habilidade de que cada habilidade posssui
    /// </summary>
    public partial class TipoHabilidade
    {
        public TipoHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTipoHabilidade { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
