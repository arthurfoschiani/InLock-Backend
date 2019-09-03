using System;
using System.Collections.Generic;

namespace Senai.InLock.WebAPI.Domains
{
    public partial class Estudios
    {
        public int EstudioId { get; set; }
        public string NomeEstudio { get; set; }
        public string PaisOrigem { get; set; }
        public DateTime? DataCriacao { get; set; }
        public int? UsuarioId { get; set; }

        public Usuarios IdUsuarioNavegation { get; set; }
        public ICollection<Jogos> Jogos { get; set; }
    }
}
