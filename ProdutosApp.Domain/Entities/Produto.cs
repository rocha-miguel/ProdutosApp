

using ProdutosApp.Domain.Enums;


namespace ProdutosApp.Domain.Entities {
    public class Produto {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; } = string.Empty;

        public decimal Preco { get; set; } = 0;

        public int Quantidade { get; set; } = 0;

        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;

        public CategoriaProduto Categoria { get; set; }

        public StatusProduto Status { get; set; }
    }
}
