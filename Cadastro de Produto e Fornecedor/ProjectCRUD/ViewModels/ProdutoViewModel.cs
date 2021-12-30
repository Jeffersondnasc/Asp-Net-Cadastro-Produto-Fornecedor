using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCRUD.ViewModels
{
    public class ProdutoViewModel
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
        public int FornecedorId { get; set; }
    }
}
