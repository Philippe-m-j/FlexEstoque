using FlexEstoque.Data;
using FlexEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlexEstoque.Controllers
{
    public class LoginController : Controller
    {
        private readonly FlexEstoqueContext _context;

        public LoginController(FlexEstoqueContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entrar(LoginInicial loginInicial)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    if(loginInicial.Login == "Admin" && loginInicial.Senha == "23213021")


                    return RedirectToAction("Index", "Home");
                }

                TempData["MensagemErro"] = $"Usuário ou senha inválidos. Por Favor, tente novamente.";
                

                return View("Index");  
            }
            catch (Exception erro) 
            {

                TempData["MensagemErro"] = $"Ops, não foi possivel conectar com seu login, tente novamente, detalhe o erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
