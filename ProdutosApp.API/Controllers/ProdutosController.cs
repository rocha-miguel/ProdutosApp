using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Enums;
using ProdutosApp.Infra.Data.Repositories;

namespace ProdutosApp.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController(ProdutoRepository produtoRepository) {
            _produtoRepository = produtoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAsync(
                        [FromQuery] string nome,
                        [FromQuery] decimal preco,
                        [FromQuery] int quantidade,
                        [FromQuery] CategoriaProduto categoria,
                        [FromQuery] StatusProduto status) {
            var produto = new Produto {
                Nome = nome,
                Preco = preco,
                Quantidade = quantidade,
                Categoria = categoria,
                Status = status
            };

            await _produtoRepository.AdicionarAsync(produto);

            return StatusCode(201, new { mensagem = "Produto cadastrado com sucesso." });
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarAsync(Guid id, [FromBody] Produto produto) {


            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(Guid id) {

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ObterAsync() {


            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(Guid id) {

            return Ok();
        }

    }
}
