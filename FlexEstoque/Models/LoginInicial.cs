﻿using System.ComponentModel.DataAnnotations;

namespace FlexEstoque.Models
{
    public class LoginInicial
    {
        [Required(ErrorMessage ="Digite o Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }

    }
}
