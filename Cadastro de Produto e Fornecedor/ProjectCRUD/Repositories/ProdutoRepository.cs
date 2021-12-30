using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectCRUD.Data;
using ProjectCRUD.Models;
using ProjectCRUD.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.Repositories
{
    public class ProdutoRepository : AbstractRepository<Produto>
    {
        private readonly ApplicationDbContext _db;

        public ProdutoRepository(ApplicationDbContext db, IConfiguration configuration) : base(configuration)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProdutoViewModel>> FindAll()
        {
            var produtos = new List<ProdutoViewModel>();

            var prod = await _db.Produto.ToListAsync();

            foreach (var p in prod)
            {
                produtos.Add(new ProdutoViewModel()
                {
                    ProdutoId = p.ProdutoId,
                    Descricao = p.Descricao,
                    Valor = p.Valor,
                    FornecedorId = p.FornecedorId
                });
            }

            return produtos;
        }

        public async Task<ProdutoViewModel> FindById(int id)
        {
            var produto = new ProdutoViewModel();

            var prod = await _db.Produto.Where(f => f.ProdutoId == id).FirstOrDefaultAsync();

            if (prod != null)
            {
                produto.ProdutoId = prod.ProdutoId;
                produto.Descricao = prod.Descricao;
                produto.Valor = prod.Valor;
                produto.FornecedorId = prod.FornecedorId;
            }

            return produto;
        }

        public async Task<ProdutoViewModel> Add(ProdutoViewModel produto)
        {
            var prod = new Produto()
            { 
                Descricao = produto.Descricao,
                Valor = produto.Valor,
                FornecedorId = produto.FornecedorId
            };

            _db.Produto.Add(prod);

            await _db.SaveChangesAsync();

            produto.ProdutoId = prod.ProdutoId;
            produto.Descricao = prod.Descricao;
            produto.Valor = prod.Valor;
            produto.FornecedorId = prod.FornecedorId;

            return produto;
        }

        public async Task<ProdutoViewModel> Update(ProdutoViewModel produto)
        {
            var prod = await _db.Produto.Where(f => f.ProdutoId == produto.ProdutoId).FirstOrDefaultAsync();

            if (prod != null)
            {
                _db.Produto.Attach(prod);

                prod.Descricao = produto.Descricao;
                prod.Valor = produto.Valor;
                prod.FornecedorId = produto.FornecedorId;

                await _db.SaveChangesAsync();
            }

            produto.ProdutoId = prod.ProdutoId;
            produto.Descricao = prod.Descricao;
            produto.Valor = prod.Valor;
            produto.FornecedorId = prod.FornecedorId;

            return produto;
        }

        public async Task<int> Remove(int id)
        {
            var produto = await _db.Produto.Where(f => f.ProdutoId == id).FirstOrDefaultAsync();

            if (produto != null)
            {
                _db.Produto.Remove(produto);
            }

            return await _db.SaveChangesAsync();
        }

        public async Task<FileStream> RelatorioProdutos()
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
                {
                    string sQuery = @"EXEC RelatorioProdutos";
                    dbConnection.Open();

                    var result = await dbConnection.ExecuteAsync(sQuery);

                    if (result > 0)
                    {
                        string path = @"D:\result.csv";
                        return File.OpenRead(path);
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
