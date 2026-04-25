
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.API.Dtos;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Enums;
using ProdutosApp.Infra.Data.Repositories;

namespace ProdutosApp.API.Controllers {
    [Route("api/v1/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController(ProdutoRepository produtoRepository) {
            _produtoRepository = produtoRepository;
        }

        [HttpPost("cadastrar-produto")]
        public async Task<IActionResult> CadastrarAsync([FromBody]ProdutoRequestDto request) {

            var produto = new Produto {
                Nome = request.Nome!,
                Preco = request.Preco!.Value,
                Quantidade = request.Quantidade!.Value,
                Categoria = (CategoriaProduto)request.Categoria!.Value,
                Status = (StatusProduto)request.Status!.Value

            };

            await _produtoRepository.AdicionarAsync(produto);

            return StatusCode(201, new {
                Mensagem = "Produto cadastrado com sucesso!",
                Produto = ToResponse(produto)
            });
        }



        [HttpPut("atualizar-produto-{id}")]
        public async Task<IActionResult> ModificarAsync(Guid id, [FromBody] ProdutoRequestDto request) {

            var produto = await _produtoRepository.ObterPorIdAsync(id);

            if (produto == null)
                return NotFound(new { mensagem = "Produto não encontrado." });

            produto.Nome = request.Nome!;
            produto.Preco = request.Preco!.Value;
            produto.Quantidade = request.Quantidade!.Value;
            produto.Categoria = (CategoriaProduto) request.Categoria!.Value;
            produto.Status = (StatusProduto) request.Status!.Value;

            await _produtoRepository.ModificarAsync(produto);

            return Ok(new { 
                Mensagem = "Produto atualizado com sucesso.",
                Produto = ToResponse(produto)
            });
        }

        [HttpDelete("deletar-produto-{id}")]
        public async Task<IActionResult> DeletarAsync(Guid id) {

            var produto = await _produtoRepository.ObterPorIdAsync(id);

            if (produto == null)
                return NotFound(new { mensagem = "Produto não encontrado." });

            await _produtoRepository.ExcluirAsync(produto);
            return Ok(new {
                Mensagem = "Produto excluído com sucesso!",
                Produto = ToResponse(produto)
            });
        }

        [HttpGet("obter-produtos")]
        public async Task<IActionResult> ObterAsync() {

            var produtos = await _produtoRepository.ConsultarAsync();

            return Ok(new {
                mensagem = "Lista de produtos",
                produtos = produtos.Select(produto => ToResponse(produto))
            });
        }

        [HttpGet("obter-porId-produto-{id}")]
        public async Task<IActionResult> ObterPorIdAsync(Guid id) {

            var produto = await _produtoRepository.ObterPorIdAsync(id);
            return Ok(new {
                Mensagem = "Produto obtido com sucesso!",
                Produto = ToResponse(produto!)
            });
        }

        private ProdutoResponseDto ToResponse(Produto produto) {

            return new ProdutoResponseDto {

                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                Total = produto.Preco * produto.Quantidade,
                DataHoraCadastro = produto.DataHoraCadastro,
                Categoria = new EnumDto {
                    Id = (int)produto.Categoria,
                    Nome = produto.Categoria.ToString(),
                },
                Status = new EnumDto {
                    Id = (int)produto.Status,
                    Nome = produto.Status.ToString(),
                }
            };
        }

    }
}
