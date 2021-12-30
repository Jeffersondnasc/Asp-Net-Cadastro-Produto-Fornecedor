using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.ViewModels
{
    public class FornecedorViewModel
    {
        public int FornecedorId { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string CNPJ { get; set; }
    }
}
