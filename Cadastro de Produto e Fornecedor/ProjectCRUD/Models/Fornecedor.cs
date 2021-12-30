using System.ComponentModel.DataAnnotations;

namespace ProjectCRUD.Models
{
    public class Fornecedor
    {
        [Key]
        public int FornecedorId { get; set; }

        [MaxLength(300)]
        public string RazaoSocial { get; set; }

        [MaxLength(300)]
        public string Fantasia { get; set; }

        [MaxLength(50)]
        public string CNPJ { get; set; }
    }
}
