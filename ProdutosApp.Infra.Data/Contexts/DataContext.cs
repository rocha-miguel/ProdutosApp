
using Microsoft.EntityFrameworkCore;
using ProdutosApp.Infra.Data.Mappings;

namespace ProdutosApp.Infra.Data.Contexts {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
