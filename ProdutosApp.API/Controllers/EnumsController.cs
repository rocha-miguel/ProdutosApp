using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Domain.Enums;

namespace ProdutosApp.API.Controllers {
    [Route("api/v1/enums")]
    [ApiController]
    public class EnumsController : ControllerBase {

        [HttpGet("obter-categorias")]
        public async Task<IActionResult> ObterCategoriasAsync() {

            var result = Enum.GetValues(typeof(CategoriaProduto))
                .Cast<CategoriaProduto>()
                .Select(c => new {
                    Id = (int)c,
                    Nome = c.ToString()
                });

            return Ok(result);
        }

        [HttpGet("obter-status")]
        public async Task<IActionResult> ObterStatusAsync() {

            var result = Enum.GetValues(typeof(StatusProduto))
                .Cast<StatusProduto>()
                .Select(s => new {
                    Id = (int)s,
                    Nome = s.ToString()
                });

            return Ok(result);
        }

    }
}
