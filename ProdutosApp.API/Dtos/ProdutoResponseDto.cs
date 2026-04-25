using Microsoft.EntityFrameworkCore.Query.Internal;
using ProdutosApp.Domain.Enums;

namespace ProdutosApp.API.Dtos {
    public class ProdutoResponseDto {

        public Guid Id { get; set; }

        public string? Nome { get; set; }

        public decimal? Preco { get; set; }

        public int? Quantidade { get; set; }

        public decimal? Total { get; set; }
        
        public DateTime DataHoraCadastro { get; set; }

        public EnumDto? Categoria { get; set; }

        public EnumDto? Status { get; set; }

    }

    public class EnumDto {

        public int Id { get; set; }

        public string? Nome { get; set; }
    }
}
