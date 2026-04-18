

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Domain.Entities;

namespace ProdutosApp.Infra.Data.Mappings {
    public class ProdutoMap : IEntityTypeConfiguration<Produto> {
        public void Configure(EntityTypeBuilder<Produto> builder) {

            builder.ToTable("PRODUTOS");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID");

            builder.Property(p => p.Nome).HasColumnName("NOME").HasMaxLength(150).IsRequired();

            builder.Property(p => p.Preco).HasColumnName("PRECO").HasColumnType("DECIMAL(10,2)").IsRequired();

            builder.Property(p => p.Quantidade).HasColumnName("QUANTIDADE").IsRequired();

            builder.Property(p => p.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();

            builder.Property(p => p.Categoria).HasColumnName("CATEGORIA").IsRequired();

            builder.Property(p => p.Status).HasColumnName("STATUS").IsRequired();


        }
    }
}
