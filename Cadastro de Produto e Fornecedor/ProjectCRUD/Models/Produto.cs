using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCRUD.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [MaxLength(300)]
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Valor { get; set; }

        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
