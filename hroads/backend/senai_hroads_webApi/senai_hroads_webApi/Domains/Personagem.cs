using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroads_webApi.Domains
{
    /// <summary>
    /// São os personagens e sua descrição 
    /// </summary>
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public string Nome { get; set; }
        public int? IdClasse { get; set; }
        public int? CapacidadeMaxVida { get; set; }
        public int? CapacidadeMaxMana { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
