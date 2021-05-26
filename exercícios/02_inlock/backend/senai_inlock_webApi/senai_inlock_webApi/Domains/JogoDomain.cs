using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }

        [Required(ErrorMessage = "O nome do jogo tem que ser preenchido")]
        public string nomeJogo { get; set; }

        public string descricao { get; set; }

        [DataType(DataType.Date)]
        public DateTime dataLancamento { get; set; }

        public decimal valor { get; set; }

        public int idEstudio { get; set; }

    }
}
