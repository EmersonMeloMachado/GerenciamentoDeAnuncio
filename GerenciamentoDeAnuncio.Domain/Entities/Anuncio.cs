using System;

namespace GerenciamentoDeAnuncio.Domain.Entities
{
    public class Anuncio
    {
        public int AnuncioID { get; set; }
        public string Texto { get; set; }
        public string Audio { get; set; }
        public string Video { get; set; }
        public bool Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
