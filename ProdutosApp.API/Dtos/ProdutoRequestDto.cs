using System.ComponentModel.DataAnnotations;

namespace ProdutosApp.API.Dtos {
    public class ProdutoRequestDto {

        [MinLength(3, ErrorMessage = "O nome do produto deve conter pelo menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome do produto deve conter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string? Nome { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço do produto deve ser um valor maior do que zero.")]
        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        public decimal? Preco { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "A quantidade do produto deve ser um valor maior ou igual a zero.")]
        [Required(ErrorMessage = "A quantidade do produto é obrigatória.")]
        public int? Quantidade { get; set; }

        [Range(1, 5, ErrorMessage = "A categoria do produto deve ser um valor entre {1} e {2}")]
        [Required(ErrorMessage = "A categoria do produto é obrigatória.")]
        public int? Categoria { get; set; }

        [Range(1, 3, ErrorMessage = "O status do produto deve ser um valor entre {1} e {2}")]
        [Required(ErrorMessage = "O status do produto é obrigatório.")]
        public int? Status { get; set; }
    }
}
