using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FlexEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [DisplayName("Nome do Produto")]
        public string NomeProduto { get; set; }
        [DisplayName("Código do Produto")]
        public string CodigoProduto { get; set; }
        [DisplayName("Descrição do Produto")]
        public string DescricaoProduto { get; set; }
        [DisplayName("Valor do Produto")]
        public string ValorProduto { get; set; }
        [DisplayName("Categoria do Produto")]
        public int? CategoriaProdutoId { get; set; }
        public virtual CategoriaProduto Categoria { get; set; }
        [DisplayName("Valiade do Produto")]
        public DateTime ValidadeProduto { get; set; }
        [DisplayName("Quantidade do Produto")]
        public int EstoqueMinimo { get; set; }
        public int EstoqueMaximo { get; set; }
    }
}
