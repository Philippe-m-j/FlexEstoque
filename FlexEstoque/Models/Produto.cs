using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string ValorProduto { get; set; }
        public DateTime ValidadeProduto { get; set; }
        public int EstoqueMinimo { get; set; }
        public int EstoqueMaximo { get; set; }
    }
}
