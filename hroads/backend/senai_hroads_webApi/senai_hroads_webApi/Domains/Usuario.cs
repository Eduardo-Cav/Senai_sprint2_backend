﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroads_webApi.Domains
{
    /// <summary>
    /// Usuario que será logado 
    /// </summary>
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
