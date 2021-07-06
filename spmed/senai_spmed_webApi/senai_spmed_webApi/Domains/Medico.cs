using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmed_webApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consultas = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }
        public int? IdEspecialidade { get; set; }
        public int? IdClinica { get; set; }
        public int? IdUsuario { get; set; }
        public string NomeMedico { get; set; }
        public string Crm { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
