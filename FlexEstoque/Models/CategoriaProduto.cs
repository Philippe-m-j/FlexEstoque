using System.ComponentModel;

namespace FlexEstoque.Models
{
    public class CategoriaProduto
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        public string Descricao { get; set; }
    }
}
