
using Microsoft.EntityFrameworkCore;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Infra.Data.Contexts;

namespace ProdutosApp.Infra.Data.Repositories {
    public class ProdutoRepository {

        private readonly DataContext _dataContext;

        public ProdutoRepository(DataContext dataContext) {
            _dataContext = dataContext;
        }

        public async Task AdicionarAsync(Produto produto) {


            await _dataContext.AddAsync(produto);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ModificarAsync(Produto produto) {

            _dataContext.Update(produto);
            await _dataContext.SaveChangesAsync();

        }

        public async Task ExcluirAsync(Produto produto) {

            _dataContext.Remove(produto);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<List<Produto>> ConsultarAsync() {

            return await _dataContext
                .Set<Produto>()
                .OrderBy(p => p.Nome)
                .ToListAsync();

        }

        public async Task<Produto?> ObterPorIdAsync(Guid id) {

            return await _dataContext
                .Set<Produto>()
                .FirstOrDefaultAsync(p => p.Id == id);

        }

    }
}
