using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroads_webApi.Domains
{
    /// <summary>
    /// São as classes existentes no jogo
    /// </summary>
    public partial class Classe
    {
        public Classe()
        {
            Personagens = new HashSet<Personagem>();
        }

        public int IdClasse { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Personagem> Personagens { get; set; }
    }
}
