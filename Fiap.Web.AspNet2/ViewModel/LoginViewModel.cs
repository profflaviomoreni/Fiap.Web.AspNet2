using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet2.ViewModel
{
    public class LoginViewModel
    {

        [HiddenInput]
        public int LoginId { get; set; }

        [Display(Name = "Usuário")]
        public String Usuario { get; set; }

        public String NomeUsuario { get; set; }

        public String Senha { get; set; }

        public String Token { get; set; }

    }
}
