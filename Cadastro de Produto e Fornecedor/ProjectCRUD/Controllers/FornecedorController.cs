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
    public class FornecedorController : ControllerBase
    {
        private readonly FornecedorRepository fornecedorRepository;

        public FornecedorController(IConfiguration configuration, ApplicationDbContext db)
        {
            fornecedorRepository = new FornecedorRepository(db, configuration);
        }

        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            var result = await fornecedorRepository.FindAll();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "No result" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(int id)
        {
            var result = await fornecedorRepository.FindById(id);

            if (result != null && result.FornecedorId > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "No result" });
            }
        }

        [HttpPost]
        public async Task<ObjectResult> Post([FromBody] FornecedorViewModel fornecedor)
        {
            var result = await fornecedorRepository.Add(fornecedor);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "No result" });
            }
        }

        [HttpPut]
        public async Task<ObjectResult> Put([FromBody] FornecedorViewModel fornecedor)
        {
            var result = await fornecedorRepository.Update(fornecedor);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "No result" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ObjectResult> Delete(int id)
        {
            var result = await fornecedorRepository.Remove(id);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "No result" });
            }
        }
    }
}
