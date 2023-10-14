using FlexEstoque.Models;

namespace FlexEstoque.Repository
{
    public interface IUsuarioRepository
    {
        Usuario BuscarPorLogin(string login);
    }
}
