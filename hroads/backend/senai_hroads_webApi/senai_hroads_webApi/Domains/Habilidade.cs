using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroads_webApi.Domains
{
    /// <summary>
    /// As habilidades do hroads
    /// </summary>
    public partial class Habilidade
    {
        public int IdHabilidade { get; set; }
        public int? IdTh { get; set; }
        public string Nome { get; set; }

        public virtual TipoHabilidade IdThNavigation { get; set; }
    }
}
