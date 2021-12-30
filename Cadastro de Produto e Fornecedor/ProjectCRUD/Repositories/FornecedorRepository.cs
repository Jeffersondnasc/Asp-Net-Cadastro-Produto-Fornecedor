using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectCRUD.Data;
using ProjectCRUD.Models;
using ProjectCRUD.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.Repositories
{
    public class FornecedorRepository : AbstractRepository<Fornecedor>
    {
        private readonly ApplicationDbContext _db;

        public FornecedorRepository(ApplicationDbContext db, IConfiguration configuration) : base(configuration)
        {
            _db = db;
        }

        public async Task<IEnumerable<FornecedorViewModel>> FindAll()
        {
            var fornecedores = new List<FornecedorViewModel>();

            var forn = await _db.Fornecedor.ToListAsync();

            foreach (var f in forn)
            {
                fornecedores.Add(new FornecedorViewModel()
                { 
                    FornecedorId = f.FornecedorId,
                    RazaoSocial = f.RazaoSocial,
                    Fantasia = f.Fantasia,
                    CNPJ = f.CNPJ
                });
            }

            return fornecedores;
        }

        public async Task<FornecedorViewModel> FindById(int id)
        {
            var fornecedor = new FornecedorViewModel();

            var forn = await _db.Fornecedor.Where(f => f.FornecedorId == id).FirstOrDefaultAsync();

            if (forn != null)
            {
                fornecedor.FornecedorId = forn.FornecedorId;
                fornecedor.RazaoSocial = forn.RazaoSocial;
                fornecedor.Fantasia = forn.Fantasia;
                fornecedor.CNPJ = forn.CNPJ;
            }

            return fornecedor;
        }

        public async Task<FornecedorViewModel> Add(FornecedorViewModel fornecedor)
        {
            var forn = new Fornecedor()
            {
                RazaoSocial = fornecedor.RazaoSocial,
                Fantasia = fornecedor.Fantasia,
                CNPJ = fornecedor.CNPJ
            };

            _db.Fornecedor.Add(forn);

            await _db.SaveChangesAsync();

            fornecedor.FornecedorId = forn.FornecedorId;
            fornecedor.RazaoSocial = forn.RazaoSocial;
            fornecedor.Fantasia = forn.Fantasia;
            fornecedor.CNPJ = forn.CNPJ;

            return fornecedor;
        }

        public async Task<FornecedorViewModel> Update(FornecedorViewModel fornecedor)
        {
            var forn = await _db.Fornecedor.Where(f => f.FornecedorId == fornecedor.FornecedorId).FirstOrDefaultAsync();

            if (forn != null)
            {
                _db.Fornecedor.Attach(forn);

                forn.RazaoSocial = fornecedor.RazaoSocial;
                forn.Fantasia = fornecedor.Fantasia;
                forn.CNPJ = fornecedor.CNPJ;

                await _db.SaveChangesAsync();
            }

            fornecedor.FornecedorId = forn.FornecedorId;
            fornecedor.RazaoSocial = forn.RazaoSocial;
            fornecedor.Fantasia = forn.Fantasia;
            fornecedor.CNPJ = forn.CNPJ;

            return fornecedor;
        }

        public async Task<int> Remove(int id)
        {
            var fornecedor = await _db.Fornecedor.Where(f => f.FornecedorId == id).FirstOrDefaultAsync();

            if (fornecedor != null)
            {
                _db.Fornecedor.Remove(fornecedor);
            }

            return await _db.SaveChangesAsync();
        }
    }
}
