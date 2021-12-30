using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectCRUD.Data;
using ProjectCRUD.Models;
using ProjectCRUD.Repositories;
using ProjectCRUD.ViewModels;

namespace ProjectCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository produtoRepository;

        public ProdutoController(IConfiguration configuration, ApplicationDbContext db)
        {
            produtoRepository = new ProdutoRepository(db, configuration);
        }

        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            var result = await produtoRepository.FindAll();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "Sem resultado" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(int id)
        {
            var result = await produtoRepository.FindById(id);

            if (result != null && result.ProdutoId > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "Sem resultado" });
            }
        }

        [HttpPost]
        public async Task<ObjectResult> Post([FromBody] ProdutoViewModel produto)
        {
            var result = await produtoRepository.Add(produto);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "Sem resultado" });
            }
        }

        [HttpPut]
        public async Task<ObjectResult> Put([FromBody] ProdutoViewModel produto)
        {
            var result = await produtoRepository.Update(produto);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "Sem resultado" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ObjectResult> Delete(int id)
        {
            var result = await produtoRepository.Remove(id);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "Sem resultado" });
            }
        }

        [HttpGet("RelatorioProdutos")]
        [Produces("text/csv")]
        public async Task<ObjectResult> RelatorioProdutos()
        {
            var result = await produtoRepository.RelatorioProdutos();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "Sem resultado" });
            }
        }
    }
}
