using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeAnuncio.MVC.ViewModels
{
    public class AnuncioViewModel
    {
        [Key]
        public int AnuncioID { get; set; }

        [Required(ErrorMessage ="Preencha o campo nome")]
        [MaxLength(300,ErrorMessage ="Maximo{0} Caracteres")]
        [MinLength(2,ErrorMessage = "minimo{0} Caracteres")]
        public string Texto { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(200, ErrorMessage = "Maximo{0} Caracteres")]
        [MinLength(2, ErrorMessage = "minimo{0} Caracteres")]
        public string Audio { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(200, ErrorMessage = "Maximo{0} Caracteres")]
        [MinLength(2, ErrorMessage = "minimo{0} Caracteres")]
        public string Video { get; set; }

        public bool Status { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DataAlteracao { get; set; }
    }
}